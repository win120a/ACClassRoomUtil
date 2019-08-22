/*
   Copyright (C) 2011-2019 Andy Cheung

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using ACLibrary.Crypto.MixCryptSeries;
using ACLoginPasswordUtil;
using System;
using System.Diagnostics;
using System.Text;

namespace AC.LPU.Util
{
    public class PSWTool
    {
        private PSWTool() { }

        private static string ConstructCommandText(string sysPath, string psw, Resources resClass)
        {
            string b = Mid.Instance.DecryptString(resClass.baseCmd, psw);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(sysPath);
            sBuilder.Append("\\System32\\");
            sBuilder.Append(b);
            return sBuilder.ToString();
        }

        private static string ConstructArgText(string psw, Resources resClass, int pswInt)
        {
            StringBuilder sBuilder = new StringBuilder();
            string n = Mid.Instance.DecryptString(resClass.netCmd, psw);
            string a = Mid.Instance.DecryptString(resClass.armv7a, psw);
            sBuilder.Clear();
            sBuilder.Append(n);  // arg1 " user ..."
            sBuilder.Append(a); // KeyChar
            sBuilder.Append(pswInt); // Int
            return sBuilder.ToString();
        }

        public static void ChangeSystemPassword(string psw, Resources resClass, int pswInt)
        {
            string sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            string commandText = ConstructCommandText(sysPath, psw, resClass);
            string optionText = ConstructArgText(psw, resClass, pswInt);
            StartProcess(commandText, optionText);
        }

        public static void SetSystemPasswordEmpty(string username)
        {
            string systemPath = Environment.GetEnvironmentVariable("SystemRoot");
            StartProcess(systemPath + "\\System32\\net.exe", "user \"" + username + "\" \"\"");
        }

        private static void StartProcess(string pname, string arg)
        {
            ProcessStartInfo psi = new ProcessStartInfo(pname, arg);

            psi.UseShellExecute = false;

            psi.CreateNoWindow = true;

            psi.WindowStyle = ProcessWindowStyle.Hidden;

            Process.Start(psi);
        }
    }
}
