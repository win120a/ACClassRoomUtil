/*
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
using LPU_Util;
using LPUGUIProvider;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace LPU_GUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length >= 2)
            {
                if (args[0] == "/q" && !(Tools.GetIgnoreSPSWChange()))
                {
                    string usrPass = args[1];
                    DataStorage.key = args[1];

                    try
                    {
                        Mid.Instance.DecryptString(Tools.getChangedResourceObject().baseCmd, usrPass);
                    }
                    catch (CryptographicException)
                    {
                        MessageBox.Show("The system can't continue because the password is incorrect.", "Error.");
                        return;
                    }

                    if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                    {
                        PSWTool.ChangeSystemPassword(usrPass, Tools.getChangedResourceObject(), 1);  // Change the password to Monday's
                        return;
                    }
                    else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                    {
                        return;   // Don't work in Saturday or Sunday.
                    }
                    else
                    {
                        PSWTool.ChangeSystemPassword(usrPass, Tools.getChangedResourceObject(), ((int)DateTime.Now.DayOfWeek) + 1);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("The program can't run in this mode because the mode has been blocked by Administrator.", "Error");
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DecryptPass());
        }
    }
}
