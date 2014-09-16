using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPU_Crypt_API;

namespace MCrypt_GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        // e
        private void button1_Click(object sender, EventArgs e)
        {
            EnterKey ek = new EnterKey();
            ek.ShowDialog();
            if (DataStore.exit)
            {
                return;
            }
            string s = new MixCrypt().encrypt(input.Text, DataStore.Key);
            result.Text = s;
            DataStore.Key = "";
            result.SelectAll();
        }
        // d
        private void button2_Click(object sender, EventArgs e)
        {
            EnterKey ek = new EnterKey();
            ek.ShowDialog();
            if (DataStore.exit)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(new MixCrypt().decrypt(input.Text, DataStore.Key));
            }
            catch (System.Security.Cryptography.CryptographicException ce)
            {
                MessageBox.Show("Password Wrong!", "Fail");
            }
            result.Text = sb.ToString();
            DataStore.Key = "";
            result.SelectAll();
        }
        // c
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            input.Text = "";
            result.Text = "";
            input.Focus();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            input.Focus();
        }

        private void tm_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = tm.Checked;
        }
    }
}
