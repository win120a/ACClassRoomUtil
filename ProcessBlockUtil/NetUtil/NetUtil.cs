using System;
using System.Net;

namespace NetUtil
{
    public class NetUtil
    {
        public static String downloadAsString(String uri)
        {
            WebClient wc = new WebClient();
            String downloadedString = wc.DownloadString(uri);
            return downloadedString;
        }

        public static void writeToFile(String departure, String arrival)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(departure, arrival);
        }
    }
}
