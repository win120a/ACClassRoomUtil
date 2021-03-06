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
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PowerOnLoggerManagmentTool
{
    public partial class ExportBackup : Form
    {
        public ExportBackup()
        {
            InitializeComponent();
        }

        private void WriteLogs(string name)
        {
            StreamWriter sw = new StreamWriter(name);
            string path = Tools.GetLogPath();
            IEnumerable enu0 = Directory.EnumerateFiles(path);
            sw.WriteLine("AC POL Log Report File V2.00");
            sw.WriteLine("Copyright (C) AC Inc.");
            sw.WriteLine();
            foreach (string s in enu0)
            {
                string first = s.Replace(path + "\\", "");
                string second = first.Replace("ACPOL_", "");
                string third = second.Replace("_", " ");
                string forth = third.Replace("H ", ":").Replace("M ", ":");
                string fifth = forth.Replace("S ", " ");
                string final = fifth.Replace(".aclog", " ");
                sw.WriteLine(final);
                sw.Flush();
            }
            sw.Close();
        }

        private void WriteLogsWithCrypt(string name)
        {
            StreamWriter sw = new StreamWriter(name);
            string path = Tools.GetLogPath();
            IEnumerable enu0 = Directory.EnumerateFiles(path);
            StringBuilder sb = new StringBuilder();
            foreach (string s in enu0)
            {
                sb.Append(s + "/");
            }
            string es = Mid.Instance.EncryptString(sb.ToString(), "123");
            sw.Write(es);
            sw.Flush();
            sw.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
            GC.Collect();
            new Main().Show();
        }

        private void e_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text documents|*.txt";
            DialogResult r = sfd.ShowDialog();
            if (r.Equals(DialogResult.OK))
            {
                string name = sfd.FileName;
                WriteLogs(name);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Data File|*.dat";
            DialogResult r = sfd.ShowDialog();
            if (r.Equals(DialogResult.OK))
            {
                string name = sfd.FileName;
                WriteLogsWithCrypt(name);
            }
        }

        private void re_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Data File|*.dat";
            DialogResult r = ofd.ShowDialog();
            if (r.Equals(DialogResult.OK))
            {
                string name = ofd.FileName;
                StreamReader sr = new StreamReader(name);
                string econtent = sr.ReadToEnd();
                string content = Mid.Instance.DecryptString(econtent, "123");
                string[] logs = content.Split('/');
                foreach (string s in logs)
                {
                    if (s == "")
                    {
                        continue;
                    }
                    else
                    {
                        if (Tools.Is64BitOS())
                        {
                            s.Replace("System32", "SysWOW64");
                        }
#if DEBUG
                        MessageBox.Show(s);
#endif
                        File.Create(s);
                    }
                }
            }
        }
    }
}
