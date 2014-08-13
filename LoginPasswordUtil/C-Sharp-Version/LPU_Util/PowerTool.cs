using System;
using System.Diagnostics;

namespace LPU_Util
{
    public class PowerTool
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
