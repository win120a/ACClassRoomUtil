﻿/*
   Copyright (C) 2011-2015 AC Inc. (Andy Cheung)

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

using ACLibrary.Crypto.RandomKeyMixCrypt;
using System;
using System.Text;
using System.Windows.Forms;

namespace RMCrypt_GUI
{
    public partial class Main : Form
    {
        int whichMethod;

        public Main()
        {
            InitializeComponent();
        }

        private void SetAllButtonEnabled()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        // e
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            TopMost = false;
            EnterKey ek = new EnterKey();
            ek.ShowDialog();
            TopMost = tm.Checked;
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

            SetAllButtonEnabled();
        }
        // d
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            TopMost = false;
            EnterKey ek = new EnterKey();
            ek.ShowDialog();

            if (DataStore.exit)
            {
                SetAllButtonEnabled();
                return;
            }

            EnterRandomKey erk = new EnterRandomKey();
            erk.ShowDialog();
            if (DataStore.exit)
            {
                SetAllButtonEnabled();
                return;
            }

            TopMost = tm.Checked;

            //Thread t = new Thread(new ThreadStart(doDecrypt));
            //t.Start();

            doDecrypt();

            result.Text = DataStore.finalResult;
            DataStore.Key = "";
            DataStore.finalResult = "";
            result.SelectAll();

            SetAllButtonEnabled();
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
            TopMost = tm.Checked;
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
            IRandomKeyMixCryptBase engine = DetermineAndLoadEngine();
            ReturnStruct r = engine.EncryptString(input.Text, DataStore.Key);
            DataStore.finalResult = r.Result;

            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            int it = 0;

            foreach (int ti in r.RandomKeys)
            {
                sb.Append(ti);
                if (it != (r.RandomKeys.Length) - 1)
                {
                    sb.Append(",");
                }
                it++;
            }

            sb.Append("]");

            MessageBox.Show("请记好验证码，谢谢合作：\n\n" + sb.ToString(), "请注意");
        }

        public void doDecrypt()
        {
            IRandomKeyMixCryptBase engine = DetermineAndLoadEngine();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(engine.DecryptString(input.Text, DataStore.Key, DataStore.erkr));
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                MessageBox.Show("Password Wrong!", "Fail");
            }
            DataStore.finalResult = sb.ToString();
        }

        private void MixCryptWeak_CheckedChanged(object sender, EventArgs e)
        {
            whichMethod = 0;
        }

        private void MixCryptMid_CheckedChanged(object sender, EventArgs e)
        {
            whichMethod = 1;
        }

        private void MixCryptStronger_CheckedChanged(object sender, EventArgs e)
        {
            whichMethod = 2;
        }

        private void MixCryptStrongest_CheckedChanged(object sender, EventArgs e)
        {
            whichMethod = 3;
        }

        private IRandomKeyMixCryptBase DetermineAndLoadEngine()
        {
            IRandomKeyMixCryptBase ip = null;
            switch (whichMethod)
            {
                case 0:
                    ip = null;
                    break;
                case 1:
                    ip = new Mid();
                    break;
                case 2:
                    ip = null;
                    break;
                case 3:
                    ip = null;
                    break;
            }

            return ip;
        }

        private void test_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NumberConverter.Int2String(whichMethod));
        }
    }
}
