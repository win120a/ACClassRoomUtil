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
using LPU_Util;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ACLibrary.Crypto.MixCryptSeries;

namespace LPUGUIProvider
{
    public partial class DayOfWeekPasswordChangeMode : Form
    {
        Dictionary<string, int> SelectBoxData = new Dictionary<string,int>();
        int num = 0;
        int s = 0;

        public DayOfWeekPasswordChangeMode()
        {
            InitializeComponent();
        }

        private void AnotherPasswordChangeMode_Load(object sender, EventArgs e)
        {
            SelectBoxData.Add("Monday", 1);
            SelectBoxData.Add("Tuesday", 2);
            SelectBoxData.Add("Wednesday", 3);
            SelectBoxData.Add("Thursday", 4);
            SelectBoxData.Add("Friday", 5);
            SelectBoxData.Add("Saturday", 6);
            SelectBoxData.Add("Sunday", 7);

            Dictionary<string, int>.KeyCollection boxText = SelectBoxData.Keys;

            foreach (string s in boxText)
            {
                sBox.Items.Add(s);
            }

            // SelectBoxData.Keys

            Tools.ReturnTodayInChinese(label1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OK2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("sett"))
            {
                if (s >= 3)
                {
                    this.Hide();
                    new Prefs().Show();
                }
                s++;
                return;
            }
            if (sBox.Text == "")
            {
                MessageBox.Show("请选择星期几！", "异常");
                return;
            }
            if (textBox1.Text.Equals(new Mid().DecryptString(new Resources().armv7a, DataStorage.key)))
            {
                Dictionary<string, int>.KeyCollection textCollection = SelectBoxData.Keys;
                Dictionary<string, int>.ValueCollection numCollection = SelectBoxData.Values;
                int num = 0;

                foreach (int n in numCollection)
                {
                    if (SelectBoxData[sBox.Text] == n)
                    {
                        num = n;
                        break;
                    }
                }

                //MessageBox.Show("You selected " + num + ".");

                new PSWTool().ChangeSystemPassword(Environment.GetEnvironmentVariable("SystemRoot"),
                       DataStorage.key,
                       new Resources(),
                       num);

                if (LPUGUIProvider.Properties.Settings.Default.autologoff)
                {
                    PowerTool.LogoffFromSystem();
                }

                Application.Exit();
            }
            else
            {
                MessageBox.Show("密码错误", "异常");
                return;
            }
        }
    }
}
