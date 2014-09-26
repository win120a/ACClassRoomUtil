using System;
using System.Windows.Forms;
using LPU_Crypt_API;
using ACLoginPasswordUtil;

namespace LPUGUIProvider
{
    public partial class DecryptPass : Form
    {
        public DecryptPass()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                new MixCrypt().decrypt(new Resources().baseCmd, textBox1.Text);
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                MessageBox.Show("密码错误", "异常");
                return;
            }

            DataStorage.key = textBox1.Text;
            this.Hide();
            new NormalPasswordChange().Show();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
