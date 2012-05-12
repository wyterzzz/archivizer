using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Archivizor_Project.Classes.Algorithms.Compressing
{
    public class SevenZip : AbstractAlgorithm, IArchive
    {
        private String tempArgs;
        private String password;

        public String Password
        {
            get { return this.password; }
            set { if (!String.IsNullOrEmpty(value)) this.password = value; }
        }

        public SevenZip(String programPath)
            : base(programPath)
        {
            this.compressionMethod = "LZMA";
            this.argumentsArchive = "a -t{0} -m0={1} -mmt=on -sccUTF-8 \"{2}\" {3}";
            this.argumentsExtract = "x -aos \"-o{0}\" -sccUTF-8 \"{1}\"";
        }

        private void Generate(String type, String destinationPath)
        {
            if (this.items.Length > 0)
            {
                tempArgs = String.Format(this.argumentsArchive, type, this.compressionMethod.Trim(), destinationPath, this.items.ToString());
                if (!String.IsNullOrEmpty(password))
                    tempArgs += String.Format(" -p\"{0}\"", password);
                if (destinationPath.EndsWith(".exe"))
                    tempArgs += " -sfx7z.sfx";
                CommandExecutor(tempArgs);
            }
        }

        public void GenerateSFX(String sfxPath)
        {
            Generate("7z", sfxPath);
        }

        public override void GenerateArchive(String archivePath)
        {
            Generate(archivePath.Substring(archivePath.LastIndexOf(@".") + 1), archivePath);
        }

        public override void ExtractArchive(String archivePath, String destinationPath)
        {
            if (Validate(archivePath))
            {
                tempArgs = String.Format(this.argumentsExtract, destinationPath, archivePath);
                if (!String.IsNullOrEmpty(password))
                    tempArgs += String.Format(" -p\"{0}\"", password);
                CommandExecutor(tempArgs);
            }
        }
    }
}
