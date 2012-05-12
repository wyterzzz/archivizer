using System;

class OSCheck
{
    public static String getOSInfo()
    {
        //Get Operating system information.
        OperatingSystem os = Environment.OSVersion;
        //Get version information about the os.
        Version vs = os.Version;

        //Variable to hold our return value
        String operatingSystem = "";

        if (os.Platform == PlatformID.Win32Windows)
        {
            //This is a pre-NT version of Windows
            switch (vs.Minor)
            {
                case 0:
                    operatingSystem = "95";
                    break;
                case 10:
                    if (vs.Revision.ToString() == "2222A")
                        operatingSystem = "98SE";
                    else
                        operatingSystem = "98";
                    break;
                case 90:
                    operatingSystem = "Me";
                    break;
                default:
                    break;
            }
        }
        else if (os.Platform == PlatformID.Win32NT)
        {
            switch (vs.Major)
            {
                case 3:
                    operatingSystem = "NT 3.51";
                    break;
                case 4:
                    operatingSystem = "NT 4.0";
                    break;
                case 5:
                    if (vs.Minor == 0)
                        operatingSystem = "2000";
                    else
                        operatingSystem = "XP";
                    break;
                case 6:
                    if (vs.Minor == 0)
                        operatingSystem = "Vista";
                    else
                        operatingSystem = "7";
                    break;
                default:
                    break;
            }
        }
        
        //Return the information we've gathered.
        return operatingSystem;
    }
}

