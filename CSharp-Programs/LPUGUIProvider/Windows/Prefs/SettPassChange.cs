﻿/*
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
using AC.LPU.GUI.Properties;
using System;
using System.Windows.Forms;

namespace AC.LPU.GUI.Windows.Prefs
{
    internal partial class SettPassChange : Form
    {
        public SettPassChange()
        {
            InitializeComponent();
        }

        private void c_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void o_Click(object sender, EventArgs e)
        {
            if (s.Text == "")
            {
                MessageBox.Show("不能为空！", "提示");
                return;
            }
            else
            {
                if ((Mid.Instance.DecryptString(Tools.getChangedResourceObject().armv7a, DataStorage.key)) == s.Text)
                {
                    MessageBox.Show("不能与密码根相同！", "提示");
                    return;
                }

                Settings.Default.settPass = s.Text;
                Settings.Default.Save();
                MessageBox.Show("保存成功！", "提示");
                Application.Exit();
            }
        }

        private void SettPassChange_Load(object sender, EventArgs e)
        {
            s.Text = Settings.Default.settPass;
        }
    }
}
