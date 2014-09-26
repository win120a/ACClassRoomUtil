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
            DayOfWeek dow = DateTime.Now.DayOfWeek;
            switch (dow.ToString())
            {
                case "Monday":
                    label1.Text = "今天星期一";
                    break;
                case "Tuesday":
                    label1.Text = "今天星期二";
                    break;
                case "Wednesday":
                    label1.Text = "今天星期三";
                    break;
                case "Thursday":
                    label1.Text = "今天星期四";
                    break;
                case "Friday":
                    label1.Text = "今天星期五";
                    break;
                case "Saturday":
                    label1.Text = "今天星期六";
                    break;
                case "Sunday":
                    label1.Text = "今天星期天";
                    break;
            }

            int num = 0;
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
                label2.Text = "为确保安全考虑，周六日密码修改已禁用。";
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
                    DayOfWeek dow = DateTime.Now.DayOfWeek;
                    switch (dow.ToString())
                    {
                        case "Monday":
                            num = 1;
                            break;
                        case "Tuesday":
                            num = 2;
                            break;
                        case "Wednesday":
                            num = 3;
                            break;
                        case "Thursday":
                            num = 4;
                            break;
                        case "Friday":
                            num = 5;
                            break;
                        case "Saturday":
                            num = 6;
                            break;
                        case "Sunday":
                            num = 7;
                            break;
                    }

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
        }
    }
}
