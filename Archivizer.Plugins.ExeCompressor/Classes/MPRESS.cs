using System;
using System.Collections.Generic;
using System.Text;

namespace ExeCompressor.Classes
{
    public class MPRESS : AbstractCompressor, ICompress
    {
        public MPRESS(String programPath)
            : base(programPath)
        {
            this.patternArguments = "\"{0}\" -b";
        }

        public override void Compress(String filePath)
        {
            CommandExecutor(String.Format(this.patternArguments, filePath));
        }
    }
}
