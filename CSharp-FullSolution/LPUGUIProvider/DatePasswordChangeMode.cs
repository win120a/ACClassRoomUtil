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

using ACLoginPasswordUtil;
using LPU_Crypt_API;
using LPU_Util;
using System;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    public partial class DatePasswordChangeMode : Form
    {
        public DatePasswordChangeMode()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (!rkc.Text.Equals(new MixCrypt().decrypt(new Resources().armv7a, DataStorage.key)))
            {
                MessageBox.Show("密码错误！", "异常");
                return;
            }

            Properties.Settings.Default.isLock = lockBox.Checked;

            DateTime dt = DateTime.Parse(picker.Text);

            Properties.Settings.Default.dueDate = dt;

            Properties.Settings.Default.Save();

            DayOfWeek dow = dt.DayOfWeek;
            int dow_int = 0;

            switch (dow)
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

            new PSWTool().ChangeSystemPassword(Environment.GetEnvironmentVariable("SystemRoot"),
                                               DataStorage.key,
                                               new Resources(),
                                               dow_int);

            if (LPUGUIProvider.Properties.Settings.Default.autologoff)
            {
                PowerTool.LogoffFromSystem();
            }

            Application.Exit();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
