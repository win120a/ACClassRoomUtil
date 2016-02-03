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

using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace PowerOnLoggerManagmentTool
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void LoadLogs()
        {
            listBox1.Items.Clear();
            if (!(Directory.Exists(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger")))
            {
                listBox1.Items.Add("You didn't install POL.");
                return;
            }
            listBox1.Hide();
            String path = Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger";
            IEnumerable enu0 = Directory.EnumerateFiles(path);
            listBox1.BeginUpdate();
            foreach (string s in enu0)
            {
                string first = s.Replace(path + "\\", " ");
                string second = first.Replace("ACPOL_", " ");
                string third = second.Replace("_", " ");
                string forth = third.Replace("H ", ":").Replace("M ", ":");
                string fifth = forth.Replace("S ", " ");
                string final = fifth.Replace(".aclog", " ");
                listBox1.Items.Add(final);
            }
            listBox1.EndUpdate();
            listBox1.Show();
        }

        private void View_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GC.Collect();
            new Main().Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }
    }
}
