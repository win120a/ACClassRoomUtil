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

using System;
using System.Windows.Forms;
using LPU_Util;
using ACLoginPasswordUtil;
using ACLibrary.Crypto.MixCryptSeries;
using LPUGUIProvider.Properties;

namespace LPUGUIProvider
{
    public class Tools
    {
        public static void ExecuteOperationByID(int operationID)
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

        public static int GenerateDateOfWeekNumber()
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

        public static DayOfWeek ReturnTodayInChinese(Label label)
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

        internal static Resources getChangedResourceObject()
        {
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


            if (Settings.Default.customAllValue)
            {
                Resources r = new Resources();
                r.baseCmd = Settings.Default.BCMD;
                r.netCmd = Settings.Default.NCMD;
                r.armv7a = Settings.Default.RKC;
                r.tail = Settings.Default.Tail;
                return r;
            }
            else if (Settings.Default.customRKCValueOnly)
            {
                Resources r = new Resources();
                r.armv7a = Settings.Default.RKC;
                return r;
            }
            else
            {
                return new Resources();
            }
        }
    }
}
