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

using System;
using System.IO;
using System.Windows.Forms;

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
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Main().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wrongCount++;

            remainChance = maxWrongCount - wrongCount;

            if (Properties.Settings.Default.Pass.Equals(textBox1.Text))
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.Yes))
                {
                    if (Directory.Exists(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger"))
                    {
                        Directory.Delete(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger", true);
                        Directory.CreateDirectory(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger");
                        MessageBox.Show("Delete Log Successful.", "Done");
                        this.Hide();
                        this.Dispose();
                        GC.Collect();
                        new Main().Show();
                    }
                    else
                    {
                        MessageBox.Show("You did not install POL.", "HINT!");
                        this.Hide();
                        this.Dispose();
                        GC.Collect();
                        new Main().Show();
                    }
                }
                else
                {
                    this.Hide();
                    this.Dispose();
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
                    this.Hide();
                    this.Dispose();
                    GC.Collect();
                    Main mainObj = new Main();
                    mainObj.button1.Enabled = false;
                    mainObj.button2.Enabled = false;
                    mainObj.button3.Enabled = false;
                    mainObj.Show();
                }
            }
        }
    }
}
