using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

namespace DataStructures.UtilityClasses
{
    /// <summary>
    /// Contains functions used to obtain the directory and name where files are saved.
    /// </summary>
    public class NamingFunctions
    {
        /// <summary>
        /// Adds the appropriate number of zeros so that number has n0 digit
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n0"></param>
        /// <returns></returns>
        public static string number_to_string(int number, int n0)
        {
            string res = number.ToString();
            for (int i = 0; i < n0 - number.ToString().Length; i++)
            {
                res = "0" + res;
            }
            return res;
        }

        /// <summary>
        /// Obtains a list '_' separated of the bound variables and their values, reported in the name of the shot
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static string listBoundVariables(SequenceData sequence)
        {
            string listBoundVariableValues = "";

            foreach (Variable var in sequence.Variables)
            {

                if (var.ListDriven && !var.PermanentVariable)
                {
                    if (listBoundVariableValues != "")
                    {
                        listBoundVariableValues += "_";
                    }
                    listBoundVariableValues += var.VariableName + " = " + var.VariableValue.ToString();
                }
            }


            return listBoundVariableValues;

        }

        /// <summary>
        /// Obtains the directory in which the files will be saved
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string get_fileDirectory(SettingsData settings)
        {
            string fileDirectory;
            // 2016-12-19 Benno Rem: Changed to several different options
            switch (settings.StyleFileTimestamps)
            {
                case DataStructures.SettingsData.StyleTypes.Paris:
                    {
                        DateTime today = DateTime.Today;
                        string the_year = today.Year.ToString();
                        CultureInfo the_current_culture = CultureInfo.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
                        string the_month = String.Format("{0:MMM}", today).ToString();
                        Thread.CurrentThread.CurrentCulture = the_current_culture;
                        the_month = the_month.Substring(0, 1).ToUpper() + the_month.Substring(1);
                        string the_day = number_to_string(today.Day, 2);

                        if (settings.SavePath.EndsWith("/") || settings.SavePath.EndsWith(@"\"))
                            fileDirectory = settings.SavePath.Remove(settings.SavePath.Length - 1) + @"\" + the_year + @"\" + the_month + the_year + @"\" + the_day + the_month + the_year;
                        else if (settings.SavePath != "")
                            fileDirectory = settings.SavePath + @"\" + the_year + @"\" + the_month + the_year + @"\" + the_day + the_month + the_year;
                        else
                            fileDirectory = AppDomain.CurrentDomain.BaseDirectory + the_year + @"\" + the_month + the_year + @"\" + the_day + the_month + the_year;
                        break;
                    }
                case DataStructures.SettingsData.StyleTypes.Hamburg:
                    {
						// In the Hamburg style system, protocols are saved as [BaseDirectory]\YYYY\YYYY_MM\YYYY_MM_DD\YYYY_MM_DD_IIII_proto.[cgl/xml]
						// where YYYY corresponds to year, MM to month, DD to day and IIII to the id of the image, which is increased after each image
						// Images are then saved accordingly with the addition of AA, corresponding to the imaging axis 
						// [BaseDirectory]\YYYY\YYYY_MM\YYYY_MM_DD\YYYY_MM_DD_AA_IIII_[atoms/noatoms/dark1/dark2].[png/tif])
						// DONE 2017/04/19: change this to use id's instead of times (this will simplify communication with Matthias' program)
						DateTime today = DateTime.Today;
						string the_year = today.Year.ToString();
						CultureInfo the_current_culture = CultureInfo.CurrentCulture;
						//Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
						string the_month = number_to_string(today.Month, 2); //today.Month.ToString("00");// String.Format("{0:MMM}", today).ToString();
						//Thread.CurrentThread.CurrentCulture = the_current_culture;
						//the_month = the_month.Substring(0, 1).ToUpper() + the_month.Substring(1);
						string the_day = number_to_string(today.Day, 2);

						if (settings.SavePath.EndsWith("/") || settings.SavePath.EndsWith(@"\"))
							fileDirectory = settings.SavePath.Remove(settings.SavePath.Length - 1) + @"\" + the_year + @"\" + the_year + "_" + the_month + @"\" + the_year + "_" + the_month + "_" + the_day;
						else if (settings.SavePath != "")
							fileDirectory = settings.SavePath + @"\" + the_year + @"\" + the_year + "_" + the_month + @"\" + the_year + "_" + the_month + "_" + the_day;
						else
							fileDirectory = AppDomain.CurrentDomain.BaseDirectory + the_year + @"\" + the_year + "_" + the_month + @"\" + the_year + "_" + the_month + "_" + the_day;
						break;
                    }
                default:
                {
                    if (settings.SavePath.EndsWith("/") || settings.SavePath.EndsWith(@"\"))
                        fileDirectory = settings.SavePath.Remove(settings.SavePath.Length - 1);
                    else if (settings.SavePath != "")
                        fileDirectory = settings.SavePath;
                    else
                        fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    break;
                }
            }
            //if (!settings.UseParisStyleFileTimestamps)
            //{
            //    if (settings.SavePath.EndsWith("/") || settings.SavePath.EndsWith(@"\"))
            //        fileDirectory = settings.SavePath.Remove(settings.SavePath.Length - 1);
            //    else if (settings.SavePath != "")
            //        fileDirectory = settings.SavePath;
            //    else
            //        fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //}
            //else
            //{
            //    DateTime today = DateTime.Today;
            //    string the_year = today.Year.ToString();
            //    CultureInfo the_current_culture = CultureInfo.CurrentCulture;
            //    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
            //    string the_month = String.Format("{0:MMM}", today).ToString();
            //    Thread.CurrentThread.CurrentCulture = the_current_culture;
            //    the_month = the_month.Substring(0, 1).ToUpper() + the_month.Substring(1);
            //    string the_day = number_to_string(today.Day, 2);

            //    if (settings.SavePath.EndsWith("/") || settings.SavePath.EndsWith(@"\"))
            //        fileDirectory = settings.SavePath.Remove(settings.SavePath.Length - 1) + @"\" + the_year + @"\" + the_month + the_year + @"\" + the_day + the_month + the_year;
            //    else if (settings.SavePath != "")
            //        fileDirectory = settings.SavePath + @"\" + the_year + @"\" + the_month + the_year + @"\" + the_day + the_month + the_year;
            //    else
            //        fileDirectory = AppDomain.CurrentDomain.BaseDirectory + the_year + @"\" + the_month + the_year + @"\" + the_day + the_month + the_year;
            //}
            return fileDirectory;

        }

        ///// <summary>
        ///// Obtains the directory in which the files will be saved
        ///// </summary>
        ///// <param name="settings"></param>
        ///// <returns></returns>
        //public string generateFileString(string template)
        //{
        //    // generates ID format
        //    idFormat = "";
        //    foreach (char c in template)
        //        if (c == 'I') idFormat = idFormat + "0";


        //    template = template.Replace("I", "");
        //    template = template.Replace("NN", cameraName);
        //    template = template.Replace("YYYY", the_year);
        //    template = template.Replace("MM", the_month);
        //    template = template.Replace("DD", the_day);
        //    template = template.Replace("AA", axisID);
        //    if (template[template.Length - 1] != '_') template = template + "_";

        //    return template;
        //}

		private static Dictionary<string,int> sscanf(string s, string format, List<string> tokens)
		{
			int index = -1;
			StringBuilder key = new StringBuilder();
			StringBuilder value = new StringBuilder();
			Dictionary<string,int> dic = new Dictionary<string,int>();

			int val = 0;
			while (index < s.Length-1)
			{
				index++;
				if (s[index] == format[index])
				{
					if (key.Length == 0)
						continue;
				
					if (!tokens.Contains(key.ToString()) || !Int32.TryParse(value.ToString(), out val))
						return null;

					dic.Add(key.ToString(), val);
					key.Length = 0;
					value.Length = 0;
				}
				else
				{
					key.Append(format[index]);
					value.Append(s[index]);
				}	
			}

			//Add possible last found key/value
			if (key.Length > 0 && (!tokens.Contains(key.ToString()) || !Int32.TryParse(value.ToString(), out val)))
				return null;
			dic.Add(key.ToString(), val);

			return dic;
		}
		public static int get_fileID(SettingsData settings)
		{
			//Read in template from Cicero menu
			string template = settings.FileName;
			//First extract ID format
			StringBuilder _idToken = new StringBuilder();
			StringBuilder _idFormat = new StringBuilder();
			foreach (char c in template)
				if (c == 'I')
				{
					_idToken.Append("I");
					_idFormat.Append("0");
				}
			string idToken = _idToken.ToString();
			string idFormat = _idFormat.ToString();


			//Get last ID
			var directory = new System.IO.DirectoryInfo(get_fileDirectory(settings) + @"\");	//todo: Keep in mind midnight problem
			var id = 0;

			if (!(directory == null || !directory.Exists))
			{
				System.IO.FileInfo[] files = directory.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);
				foreach (System.IO.FileInfo file in files)
				{
					string fname = System.IO.Path.GetFileNameWithoutExtension(file.Name);
					var result = sscanf(fname, template, new List<string> { "YYYY", "MM", "DD", idToken });
					if (result != null && result.ContainsKey(idToken))
					{
						if (result[idToken] > id) //YYYY_MM_DD_AXIS_ID_[no]atoms.tif
							id = result[idToken];
					}
					else
					{
						//Error handling
						throw new Exception("Could not parse log ID according to template " +  template + " from file name in: " +  System.IO.Path.GetFileNameWithoutExtension(file.Name));
					}
				}
			}
			return id + 1;
		}

		public static string getfrom_template(DateTime runTime, string template, int id)
		{
			//Parse template and return file string
			StringBuilder _idToken = new StringBuilder();
			StringBuilder _idFormat = new StringBuilder();
			foreach (char c in template)
				if (c == 'I')
				{
					_idToken.Append("I");
					_idFormat.Append("0");
				}
			string idToken = _idToken.ToString();
			string idFormat = _idFormat.ToString();

			StringBuilder fileStamp = new StringBuilder(template);

			if (!string.IsNullOrEmpty(idToken))
				fileStamp = fileStamp.Replace(idToken, id.ToString(idFormat));
			fileStamp = fileStamp.Replace("YYYY", runTime.Year.ToString());
			fileStamp = fileStamp.Replace("MM", runTime.Month.ToString("00"));
			fileStamp = fileStamp.Replace("DD", runTime.Day.ToString("00"));

			return fileStamp.ToString();
		}
        /// <summary>
        /// Obtains the name of the shot, containing bound variables, the name and the description of the sequence
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="settings"></param>
        /// <param name="runTime"></param>
        /// <returns></returns>
        public static string get_fileStamp(SequenceData sequence, SettingsData settings, DateTime runTime)
        {
            string fileStamp;
            switch (settings.StyleFileTimestamps)
            {
                case DataStructures.SettingsData.StyleTypes.Paris:
                    {
                        fileStamp = number_to_string(runTime.Hour, 2) + number_to_string(runTime.Minute, 2) + number_to_string(runTime.Second, 2);
                        if (sequence.SequenceName != "")
                            fileStamp = fileStamp + "_" + ProcessName(sequence.SequenceName, sequence);
                        if (sequence.SequenceDescription != "")
                            fileStamp = fileStamp + "_" + ProcessName(sequence.SequenceDescription, sequence);
                        if (listBoundVariables(sequence) != "")
                            fileStamp = fileStamp + "_" + listBoundVariables(sequence);
                        break;
                    }
                case DataStructures.SettingsData.StyleTypes.Hamburg:
                    {
						// DONE 2017/04/19: change this to use id's instead of times (this will simplify communication with Matthias' program)
						// [BaseDirectory]\YYYY\YYYY_MM\YYYY_MM_DD\YYYY_MM_DD_AA_IIII_[atoms/noatoms/dark1/dark2].[png/tif])

						//var delim = settings.Delimiter;
						fileStamp = getfrom_template(runTime, settings.FileName, get_fileID(settings));
						//string id = get_fileID(settings);
						//fileStamp = "Protocol-" + fileStamp + delim + id;//Common.getTimeStampString(runTime);
						break;
                    }
                default:
                    {
                        fileStamp = "RunLog-" + Common.getTimeStampString(runTime);
                        break;
                    }
            }
            //if (!settings.UseParisStyleFileTimestamps)
            //{
            //    fileStamp = "RunLog-" + Common.getTimeStampString(runTime);
            //}
            //else
            //{
            //    fileStamp = number_to_string(runTime.Hour, 2) + number_to_string(runTime.Minute, 2) + number_to_string(runTime.Second, 2);
            //    if (sequence.SequenceName != "")
            //        fileStamp = fileStamp + "_" + ProcessName(sequence.SequenceName,sequence);
            //    if (sequence.SequenceDescription != "")
            //        fileStamp = fileStamp + "_" + ProcessName(sequence.SequenceDescription,sequence);
            //    if (listBoundVariables(sequence) != "")
            //        fileStamp = fileStamp + "_" + listBoundVariables(sequence);
            //}
            return fileStamp;
        }

        /// <summary>
        /// Looks for variable names in the sequence name or description to add the value afterwards
        /// </summary>
        /// <param name="theName"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static string ProcessName(string theName, SequenceData sequence)
        {
            string ans = theName;
            foreach (Variable var in sequence.Variables)
            {

                if (!var.ListDriven || var.PermanentVariable)
                {
                    if (theName.Contains(var.VariableName))
                        ans = ans.Replace(var.VariableName, var.VariableName + " = " + var.VariableValue.ToString());
                }
            }
            return ans;
        }
    }
}
