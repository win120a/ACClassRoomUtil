﻿/*
   Copyright (C) 2011-2019 Andy Cheung

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

using AC.LPU.Res;
using ACLibrary.Crypto.MixCryptSeries;
using System;
using System.Windows.Forms;

namespace AC.LPU.GUI
{
    public partial class DecryptPass : Form
    {
        public DecryptPass()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Resources r = new Resources();

            if (Properties.Settings.Default.customAllValue)
            {
                r.netCmd = Properties.Settings.Default.NCMD;
            }

            try
            {
                Mid.Instance.DecryptString(r.netCmd, textBox1.Text);
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                Tools.HandleExceptions(ex);
                MessageBox.Show("密码错误", "异常");
                return;
            }

            DataStorage.key = textBox1.Text;
            Hide();
            new NormalPasswordChange().Show();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DecryptPass_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.isLock)
            {
                return;
            }

            DateTime savedDate = Properties.Settings.Default.dueDate;
            if (savedDate > DateTime.Now)
            {
                MessageBox.Show("程序现在被锁！", "已锁定");
                Application.Exit();
                return;
            }

            Properties.Settings.Default.isLock = false;
            Properties.Settings.Default.dueDate = new DateTime(1);
            Properties.Settings.Default.Save();
        }
    }
}
