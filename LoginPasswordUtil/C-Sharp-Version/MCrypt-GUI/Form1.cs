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

using LPU_Crypt_API;
using System;
using System.Text;
using System.Windows.Forms;

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
            this.TopMost = false;
            EnterKey ek = new EnterKey();
            ek.ShowDialog();
            this.TopMost = tm.Checked;
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
            this.TopMost = false;
            EnterKey ek = new EnterKey();
            ek.ShowDialog();
            this.TopMost = tm.Checked;
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

        private void button4_Click(object sender, EventArgs e)
        {
            input.Text = Clipboard.GetText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(result.Text);
        }
    }
}
