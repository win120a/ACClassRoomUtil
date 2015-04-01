/*
   Copyright (C) 2011-2014 AC Inc. (Andy Cheung)

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
using System;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    public partial class DatePasswordChangeMode : Form
    {
        /// <summary>
        ///  The Constructor.
        /// </summary>
        public DatePasswordChangeMode()
        {
            InitializeComponent();
        }

        #region Handlers

        /// <summary>
        /// The OK button Event Handler.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Args.</param>
        private void ok_Click(object sender, EventArgs e)
        {
            // Check Key.
            if (!rkc.Text.Equals(new Mid().DecryptString(new Resources().armv7a, DataStorage.key))) // Decrypts key and check it.
            {
                MessageBox.Show("密码错误！", "异常");
                return;
            }

            #region Date Process zone
            Properties.Settings.Default.isLock = lockBox.Checked;  // Turn on (or not) lock switch.

            DateTime dt = DateTime.Parse(picker.Text); // Parse text to object.

            Properties.Settings.Default.dueDate = dt; // Save it.
            
            Properties.Settings.Default.Save(); // Save to settings zone.
            #endregion

            #region Parse day of week zone
            DayOfWeek dow = dt.DayOfWeek;  // Extract Day of week.
            int dow_int = 0;

            switch (dow) // Obj -> int
            {
                case DayOfWeek.Monday:
                    dow_int = 1;
                    break;
                case DayOfWeek.Tuesday:
                    dow_int = 2;
                    break;
                case DayOfWeek.Wednesday:
                    dow_int = 3;
                    break;
                case DayOfWeek.Thursday:
                    dow_int = 4;
                    break;
                case DayOfWeek.Friday:
                    dow_int = 5;
                    break;
                case DayOfWeek.Saturday:
                    dow_int = 6;
                    break;
                case DayOfWeek.Sunday:
                    dow_int = 7;
                    break;
                default:
                    throw new SystemException();
            }
            #endregion

            #region Change PSW and after process zone
            new PSWTool().ChangeSystemPassword(Environment.GetEnvironmentVariable("SystemRoot"),
                                               DataStorage.key,
                                               new Resources(),
                                               dow_int); // Change psw.

            Cases.ExecuteCases();

            Application.Exit();
            #endregion
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
