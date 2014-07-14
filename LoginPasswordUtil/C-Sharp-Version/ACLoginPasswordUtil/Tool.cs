using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ACLoginPasswordUtil
{
    class Tool
    {
        public static void ShutdownSystem()
        {
            String sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            Process.Start(sysPath + "\\System32\\shutdown.exe", "-s -t 0");
        }

        public static void RebootSystem()
        {
            String sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            Process.Start(sysPath + "\\System32\\shutdown.exe", "-r -t 0");
        }

        public static void LogoffFromSystem()
        {
            String sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            Process.Start(sysPath + "\\System32\\logoff.exe");
        }
    }
}
