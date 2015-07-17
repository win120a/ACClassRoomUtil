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
    public partial class Verify : Form
    {
        public Verify()
        {
            InitializeComponent();
        }

        private void co_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show(Properties.Settings.Default.User);
            MessageBox.Show(Properties.Settings.Default.Pass);
            this.Hide();
            GC.Collect();
            new Main().Show();
#else
            if ((p.Text.Equals(Properties.Settings.Default.Pass)) && (u.Text.Equals(Properties.Settings.Default.User)))
            {
                this.Hide();
                GC.Collect();
                new Main().Show();
            }
            else
            {
                MessageBox.Show("User/Password Wrong!", "Fail");
            }
#endif
        }

        private void cc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
