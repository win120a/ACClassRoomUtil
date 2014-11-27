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

using System;
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
