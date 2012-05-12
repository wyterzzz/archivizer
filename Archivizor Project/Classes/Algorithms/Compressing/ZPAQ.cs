using System;
using System.Collections.Generic;
using System.Text;

namespace Archivizor_Project.Classes.Algorithms.Compressing
{
    public class ZPAQ : AbstractAlgorithm, IArchive
    {
        public ZPAQ(String programPath)
            : base(programPath)
        {
            this.compressionLevel = "mid.cfg";
            this.argumentsArchive = "a\"{0}\" \"{1}\" {2}";
            this.argumentsExtract = "x \"{0}\"";
        }

        public override void GenerateArchive(String archivePath)
        {
            if (this.items.Length > 0)
            {
                CommandExecutor(String.Format(this.argumentsArchive, this.programPath.Substring(0, this.programPath.LastIndexOf(@"\") + 1) + this.compressionLevel, archivePath, this.items.ToString()));
            }
        }

        public override void ExtractArchive(String archivePath, String destinationPath)
        {
            if (Validate(archivePath))
            {
                CommandExecutor(String.Format(this.argumentsExtract, archivePath));
            }
        }
    }
}
