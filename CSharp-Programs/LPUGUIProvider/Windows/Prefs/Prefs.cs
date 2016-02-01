/*
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

using ACLibrary.Collection;
using LPU_Util;
using LPUGUIProvider.Properties;
using LPUGUIProvider.Windows.Prefs;
using System;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    internal partial class Prefs : Form
    {
        ACDictionary<string, int> SelectBoxData = new ACDictionary<string, int>();

        public Prefs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ok
        {
            Settings.Default.operateID = SelectBoxData[comboBox1.Text];
            Settings.Default.userName = userName.Text;
            
            if (userName.Text == "Administrator")
            {
                Settings.Default.customUsername = false;
            }
            else
            {
                Settings.Default.customUsername = true;
            }

            Settings.Default.Save();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) // cancel
        {
            Application.Exit();
        }

        private void Prefs_Load(object sender, EventArgs e)
        {
            SelectBoxData.Add("不操作", 0);
            SelectBoxData.Add("关  机", 1);
            SelectBoxData.Add("重  启", 2);
            SelectBoxData.Add("注  销", 3);

            // comboBox1.Text = SelectBoxData.GetKeyByValue(Settings.Default.operateID);

            foreach (string s in SelectBoxData.KeyList())
            {
                comboBox1.Items.Add(s);
            }

            comboBox1.Text = SelectBoxData.GetKeyByValue(Settings.Default.operateID);
            userName.Text = Settings.Default.userName;

            if (Settings.Default.ignoreSPSWChange)
            {
                ignoreSPC.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            LargeOperationVerify vw = new LargeOperationVerify();
            vw.ShowDialog();
            MessageBox.Show(vw.Verifed ? "通过" : "未通过", "结果");

            if (vw.Verifed)
            {
                this.Hide();
                new RKCChange().Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            LargeOperationVerify vw = new LargeOperationVerify();
            vw.ShowDialog();
            MessageBox.Show(vw.Verifed ? "通过" : "未通过", "结果");

            if (vw.Verifed)
            {
                DialogResult result = MessageBox.Show("您确定要将用户" + Settings.Default.userName + "的密码消除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    new PSWTool().SetSystemPasswordEmpty(Settings.Default.userName);
                }
            }
        }

        private void dbdpc_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            LargeOperationVerify vw = new LargeOperationVerify();
            vw.ShowDialog();
            MessageBox.Show(vw.Verifed ? "通过" : "未通过", "结果");

            if (vw.Verifed)
            {
                this.Hide();
                new DBDPChange().Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            LargeOperationVerify vw = new LargeOperationVerify();
            vw.ShowDialog();
            MessageBox.Show(vw.Verifed ? "通过" : "未通过", "结果");

            if (vw.Verifed)
            {
                this.Hide();
                new SettPassChange().Show();
            }
        }

        private void ignoreSPC_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            LargeOperationVerify vw = new LargeOperationVerify();
            vw.ShowDialog();
            MessageBox.Show(vw.Verifed ? "通过" : "未通过", "结果");

            if (vw.Verifed)
            {
                DialogResult result = MessageBox.Show("确实要忽略吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Settings.Default.ignoreSPSWChange = true;
                }
            }
        }
    }
}
