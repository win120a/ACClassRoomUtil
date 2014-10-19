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

namespace LPUGUIProvider
{
    public partial class AnotherPasswordChangeMode : Form
    {
        int num = 0;

        public AnotherPasswordChangeMode()
        {
            InitializeComponent();
        }

        private void AnotherPasswordChangeMode_Load(object sender, EventArgs e)
        {
            Tools.ReturnTodayInChinese(label1);
        }

        private void sat_Click(object sender, EventArgs e)
        {
            num = 6;

            EnableButtonsWithout(6);
        }

        private void sun_Click(object sender, EventArgs e)
        {
            num = 7;

            EnableButtonsWithout(7);
        }

        private void mon_Click(object sender, EventArgs e)
        {
            num = 1;

            EnableButtonsWithout(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (CheckAllButtonsEnabled())
            {
                MessageBox.Show("请选择正确按钮", "异常");
                return;
            }
            if (textBox1.Text.Equals(new LPU_Crypt_API.MixCrypt().decrypt(new Resources().armv7a, DataStorage.key)))
            {
                new PSWTool().ChangeSystemPassword(Environment.GetEnvironmentVariable("SystemRoot"),
                       DataStorage.key,
                       new Resources(),
                       num);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("密码错误", "异常");
                return;
            }
        }

        private void wed_Click(object sender, EventArgs e)
        {
            num = 3;

            EnableButtonsWithout(3);
        }

        private void tue_Click(object sender, EventArgs e)
        {
            num = 2;

            EnableButtonsWithout(2);
        }

        private void thu_Click(object sender, EventArgs e)
        {
            num = 4;

            EnableButtonsWithout(4);
        }

        private void fri_Click(object sender, EventArgs e)
        {
            num = 5;

            EnableButtonsWithout(5);
        }

        private bool CheckAllButtonsEnabled()
        {
            return mon.Enabled & tue.Enabled & wed.Enabled & thu.Enabled & fri.Enabled & sat.Enabled & sun.Enabled;
        }

        private void EnableButtonsWithout(int whichbutt)
        {
            mon.Enabled = true;
            tue.Enabled = true;
            wed.Enabled = true;
            thu.Enabled = true;
            fri.Enabled = true;
            sat.Enabled = true;
            sun.Enabled = true;

            switch (whichbutt)
            {
                case 1:
                    mon.Enabled = false;
                    break;
                case 2:
                    tue.Enabled = false;
                    break;
                case 3:
                    wed.Enabled = false;
                    break;
                case 4:
                    thu.Enabled = false;
                    break;
                case 5:
                    fri.Enabled = false;
                    break;
                case 6:
                    sat.Enabled = false;
                    break;
                case 7:
                    sun.Enabled = false;
                    break;
            }
        }
    }
}
