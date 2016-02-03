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

using ACLibrary.Crypto.MixCryptSeries;
using ACLoginPasswordUtil;
using LPUGUIProvider.Properties;
using System;
using System.Windows.Forms;

namespace LPUGUIProvider.Windows.Prefs
{
    internal partial class DBDPChange : Form
    {
        public DBDPChange()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (o.Text == "" || n.Text == "" || c.Text == "")
            {
                MessageBox.Show("三者均不可空白！", "提示");
                return;
            }

            if (o.Text == DataStorage.key)
            {
                if (n.Text == c.Text)
                {
                    CreateNewEncryptedDatabase();
                    MessageBox.Show("建立新数据库成功！", "提示");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("确认密码和新密码不匹配", "提示");
                }
            }
            else
            {
                MessageBox.Show("原密码错", "提示");
            }
        }

        private void CreateNewEncryptedDatabase()
        {
            Mid engine = new Mid();
            Resources rClass = Tools.getChangedResourceObject();

            // Decrypt old database.
            string bCmd = engine.DecryptString(rClass.baseCmd, DataStorage.key);
            string nCmd = engine.DecryptString(rClass.netCmd, DataStorage.key);
            string rkc = engine.DecryptString(rClass.armv7a, DataStorage.key);
            string tail = engine.DecryptString(rClass.tail, DataStorage.key);

            // Create new database.
            string ebCmd = engine.EncryptString(bCmd, n.Text);
            string enCmd = engine.EncryptString(nCmd, n.Text);
            string erkc = engine.EncryptString(rkc, n.Text);
            string etail = engine.EncryptString(tail, n.Text);

            // Save it.
            Settings settI = Settings.Default;
            settI.BCMD = ebCmd;
            settI.NCMD = enCmd;
            settI.RKC = erkc;
            settI.Tail = etail;
            settI.customAllValue = true;
            settI.customRKCValueOnly = false;
            settI.Save();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
