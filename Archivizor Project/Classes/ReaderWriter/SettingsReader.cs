using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;

namespace Archivizor_Project.Classes.ReaderWriter
{
    public class SettingsReader
    {
        #region Fields
        public static readonly String defConfigsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\configs\Archiving Settings\";

        private Regex regexMethods;
        private Regex regexLevels;
        private Regex regexPassword;
        
        private String settingsPath;
        private String settingsText;

        private List<String> methods;
        private List<String> levels;

        private Boolean hasPassword;
        #endregion

        #region Properties
        public Boolean HasPassword
        {
            get { return hasPassword; }
        }
        public List<String> Methods
        {
            get { return methods; }
        }
        public List<String> Levels
        {
            get { return levels; }
        }
        public String SettingsPath
        {
            get { return settingsPath; }
            set { settingsPath = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// New instance
        /// </summary>
        /// <param name="settingsPath">Path of the settings</param>
        public SettingsReader(String settingsPath)
        {
            if (File.Exists(settingsPath))
            {
                this.regexPassword = new Regex("%(.*)");
                this.regexMethods = new Regex("#(.*)");
                this.regexLevels = new Regex("-(.*)");
                
                this.methods = new List<String>();
                this.levels = new List<String>();
                
                this.settingsPath = settingsPath;
                this.settingsText = File.ReadAllText(this.settingsPath);

                SetLevels();
                SetMethods();
                SetPassword();
            }
            else
            {
                throw new Exception("Invalid file.");
            }
        }
        #endregion

        #region Methods
        private void SetPassword()
        {
            this.hasPassword = Boolean.Parse(regexPassword.Match(this.settingsText).Groups[1].Value);   
        }
        private void SetMethods()
        {
            foreach (Match match in regexMethods.Matches(this.settingsText))
            {
                this.methods.Add(match.Groups[1].Value);
            } 
        }
        private void SetLevels()
        {
            foreach (Match match in regexLevels.Matches(this.settingsText))
            {
                this.levels.Add(match.Groups[1].Value);
            }
        }
        /*
        public Dictionary<String, String[]> GetEntries()
        {
            List<String> valuesList = new List<String>();
            String currentExtension = null;
            String tempLine;

            using (StreamReader streamReader = new StreamReader(this.settingsPath))
            {
                while ((tempLine = streamReader.ReadLine()) != null)
                {
                    if (!regexSection.IsMatch(tempLine))
                    {
                        valuesList.Add(regexEntry.Match(tempLine).Groups[1].Value);
                    }
                    else
                    {
                        if (currentExtension != null)
                            this.sectionsValues.Add(currentExtension, valuesList.ToArray());
                        currentExtension = regexSection.Match(tempLine).Groups[1].Value;
                        valuesList = new List<String>();
                    }
                }
                this.sectionsValues.Add(currentExtension, valuesList.ToArray());
            }

            return sectionsValues;
        }*/
        #endregion
    }
}
