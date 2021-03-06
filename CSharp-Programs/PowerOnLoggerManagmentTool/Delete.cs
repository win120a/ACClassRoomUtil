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

using System;
using System.IO;
using ACCVF;
using System.Windows.Forms;
using ACLibrary.Crypto.MixCryptSeries;
using PowerOnLoggerManagmentTool.Properties;

namespace PowerOnLoggerManagmentTool
{
    public partial class Delete : Form
    {

        private int wrongCount = 0;
        private int maxWrongCount = 5;
        private int remainChance;

        public Delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
            GC.Collect();
            new Main().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wrongCount++;

            remainChance = maxWrongCount - wrongCount;

            Mid ee = Mid.Instance;
            LoginAccount currLA = LoginAccount.ReadFromSettings(ee, ee.DecryptString(Settings.Default.RecoveryKey, ""));

            if (currLA.Password.Equals(textBox1.Text))
            {
                if (LargeOperationVerify.ShowAndVerify())
                {
                    if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.Yes))
                    {
                        if (Directory.Exists(Tools.GetLogPath()))
                        {
                            Directory.Delete(Tools.GetLogPath(), true);
                            Directory.CreateDirectory(Tools.GetLogPath());
                            MessageBox.Show("Delete Log Successful.", "Done");
                            Hide();
                            Dispose();
                            GC.Collect();
                            new Main().Show();
                        }
                        else
                        {
                            MessageBox.Show("You did not install POL.", "HINT!");
                            Hide();
                            Dispose();
                            GC.Collect();
                            new Main().Show();
                        }
                    }
                }
                else
                {
                    Hide();
                    Dispose();
                    GC.Collect();
                    new Main().Show();
                }
            }
            else
            {
                if (remainChance == 0)
                {
                    MessageBox.Show("Password Wrong! You have no chance.", "Fail");
                }
                if (remainChance == 1)
                {
                    MessageBox.Show("Password Wrong! You only have " + remainChance + " chance.", "Fail");
                }
                else
                {
                    MessageBox.Show("Password Wrong! You only have " + remainChance + " chances.", "Fail");
                }

                if (wrongCount >= maxWrongCount)
                {
                    Hide();
                    Settings.Default.Disable = true;
                    Settings.Default.Save();
                    Application.Exit();
                }
            }
        }
    }
}
