using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

namespace Archivizor_Project.Classes.Algorithms.Compressing
{
    public abstract class AbstractAlgorithm : IArchive 
    {
        #region Fields
        public delegate void ProcessOutputChangedEventHandler(String output);

        public event EventHandler ProcessFinished;
        public event ProcessOutputChangedEventHandler ProcessOutputChanged;

        private Boolean processAlive;
         
        protected String programPath;
        protected String argumentsArchive;
        protected String argumentsExtract;
        protected String processOutput;
        protected String compressionMethod;
        protected String compressionLevel;

        protected StringBuilder items;
        
        protected Process process;

        #endregion

        #region Properties
        public String CompressionLevel
        {
            get { return compressionLevel; }
            set { compressionLevel = value; }
        }
        public String CompressionMethod
        {
            get { return compressionMethod; }
            set { compressionMethod = value; }
        }
        protected String ProcessOutput
        {
            get { return processOutput; }
            set 
            { 
                if (ProcessOutputChanged != null && this.processOutput != value)
                {
                    this.ProcessOutputChanged(value);
                }
                processOutput = value; 
            }
        }
        protected Boolean ProcessAlive
        {
            get { return processAlive; }
            set 
            {
                if (this.ProcessFinished != null && value == false)
                    this.ProcessFinished(value, new EventArgs());
                processAlive = value; 
            }
        }
        public String ProgramPath
        {
            get { return this.programPath; }
            set {
                if (ValidateProgram(value))
                    this.programPath = value;
                else
                    throw new Exception(String.Format("\"{0}\" is invalid program file path.", programPath));
                }
        }
        #endregion

        #region Constructor
        public AbstractAlgorithm(String programPath)
        {
            if (ValidateProgram(programPath)) 
                this.programPath = programPath;
            else
                throw new Exception(String.Format("\"{0}\" is invalid program file path.", programPath));

            this.processAlive = false;
            this.items = new StringBuilder();
        }
        #endregion

        #region Methods
        public abstract void ExtractArchive(String archivePath, String destinationPath);

        public abstract void GenerateArchive(String archivePath);

        protected void CommandExecutor(String arguments)
        {
            this.process = new Process
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
            //Console.WriteLine(arguments);
            
            try
            {
                this.process.Start();
            }
            catch (Exception)
            {
                throw new Exception("Try with another algorithm or if you want this one, you should change your OS from XP to another one - Vista or 7.");
            }

            this.processAlive = true;

            while (true)
            {
                byte[] buffer = new byte[256];
                var ar = this.process.StandardOutput.BaseStream.BeginRead(buffer, 0, 256, null, null);
                ar.AsyncWaitHandle.WaitOne();
                var bytesRead = this.process.StandardOutput.BaseStream.EndRead(ar);
                if (bytesRead > 0)
                {
                    this.ProcessOutput = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                }
                else
                {
                    this.process.WaitForExit();
                    this.ProcessAlive = false;
                    break;
                }
            }
        }

        public void Add(String itemPath)
        {
            if (Validate(itemPath))
                this.items.Append(String.Format("\"{0}\" ", itemPath));
        }

        public void AddRange(List<String> itemsPaths)
        {
            AddRange(itemsPaths.ToArray());
        }

        public void AddRange(String[] itemsPaths)
        {
            foreach (String item in itemsPaths) Add(item);
        }

        protected bool Validate(String itemPath)
        {
            if (File.Exists(itemPath) || Directory.Exists(itemPath))
                return true;
            return false;
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
