using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DataStructures
{
    [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
    public class RS232Group : Group<RS232GroupChannelData>
    {
        public override Dictionary<Variable, string> usedVariables()
        {
           Dictionary<Variable, string> ans = new Dictionary<Variable, string>();
           foreach (int id in this.ChannelDatas.Keys)
           {
               RS232GroupChannelData data = ChannelDatas[id];
               if (data.StringParameterStrings != null)
               {
                   foreach (StringParameterString sps in data.StringParameterStrings)
                   {
                       if (sps.Parameter.myParameter.variable != null)
                       {
                           if (!ans.ContainsKey(sps.Parameter.myParameter.variable))
                           {
                               ans.Add(sps.Parameter.myParameter.variable, " channel ID " + id + ".");
                           }
                       }
                   }
               }
           }
			// 2017.07.04 BR - Add the usage of variables in raw strings
           return ans;

        }

        public override Dictionary<Waveform, string> usedWaveforms()
        {
            return new Dictionary<Waveform, string>();
        }

        public bool channelEnabled(int rs232ID) { 
            if (!channelDatas.ContainsKey(rs232ID))
                return false;
            return channelDatas[rs232ID].Enabled;
        }

        public RS232Group(string name)
            : base(name)
        {
        }
    }

    [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
    public class RS232GroupChannelData {

		
        [Serializable, TypeConverter(typeof(RS232ChannelDataType.RS232ChannelDataTypeConverter))]
        public struct RS232ChannelDataType
        {
            public class RS232ChannelDataTypeConverter : EnumWrapperTypeConverter
            {
                public RS232ChannelDataTypeConverter()
                    : base(allTypes)
                {
                }
            }

            public static bool operator==(RS232ChannelDataType sonny, RS232ChannelDataType cher)
            {
                return sonny.myType == cher.myType;
            }

            public static bool operator!=(RS232ChannelDataType sonny, RS232ChannelDataType cher) {
                return ! (sonny == cher);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is RS232ChannelDataType))
                    return false;
                RS232ChannelDataType other = (RS232ChannelDataType)obj;
                return this == other;
            }

            public override int GetHashCode()
            {
                return 1;
            }

            private enum TypeEnum { Raw, Parameter, Field };
            private static readonly string[] names = new string[] { "Raw", "Parameter", "Field" };

            private RS232ChannelDataType(TypeEnum myType)
            {
                this.myType = myType;
            }

            private TypeEnum myType;

            public static readonly RS232ChannelDataType Raw = new RS232ChannelDataType(TypeEnum.Raw);
            public static readonly RS232ChannelDataType Parameter = new RS232ChannelDataType(TypeEnum.Parameter);
            public static readonly RS232ChannelDataType Field = new RS232ChannelDataType(TypeEnum.Field);

            public static readonly RS232ChannelDataType[] allTypes = new RS232ChannelDataType[] { Raw, Parameter, Field };

            public override string ToString()
            {
                return names[(int)myType];
            }

 
        }
        //public enum RS232DataType { 
        /// <summary>
        /// Raw string output.
        /// </summary>
        //    Raw ,
        //    Parameter,
		//	Field
		//
        //};
		

        /// <summary>
        /// Array of all supported rs-232 data types.
        /// </summary>
		//public static readonly RS232DataType[] allDataTypes = new RS232DataType[] { RS232DataType.Raw, RS232DataType.Parameter, RS232DataType.Field };


        private RS232ChannelDataType dataType;

        public RS232ChannelDataType DataType
        {
            get { return dataType; }
			set
			{
				dataType = value;
				if (dataType == RS232ChannelDataType.Field)
				{
					if (rawText == null)
						rawText = new RawText();
				}
			}
		}

		private RawText rawText;
		public RawText RawText
		{
			get
			{
				return rawText;
			}
			set { rawText = value; }
		}

        private string rawString;

        public string RawString
        {
            get
            {
                if (rawString == null)
                    rawString = "";

                return rawString;
            }
            set { rawString = value; }
        }

        private bool channelEnabled;

        public bool Enabled
        {
            get { return channelEnabled; }
            set { channelEnabled = value; }
        }

        private List<StringParameterString> stringParameterStrings;

        public List<StringParameterString> StringParameterStrings
        {
            get { return stringParameterStrings; }
            set { stringParameterStrings = value; }
        }

    }
}
