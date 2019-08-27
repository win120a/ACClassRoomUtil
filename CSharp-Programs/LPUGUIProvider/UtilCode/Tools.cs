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
using AC.LPU.Res;
using AC.LPU.Util;
using AC.LPU.GUI.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace AC.LPU.GUI
{
    public sealed class Tools
    {
        private Tools() { }

        /// <summary>
        /// Generate key number after this day.
        /// </summary>
        /// <returns>The result.</returns>
        internal static int GetNextDateOfWeekNumber()
        {
            int num = 0;
            DayOfWeek dow = DateTime.Now.DayOfWeek;
            switch (dow.ToString())
            {
                case "Monday":
                    num = 2;
                    break;
                case "Tuesday":
                    num = 3;
                    break;
                case "Wednesday":
                    num = 4;
                    break;
                case "Thursday":
                    num = 5;
                    break;
                case "Friday":
                    num = 6;
                    break;
                case "Saturday":
                    num = 7;
                    break;
                case "Sunday":
                    num = 1;
                    break;
            }

            return num;
        }

        /// <summary>
        /// For UI use only.
        /// </summary>
        /// <param name="label">The label object in UI.</param>
        /// <returns>A DayOfWeek object of today.</returns>
        internal static DayOfWeek ReturnTodayInChinese(Label label)
        {
            DayOfWeek dow = DateTime.Now.DayOfWeek;
            switch (dow.ToString())
            {
                case "Monday":
                    label.Text = "今天星期一";
                    break;
                case "Tuesday":
                    label.Text = "今天星期二";
                    break;
                case "Wednesday":
                    label.Text = "今天星期三";
                    break;
                case "Thursday":
                    label.Text = "今天星期四";
                    break;
                case "Friday":
                    label.Text = "今天星期五";
                    break;
                case "Saturday":
                    label.Text = "今天星期六";
                    break;
                case "Sunday":
                    label.Text = "今天星期天";
                    break;
            }

            return dow;
        }

        /// <summary>
        /// Supports all user-define function.
        /// </summary>
        /// <returns>The user-defined database.</returns>
        public static Resources getChangedResourceObject()
        {
            if (Settings.Default.customAllValue)  // If user defined a new database decryption password, 
            {
                Resources r = new Resources();
                r.netCmd = Settings.Default.NCMD;

                if (Settings.Default.customUsername)  // If user changed the username, the program have to apply it.
                {
                    string decryptedNCmd = Mid.Instance.DecryptString(r.netCmd, DataStorage.key);  // Decrypt command.
                    string commandCmd = " user \"" + Settings.Default.userName + "\" ";  // Command with new username.
                    string encryptedCmd = Mid.Instance.EncryptString(commandCmd, DataStorage.key); // Re-Encrypt the command.
                    r.netCmd = encryptedCmd; // Apply it.
                }

                r.armv7a = Settings.Default.RKC;
                r.tail = Settings.Default.Tail; // Apply new database.
                return r;
            }
            else if (Settings.Default.customRKCValueOnly) // If user re-defined new RKC, 
            {
                Resources r = new Resources();
                r.armv7a = Settings.Default.RKC;  // Apply it.
                if (Settings.Default.customUsername) // There are the same process as before.
                {
                    string decryptedNCmd = Mid.Instance.DecryptString(r.netCmd, DataStorage.key);
                    string commandCmd = " user \"" + Settings.Default.userName + "\" ";
                    string encryptedCmd = Mid.Instance.EncryptString(commandCmd, DataStorage.key);
                    r.netCmd = encryptedCmd;
                }
                return r;
            }
            else if (Settings.Default.customUsername) // If user re-defined the username only, 
            {
                Resources r = new Resources();
                string decryptedNCmd = Mid.Instance.DecryptString(r.netCmd, DataStorage.key);
                string commandCmd = " user \"" + Settings.Default.userName + "\" ";
                string encryptedCmd = Mid.Instance.EncryptString(commandCmd, DataStorage.key);
                r.netCmd = encryptedCmd;  // Apply it.
                return r;
            }
            else
            {
                return new Resources();   // If user has not used the define function, return a default database.
            }
        }

        internal static void HandleExceptions(Exception ex)
        {
            //String fileName = Environment.GetEnvironmentVariable("SystemDrive") + "\\lpulog-" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".txt";
            string fileName = Environment.GetEnvironmentVariable("Temp") + "\\lpulog-" + Path.GetRandomFileName() + ".txt";

            FileStream fs = File.Create(fileName);
            fs.Close();

            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine("MESS: " + ex.Message);
            sw.WriteLine();
            sw.WriteLine("SOURCE: " + ex.Source);
            sw.WriteLine();
            sw.WriteLine("ST: " + ex.StackTrace);
            sw.WriteLine();
            sw.WriteLine("TargetSite: " + ex.TargetSite);
            sw.WriteLine();
            sw.WriteLine("ToString: " + ex.ToString());

            sw.Flush();
            sw.Close();
        }

        public static bool GetIgnoreSPSWChange()
        {
            if (!Settings.Default.ignoreSPSWChange)     // If the flag is false, clear the ignore date and return false.
            {
                Settings.Default.ignoreDate = new DateTime(1);
                Settings.Default.Save();
                return false;
            }
            if (Settings.Default.ignoreDate == new DateTime(1) && Settings.Default.ignoreSPSWChange == false)
            {
                return false;
            }
            else if (Settings.Default.ignoreDate == DateTime.Now.Date)   // Gather the date, and compare with the saved date.
            {
                return true;   // If equals, true.
            }
            else if (Settings.Default.ignoreDate < DateTime.Now.Date)      // If date passed, clear the date and flag.
            {
                Settings.Default.ignoreDate = new DateTime(1);
                Settings.Default.ignoreSPSWChange = false;
                Settings.Default.Save();
                return false;
            }
            else   // Other unexpected situation
            {
                return false;
            }
        }

        public static void ExecuteCaseByID()
        {
            switch (Settings.Default.operateID)
            {
                case 0:
                    return;
                case 1:
                    PowerTool.ShutdownSystem();
                    break;
                case 2:
                    PowerTool.RebootSystem();
                    break;
                case 3:
                    PowerTool.LogoffFromSystem();
                    break;
            }
        }
    }
}
