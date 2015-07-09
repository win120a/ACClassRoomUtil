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

using System;
using System.Windows.Forms;

namespace RMCrypt_GUI
{
    public partial class EnterRandomKey : Form
    {
        public EnterRandomKey()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (d1.Text == "" || d2.Text == "" || d3.Text == "" || d4.Text == "" || d5.Text == "" || d6.Text == "") return;
            int digi1 = Int32.Parse(d1.Text);
            int digi2 = Int32.Parse(d2.Text);
            int digi3 = Int32.Parse(d3.Text);
            int digi4 = Int32.Parse(d4.Text);
            int digi5 = Int32.Parse(d5.Text);
            int digi6 = Int32.Parse(d6.Text);

            DataStore.erkr = new int[] { digi1, digi2, digi3, digi4, digi5, digi6 };

            this.Hide();
            GC.Collect();
            this.Dispose();
        }

        private void can_Click(object sender, EventArgs e)
        {
            DataStore.exit = true;
            this.Hide();
            GC.Collect();
            this.Dispose();
        }

        private void EnterKey_Load(object sender, EventArgs e)
        {
            DataStore.exit = false;
        }

        private void d1_TextChanged(object sender, EventArgs e)
        {
            if (d1.Text == "")
            {
                return;
            }
            d2.Select();
        }

        private void d2_TextChanged(object sender, EventArgs e)
        {
            if (d2.Text == "")
            {
                d1.Select();
                return;
            }
            d3.Select();
        }

        private void d3_TextChanged(object sender, EventArgs e)
        {
            if (d3.Text == "")
            {
                d2.Select();
                return;
            }
            d4.Select();
        }

        private void d4_TextChanged(object sender, EventArgs e)
        {
            if (d4.Text == "")
            {
                d3.Select();
                return;
            }
            d5.Select();
        }

        private void d5_TextChanged(object sender, EventArgs e)
        {
            if (d5.Text == "")
            {
                d4.Select();
                return;
            }
            d6.Select();
        }

        private void d6_TextChanged(object sender, EventArgs e)
        {
            if (d6.Text == "")
            {
                d5.Select();
                return;
            }
            ok.Select();
        }
    }
}
