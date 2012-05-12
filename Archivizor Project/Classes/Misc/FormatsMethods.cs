using System;
using System.Collections.Generic;
using System.Text;

namespace Archivizor_Project.Classes.Misc
{
    public static class FormatsMethods
    {
        public static String GetName(string filePath)
        {
            foreach (OutputFormats format in Enum.GetValues(typeof(OutputFormats)))
            {
                String tempExtensionValue = EnumUtilities.stringValueOf(format);
                if (filePath.EndsWith(tempExtensionValue))
                    return filePath.Remove(filePath.Length - tempExtensionValue.Length);
            }
            return null;
        }

        public static String GetFormat(string filePath)
        {
            foreach (OutputFormats format in Enum.GetValues(typeof(OutputFormats)))
            {
                String tempExtensionValue = EnumUtilities.stringValueOf(format);
                if (filePath.EndsWith(tempExtensionValue))
                    return tempExtensionValue;
            }
            return null;
        }
    }
}
