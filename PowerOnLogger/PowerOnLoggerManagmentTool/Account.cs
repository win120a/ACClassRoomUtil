using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerOnLoggerManagmentTool
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.User;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.User;
        }

        private void pc_Click(object sender, EventArgs e)
        {
            if (op.Text.Equals("") || np.Text.Equals("") || npc.Text.Equals(""))
            {
                MessageBox.Show("All fields CANNOT be empty!", "Fail");
                return;
            }

            if (op.Text.Equals(Properties.Settings.Default.Pass))
            {
                if (np.Text.Equals(npc.Text))
                {
                    Properties.Settings.Default.Pass = np.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Change Password Successful.\n Please Re-login.", "OK");
                    this.Hide();
                    new Verify().Show();
                }
                else
                {
                    MessageBox.Show("New Password and Confirm not Match!", "Fail");
                }
            }
            else
            {
                MessageBox.Show("Old Password Wrong!", "Fail");
            }
        }

        private void uc_Click(object sender, EventArgs e)
        {
            if (nu.Text.Equals("") || nuc.Text.Equals(""))
            {
                MessageBox.Show("All Fields CANNOT be empty!", "Fail");
                return;
            }
            if (nu.Text.Equals(nuc.Text))
            {
                Properties.Settings.Default.User = nu.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Change Username Successful.\n Please Re-login.", "OK");
                this.Hide();
                new Verify().Show();
            }
            else
            {
                MessageBox.Show("New Username and Confirm not Match!", "Fail");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main().Show();
        }
    }
}
