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

using ACLibrary.Crypto.MixCryptSeries;
using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MCrypt_GUI
{
    public partial class Main : Form
    {
        // int whichMethod;

        public Main()
        {
            InitializeComponent();
        }
        // e
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button5.Enabled = false;

            this.TopMost = false;
            EnterKey ek = new EnterKey();
            ek.ShowDialog();
            this.TopMost = tm.Checked;
            if (DataStore.exit)
            {
                return;
            }

            //Thread t = new Thread(new ThreadStart(doEncrypt));
            //t.Start();

            doEncrypt();

            result.Text = DataStore.finalResult;
            DataStore.Key = "";
            DataStore.finalResult = "";
            result.SelectAll();

            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
        }
        // d
        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button5.Enabled = false;

            this.TopMost = false;
            EnterKey ek = new EnterKey();
            ek.ShowDialog();
            this.TopMost = tm.Checked;
            if (DataStore.exit)
            {
                return;
            }

            //Thread t = new Thread(new ThreadStart(doDecrypt));
            //t.Start();

            doDecrypt();

            result.Text = DataStore.finalResult;
            DataStore.Key = "";
            DataStore.finalResult = "";
            result.SelectAll();

            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
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
            // this.Name = Int
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

        public void doEncrypt()
        {
            DataStore.finalResult = new Mid().EncryptString(input.Text, DataStore.Key);
        }

        public void doDecrypt()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(new Mid().DecryptString(input.Text, DataStore.Key));
            }
            catch (System.Security.Cryptography.CryptographicException ce)
            {
                MessageBox.Show("Password Wrong!", "Fail");
            }
            DataStore.finalResult = sb.ToString();
        }

        private void aesonly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void desonly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rc2only_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RijndaelOnly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MixCryptWeak_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MixCryptMid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MixCryptStronger_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MixCryptStrongest_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
