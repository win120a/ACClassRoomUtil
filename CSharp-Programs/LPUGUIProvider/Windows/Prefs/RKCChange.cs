/*
   Copyright (C) 2011-2016 AC Inc. (Andy Cheung)

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

using AC.LPU.GUI.Properties;
using AC.LPU.Res;
using ACLibrary.Crypto.MixCryptSeries;
using System;
using System.Windows.Forms;

namespace AC.LPU.GUI
{
    internal partial class RKCChange : Form
    {
        public RKCChange()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)  // OK Button Handler
        {
            if (o.Text == "" || n.Text == "" || c.Text == "")
            {
                MessageBox.Show("三者均不可空白！", "提示");
                return;
            }

            if (VerifyOldKey(o.Text))  // Verify old keys.
            {
                if (n.Text == Settings.Default.settPass)
                {
                    MessageBox.Show("不能与暗语相同！", "提示");
                    return;
                }

                if (n.Text == c.Text)  // Verify new keys and confirm.
                {
                    Settings.Default.RKC = Mid.Instance.EncryptString(n.Text, DataStorage.key);  // Encrypt and store.

                    Settings.Default.customRKCValueOnly = true; // Set flag.

                    Settings.Default.Save(); // Save it.

                    MessageBox.Show("保存成功！", "提示");

                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("确认密码与原密码不匹配", "提示");
                }
            }
            else
            {
                MessageBox.Show("原密码根错", "提示");
            }
        }

        /// <summary>
        /// Verify old key with the param value.
        /// </summary>
        /// <param name="verifyStr">Value of user type.</param>
        /// <returns>The result.</returns>
        private bool VerifyOldKey(string verifyStr)
        {
            bool flag = false;

            if (Settings.Default.customRKCValueOnly || Settings.Default.customAllValue)  // If set another RKC or Change DB decrypt pass, 
            {
                Mid engine = Mid.Instance;

                string orkc = engine.DecryptString(Settings.Default.RKC, DataStorage.key); // Decrypt it to verify.

                if (verifyStr == orkc) // Verify, 
                {
                    flag = true; // Set flag, 
                }
            }
            else  // Otherwise, 
            {
                Mid engine = Mid.Instance;

                string orkc = engine.DecryptString(new Resources().armv7a, DataStorage.key); // Decrypt, 

                if (verifyStr == orkc) // Verify, 
                {
                    flag = true; // Set flag, 
                }
            }

            return flag;  // Return flag.
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
