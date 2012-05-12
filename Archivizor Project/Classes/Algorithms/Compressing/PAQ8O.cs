using System;
using System.Collections.Generic;
using System.Text;

namespace Archivizor_Project.Classes.Algorithms.Compressing
{
    public class PAQ8O : AbstractAlgorithm, IArchive
    {
        public PAQ8O(String programPath)
            : base(programPath)
        {
            this.compressionLevel = "5";
            this.argumentsArchive = "-{0} {1}";
            this.argumentsExtract = "-d \"{0}\" \"{1}\"";
        }

        public override void GenerateArchive(String archivePath)
        {
            if (this.items.Length > 0)
            {
                CommandExecutor(String.Format(this.argumentsArchive, Convert.ToInt32(this.compressionLevel), this.items.ToString()));
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
