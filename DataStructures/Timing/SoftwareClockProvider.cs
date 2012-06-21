﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DataStructures.Timing
{

    /// <summary>
    /// Base class for software clock providers.
    /// </summary>
    public abstract class SoftwareClockProvider
    {
        private object lockObj = new object();
        private bool threadsRunning = false;

        public class SoftwareClockProviderException : Exception {
            public SoftwareClockProviderException(string message) : base(message)
            {}
        }

        protected List<SoftwareClockSubscriber> subscribers;
        protected Dictionary<SoftwareClockSubscriber, Thread> subscriberThreads;
        protected Dictionary<SoftwareClockSubscriber, int> subscriberPollingPeriods_ms;
        protected Dictionary<SoftwareClockSubscriber, int> subscriberPritorities;

        protected UInt32 elapsedTime_ms;

		private object synchronizationObject = new object();

        private EventHandler<MessageEvent> messageLog;

        protected SoftwareClockProvider()
        {
            subscribers = new List<SoftwareClockSubscriber>();
            subscriberThreads = new Dictionary<SoftwareClockSubscriber,Thread>();
            subscriberPollingPeriods_ms = new Dictionary<SoftwareClockSubscriber,int>();
            subscriberPritorities = new Dictionary<SoftwareClockSubscriber, int>();
        }

        public void registerMessageLogHandler(EventHandler<MessageEvent> handler)
        {
            messageLog += handler;
        }

        protected void logMessage(MessageEvent message)
        {
            if (messageLog != null)
                messageLog(this, message);
        }

        public void clearSubscribers()
        {
            if (threadsRunning)
                throw new SoftwareClockProviderException("Attempted to clear subscribers while threads are still running. You must call Abort() first.");

            subscribers.Clear();
            subscriberThreads.Clear();
            subscriberPollingPeriods_ms.Clear();
            subscriberPritorities.Clear();
        }

        /// <summary>
        /// May add a subscriber even while clock is running.
        /// 
        /// Priority is an optional integer parameter that gets passed to the subscriber in addition to the time
        /// Subscriber may use this to decide among several clock sources.
        /// 
        /// Note -- it a subscriber subscribes to multiple clocks, the individual clocks are NOT guaranteed to be
        /// on the same thread as eachother
        /// </summary>
        /// <param name="sub"></param>
        /// <param name="minimumPollingPerios_ms"></param>
        public void addSubscriber(SoftwareClockSubscriber sub, int minimumPollingPerios_ms = 0, int priority=0)
        {
            lock (lockObj)
            {
                subscribers.Add(sub);
                subscriberPollingPeriods_ms.Add(sub, minimumPollingPerios_ms);
                subscriberPritorities.Add(sub, priority);

                if (threadsRunning)
                {
                    addAndStartSubscriberThread(sub);
                }
            }
        }

        public void Arm()
        {
            lock (lockObj)
            {
                armTimer();

                elapsedTime_ms = 0;
                foreach (SoftwareClockSubscriber sub in subscribers)
                {
                    addAndStartSubscriberThread(sub);
                }
                threadsRunning = true;
            }
        }

        private void addAndStartSubscriberThread(SoftwareClockSubscriber sub)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(subscriberThreadProc));
            subscriberThreads.Add(sub, thread);
            runningThreads++;
            thread.Start(new SubscriberThreadParameters(sub, subscriberPollingPeriods_ms[sub], subscriberPritorities[sub]));
            
        }

        public abstract void Start();

        protected abstract void abortTimer();
        protected abstract void armTimer();
        protected abstract void startTimer();

        private int runningThreads;

        public void Abort()
        {
            lock (lockObj)
            {
                abortTimer();

                foreach (Thread thread in subscriberThreads.Values)
                {
                    thread.Abort();
                }
                threadsRunning = false;
                
                clearSubscribers();

            }
        }


        public UInt32 getElapsedTime()
        {
            return elapsedTime_ms;
        }

        // Returns true if clock should keep running (there are still subscribers listening)
        // false otherwise
        protected bool reachTime(uint time_ms) {
            if (time_ms < elapsedTime_ms)
                throw new SoftwareClockProviderException("Attempted to go back in time!");


		

			lock(synchronizationObject) {
				elapsedTime_ms = time_ms;
				Monitor.PulseAll(synchronizationObject);
			}

            if (runningThreads == 0)
                return false;
            return true;
        }

        private class SubscriberThreadParameters
        {
            public SoftwareClockSubscriber subscriber;
            public int minPollTime_ms;
            public int priority;
            public SubscriberThreadParameters(SoftwareClockSubscriber sub, int minPollTime_ms, int priority)
            {
                this.subscriber = sub;
                this.minPollTime_ms = minPollTime_ms;
                this.priority = priority;
            }
        }

        private void subscriberThreadProc(object param)
        {
            if (!(param is SubscriberThreadParameters))
                throw new SoftwareClockProviderException("Passed wrong parameter type to subscriberThreadProc");

            SubscriberThreadParameters parameters = (SubscriberThreadParameters) param;

            SoftwareClockSubscriber subscriber = parameters.subscriber;
            int minPollingPeriod_ms = parameters.minPollTime_ms;
            int priority = parameters.priority;

            uint lastPoll = elapsedTime_ms;
            bool keepGoing = true;
            while (keepGoing)
            {

				lock (synchronizationObject) {
					Monitor.Wait(synchronizationObject);
				}

                
                uint thisPoll = elapsedTime_ms;
                if ((thisPoll - lastPoll) < minPollingPeriod_ms)
                    continue;

                lastPoll = thisPoll;
                try
                {
                    keepGoing = subscriber.reachedTime(thisPoll, priority);
                }
                catch (Exception e)
                {
                    if (!subscriber.handleExceptionOnClockThread(e))
                    {
                        runningThreads--;
                        throw;
                    }
                }
            }
            runningThreads--;
        }
    }
}
