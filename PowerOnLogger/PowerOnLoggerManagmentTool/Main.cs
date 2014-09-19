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

namespace PowerOnLoggerManagmentTool
{
    public partial class Main : Form
    {
        int selfLockTime = 1;  // in minutes

        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Account().Show();
        }



        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000 * 60 * selfLockTime;
            timer1.Start();
        }

        private void lo_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Verify().Show();
        }

        private void x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new View().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Delete().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Verify().Show();
        }
    }
}
