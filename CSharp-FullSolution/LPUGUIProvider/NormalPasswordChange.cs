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
using System.Text;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    public partial class NormalPasswordChange : Form
    {
        int switchVar = 0;

        public NormalPasswordChange()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // Cancel
        {
            Application.Exit();
        }

        private void NormalPasswordChange_Load(object sender, EventArgs e)
        {
            DayOfWeek dow = Tools.ReturnTodayInChinese(label1);

            int num = Tools.GenerateDateOfWeekNumber();

            switch (num)
            {
                case 2:
                    label2.Text = "程序将修改为星期二的密码";
                    break;
                case 3:
                    label2.Text = "程序将修改为星期三的密码";
                    break;
                case 4:
                    label2.Text = "程序将修改为星期四的密码";
                    break;
                case 5:
                    label2.Text = "程序将修改为星期五的密码";
                    break;
                case 6:
                    label2.Text = "程序将修改为星期六的密码";
                    break;
                case 7:
                    label2.Text = "程序将修改为星期天的密码";
                    break;
                case 1:
                    label2.Text = "程序将修改为星期一的密码";
                    break;
            }

            if (dow.Equals(DayOfWeek.Friday) || dow.Equals(DayOfWeek.Saturday))
            {
                label2.Text = "为安全考虑，在周六日修改密码已禁用。";
                textBox1.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (switchVar >= 3)
            {
                this.Hide();
                GC.Collect();
                new AnotherPasswordChangeMode().Show();
                this.Dispose();
            }
            if (textBox1.Text.Equals(""))
            {
                switchVar++;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Append(new MixCrypt().decrypt(new Resources().armv7a, DataStorage.key));
                }
                catch (System.Security.Cryptography.CryptographicException)
                {
                    MessageBox.Show("出现异常", "异常");
                    return;
                }

                if (textBox1.Text.Equals(new LPU_Crypt_API.MixCrypt().decrypt(new Resources().armv7a, DataStorage.key)))
                {
                    int num = 0;

                    num = Tools.GenerateDateOfWeekNumber();

                    //MessageBox.Show("Application is in debugging mode.\n" + 
                    //                "The key varable is: " + 
                    //                num, 
                    //                "Debbuging mode");

                    new PSWTool().ChangeSystemPassword(Environment.GetEnvironmentVariable("SystemRoot"),
                                                       DataStorage.key,
                                                       new Resources(),
                                                       num);

                    MessageBox.Show("执行完毕！", "完成");

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

        private void sdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GC.Collect();
            new DatePasswordChangeMode().Show();
            this.Dispose();
        }
    }
}
