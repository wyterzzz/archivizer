using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Archivizor_Project.Classes.Algorithms.Compressing
{
    public class ARC : AbstractAlgorithm, IArchive
    {
        public ARC(String programPath)
            : base(programPath)
        {
            this.argumentsArchive = "a -m4 -s -rr -ae=aes \"{0}\" {1}";
            this.argumentsExtract = "x -o- \"{0}\" -dp\"{1}\"";
        }

        public override void GenerateArchive(String archivePath)
        {
            if (this.items.Length > 0)
            {
                CommandExecutor(String.Format(this.argumentsArchive, archivePath, this.items.ToString()));
            }
        }

        public override void ExtractArchive(String archivePath, String destinationPath)
        {
            if (Validate(archivePath))
            {
                CommandExecutor(String.Format(this.argumentsExtract, archivePath, destinationPath));
            }
        }
    }
}
