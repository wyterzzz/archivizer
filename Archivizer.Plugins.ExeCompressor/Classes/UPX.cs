using System;
using System.Collections.Generic;
using System.Text;

namespace ExeCompressor.Classes
{
    public class UPX : AbstractCompressor, ICompress
    {
        public UPX(String programPath)
            : base(programPath)
        {
            this.patternArguments = "--best --compress-icons=0 --nrv2d --crp-ms=999999 -k \"{0}\"";
        }

        public override void Compress(String filePath)
        {
            CommandExecutor(String.Format(this.patternArguments, filePath));   
        }
    }
}
