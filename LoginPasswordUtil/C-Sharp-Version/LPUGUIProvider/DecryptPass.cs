﻿/*
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

using ACLoginPasswordUtil;
using LPU_Crypt_API;
using System;
using System.Windows.Forms;

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