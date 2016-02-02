/*
   Copyright (C) 2011-2015 AC Inc. (Andy Cheung)

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
using LPU_Util;
using LPUGUIProvider.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    public sealed class Tools
    {
        /// <summary>
        /// Execute an operation with a number, it is replaced by Cases.ExecuteCases().
        /// </summary>
        /// <param name="operationID">The operation ID.</param>
        internal static void ExecuteOperationByID(int operationID)
        {
            switch (operationID)
            {
                case 1:
                    PowerTool.ShutdownSystem();
                    break;
                case 2:
                    PowerTool.RebootSystem();
                    break;
                case 3:
                    PowerTool.LogoffFromSystem();
                    break;
                case 0:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Generate key number after this day.
        /// </summary>
        /// <returns>The result.</returns>
        internal static int GenerateDateOfWeekNumber()
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
            // Old Code for backup.

            //Resources r = new Resources(); // Create new Resource Object.

            //if (!Settings.Default.customAllValue)
            //{
            //    if (Settings.Default.customRKCValueOnly || Settings.Default.customAllValue)
            //    {
            //        r.armv7a = Settings.Default.RKC;
            //    }

            //    r.netCmd = encryptedCmd;
            //}

            //string decryptedNCmd = new Mid().DecryptString(r.netCmd, DataStorage.key);
            //string commandCmd = " user \"" + Settings.Default.userName + "\" ";
            //string encryptedCmd = new Mid().EncryptString(commandCmd, DataStorage.key);

            //string decyptedRKC = new Mid().DecryptString(r.armv7a, DataStorage.key);
            //string currentDecryptedRKC = new Mid().DecryptString(Settings.Default.RKC, DataStorage.key);

            //if (Settings.Default.customAllValue)
            //{
            //    r.baseCmd = Settings.Default.BCMD;
            //    r.netCmd = Settings.Default.NCMD;
            //    r.armv7a = Settings.Default.RKC;
            //    r.tail = Settings.Default.Tail;
            //}

            //if (commandCmd != decryptedNCmd || decyptedRKC != currentDecryptedRKC)  // If username (RKC) is different from default.
            //{
            //    return r;  // Return changed object.
            //}
            //else
            //{
            //    return new Resources();   // Return new object.
            //}


            if (Settings.Default.customAllValue)  // If user defined a new database decryption password, 
            {
                Resources r = new Resources();
                r.baseCmd = Settings.Default.BCMD;
                r.netCmd = Settings.Default.NCMD;

                if (Settings.Default.customUsername)  // If user changed the username, the program have to apply it.
                {
                    string decryptedNCmd = new Mid().DecryptString(r.netCmd, DataStorage.key);  // Decrypt command.
                    string commandCmd = " user \"" + Settings.Default.userName + "\" ";  // Command with new username.
                    string encryptedCmd = new Mid().EncryptString(commandCmd, DataStorage.key); // Re-Encrypt the command.
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
                    string decryptedNCmd = new Mid().DecryptString(r.netCmd, DataStorage.key);
                    string commandCmd = " user \"" + Settings.Default.userName + "\" ";
                    string encryptedCmd = new Mid().EncryptString(commandCmd, DataStorage.key);
                    r.netCmd = encryptedCmd;
                }
                return r;
            }
            else if (Settings.Default.customUsername) // If user re-defined the username only, 
            {
                Resources r = new Resources();
                string decryptedNCmd = new Mid().DecryptString(r.netCmd, DataStorage.key);
                string commandCmd = " user \"" + Settings.Default.userName + "\" ";
                string encryptedCmd = new Mid().EncryptString(commandCmd, DataStorage.key);
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

        internal static void setIgnoreSPSWChange(bool value)
        {
            Settings.Default.ignoreSPSWChange = value;
            Settings.Default.Save();
        }

        public static bool getIgnoreSPSWChange()
        {
            if (Settings.Default.ignoreDate == null && Settings.Default.ignoreSPSWChange == false)
            {
                return false;
            }
            else if (Settings.Default.ignoreDate == DateTime.Now.Date)
            {
                return true;
            }
            else if (Settings.Default.ignoreDate < DateTime.Now.Date)
            {
                Settings.Default.ignoreDate = new DateTime(1);
                Settings.Default.ignoreSPSWChange = false;
                Settings.Default.Save();
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
