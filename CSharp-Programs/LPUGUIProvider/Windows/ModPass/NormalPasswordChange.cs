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
using System;
using System.Text;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    public partial class NormalPasswordChange : Form
    {
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

            int num = Tools.GetNextDateOfWeekNumber();

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
                label2.Text = "为安全考虑，不允许修改为节假日密码。";
                label3.Visible = false;
                textBox1.Visible = false;
                button1.Enabled = false;
                System.Drawing.Size s = Size;
                s.Height = 150;
                Size = s;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(Mid.Instance.DecryptString(Tools.getChangedResourceObject().armv7a, DataStorage.key));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                Tools.HandleExceptions(ex);
                MessageBox.Show("出现异常，详见日志文件", "异常");
                return;
            }

            if (textBox1.Text.Equals(Mid.Instance.DecryptString(Tools.getChangedResourceObject().armv7a, DataStorage.key)))
            {
                int num = 0;

                num = Tools.GetNextDateOfWeekNumber();

                //MessageBox.Show("Application is in debugging mode.\n" + 
                //                "The key varable is: " + 
                //                num, 
                //                "Debbuging mode");

                PSWTool.ChangeSystemPassword(DataStorage.key,
                                             Tools.getChangedResourceObject(),
                                             num);

                MessageBox.Show("执行完毕！", "完成");

                Tools.ExecuteCaseByID();

                Application.Exit();
            }
            else
            {
                MessageBox.Show("密码错误", "异常");
                return;
            }
        }

        private void sdate_Click(object sender, EventArgs e)
        {
            Hide();
            GC.Collect();
            new DatePasswordChangeMode().Show();
            Dispose();
        }

        private void week_Click(object sender, EventArgs e)
        {
            Hide();
            GC.Collect();
            new DayOfWeekPasswordChangeMode().Show();
            Dispose();
        }
    }
}
