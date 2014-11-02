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
using System.Windows.Forms;
using Microsoft.Win32;
using LPU_Crypt_API;
using System.IO;
using System.Collections;
using System.Text;

namespace PowerOnLoggerManagmentTool
{
    public partial class ExportBackup : Form
    {
        public ExportBackup()
        {
            InitializeComponent();
        }

        private void WriteLogs(String name)
        {
            StreamWriter sw = new StreamWriter(name);
            String path = Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger";
            IEnumerable enu0 = Directory.EnumerateFiles(path);
            foreach (string s in enu0)
            {
                sw.WriteLine(s);
                sw.Flush();
            }
            sw.Close();
        }

        private void WriteLogsWithCrypt(String name)
        {
            StreamWriter sw = new StreamWriter(name);
            String path = Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger";
            IEnumerable enu0 = Directory.EnumerateFiles(path);
            StringBuilder sb = new StringBuilder();
            foreach (string s in enu0)
            {
                sb.Append(s + "/");
            }
            String es = new LPU_Crypt_API.MixCrypt().encrypt(sb.ToString(), "123");
            sw.Write(es);
            sw.Flush();
            sw.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Main().Show();
        }

        private void e_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".txt";
            sfd.Filter = "Text documents|*.txt";
            DialogResult r = sfd.ShowDialog();
            if (r.Equals(DialogResult.OK))
            {
                String name = sfd.FileName;
                WriteLogs(name);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".txt";
            sfd.Filter = "Data File|*.dat";
            DialogResult r = sfd.ShowDialog();
            if (r.Equals(DialogResult.OK))
            {
                String name = sfd.FileName;
                WriteLogsWithCrypt(name);
            }
        }

        private void re_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Data File|*.dat";
            DialogResult r = ofd.ShowDialog();
            if (r.Equals(DialogResult.OK))
            {
                String name = ofd.FileName;
                StreamReader sr = new StreamReader(name);
                String econtent = sr.ReadToEnd();
                String content = new MixCrypt().decrypt(econtent, "123");
                String[] logs = content.Split('/');
                foreach (String s in logs)
                {
                    if (s == "")
                    {
                        continue;
                    }
                    else
                    {
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
