using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Archivizor_Project.Classes
{
    public class ServerConfig
    {
        public static String ServerAddress
        {
            get { return Archivizor_Project.Properties.Resources.ServerAddress; }
        }

        public static bool IsServerOnline
        {
            get
            {
                Uri url = new Uri(ServerAddress);
                string pingurl = string.Format("{0}", url.Host);
                string host = pingurl;
                bool result = false;
                Ping p = new Ping();
                try
                {
                    PingReply reply = p.Send(host, 3000);
                    if (reply.Status == IPStatus.Success)
                        return true;
                }
                catch { }
                return result;
            }
        }
    }
}
