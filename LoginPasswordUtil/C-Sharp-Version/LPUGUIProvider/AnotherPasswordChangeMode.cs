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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            num = 6;
            button1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            num = 7;
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            num = 1;
            button1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ok_Click(object sender, EventArgs e)
        {
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
    }
}
