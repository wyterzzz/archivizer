using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ExeCompressor.Classes
{
    public abstract class AbstractCompressor : ICompress
    {
        #region Fields
        private Boolean processAlive;
        protected String programPath;
        protected String patternArguments;
        #endregion

        #region Events
        public event EventHandler ProcessFinished;
        #endregion

        #region Properties
        public Boolean ProcessAlive
        {
            get { return this.processAlive; }
            set
            {
                if (this.ProcessFinished != null && value == false)
                    this.ProcessFinished(value, new EventArgs());
                this.processAlive = value;
            }
        }
        #endregion

        #region Constructor
        public AbstractCompressor(String programPath)
        {
            if (ValidateProgram(programPath)) 
                this.programPath = programPath;
            else
                throw new Exception(String.Format("\"{0}\" is invalid program file path.", programPath));

            this.processAlive = false;
        }
        #endregion

        #region Methods
        public abstract void Compress(String filePath);

        protected void CommandExecutor(String arguments)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = this.programPath,
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true
                }
            };

            Console.WriteLine(arguments);
            process.Start();
            processAlive = true;

            while (!process.HasExited){}

            ProcessAlive = false;
        }

        protected bool ValidateProgram(String programPath)
        {
            if (File.Exists(programPath) && programPath.EndsWith(".exe"))
                return true;
            return false;
        }
        #endregion
    }
}
