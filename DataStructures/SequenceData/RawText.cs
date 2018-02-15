using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    /// <summary>
    /// This class defines a waveform, as used in Analog Groups, some gpibGroups, etc.
    /// </summary>
    [Serializable

    ,TypeConverter(typeof(ExpandableObjectConverter))
    // *** NOTE THE ABOVE LINE WAS ADDED Feb 11 2010. I don't know why it was missing in earlier revs,
    // and I am thus slightly suspicious that I may have taken it out as a workaround to some bug in .NET remoting.
    // SO if some weird bug in .NET remoting re-appears, I may have to remove above line.

    ]
	public class RawText
	{

        public void copyRawText(RawText copyMe)
        {

            this.dataFileName = copyMe.dataFileName;
            this.dataFromFile = copyMe.dataFromFile;

		}

		private string rawTextName;

		[Description("The name of this rawtext"), Category("Global")]
		public string RawTextName
		{
			get { return rawTextName; }
			set { rawTextName = value; }
		}

		private string rawTextValue;

		[Description("The value stored in this rawtext object"), Category("Global")]
		public string RawTextValue
		{
			get { return rawTextValue; }
			set { rawTextValue = value; }
		}

        /// <summary>
        /// Here we keep track of whether the data for this rawtext was loaded from a file.
        /// REO 10/2008
        /// </summary>
        private bool dataFromFile = false;

        [Description("Data from file."), Category("Parameters")]
        public bool DataFromFile
        {
            get { return dataFromFile; }
            set
            {
                //dataFromFile = (myInterpolationType.canReadDataFromFile) ? value : false;
				dataFromFile = value;
            }
        }

        /// <summary>
        /// The name of the file the data was loaded from.
        /// REO 10/2008
        /// </summary>
        private string dataFileName;

        [Description("Data file name."), Category("Parameters")]
        public string DataFileName
        {
            get { return dataFileName; }
            set { dataFileName = value; }
        }

        public RawText(string rawTextName) : this()
        {
            this.rawTextName = rawTextName;
        }

        public RawText(RawText copyMe)
        {


        }

        public RawText()
        {
            
        }

        public override string ToString()
        {
            return rawTextValue;
        }

        public Dictionary<Variable, string> usedVariables()
        {
            // TODO 2017.07.05 BR: Figure out which variables are used in a RawText object
			Dictionary<Variable, string> ans = new Dictionary<Variable, string>();
			// 
            // List<DimensionedParameter> allParameters = new List<DimensionedParameter>();
			// 
            // foreach (DimensionedParameter dp in allParameters)
            // {
            //     if (dp != null)
            //     {
            //         if (dp.parameter.variable != null)
            //         {
            //             if (!ans.ContainsKey(dp.parameter.variable))
            //             {
            //                 ans.Add(dp.parameter.variable, ".");
            //             }
            //         }
            //     }
            // }
			// 
            return ans;
        }

    }
}
