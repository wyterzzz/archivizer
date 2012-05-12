using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;

namespace Archivizor_Project.Classes.Misc
{
    public enum OutputFormats
    {
        [DescriptionAttribute(".7z")]
        SevenZip,
        [DescriptionAttribute(".zip")]
        Zip,
        [DescriptionAttribute(".tar")]
        Tar,
        [DescriptionAttribute(".wim")]
        WIM,
        [DescriptionAttribute(".paq8o")]
        PAQ8O,
        [DescriptionAttribute(".arc")]
        ARC,
        [DescriptionAttribute(".exe")]
        SFX7z
    }
}
