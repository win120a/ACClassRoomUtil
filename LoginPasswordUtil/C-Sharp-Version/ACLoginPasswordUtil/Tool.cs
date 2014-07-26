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

        public class PSWTool
        {
            public StringBuilder ConstructCommandText(String sysPath, Resources resClass)
            {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.Append(sysPath);
                sBuilder.Append("\\System32\\");
                sBuilder.Append(resClass.baseCmd);
                return sBuilder;
            }

            public StringBuilder ConstructArgText(StringBuilder sBuilder, Resources resClass, int pswInt)
            {
                sBuilder.Clear();
                sBuilder.Append(resClass.netCmd);  // arg1 " user ..."
                sBuilder.Append(resClass.armv7a); // KeyChar
                sBuilder.Append(pswInt); // Int
                return sBuilder;
            }

            public int DecryptUserInput(String[] originalArgs)
            {
                int first = Int32.Parse(originalArgs[0]);
                int second = Int32.Parse(originalArgs[1]);
                int result = first + second;
                return result;
            }
        }
    }
}
