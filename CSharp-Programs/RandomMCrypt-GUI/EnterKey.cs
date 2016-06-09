﻿/*
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
    public partial class EnterKey : Form
    {
        public EnterKey()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DataStore.Key = textBox1.Text;
            Hide();
            GC.Collect();
            Dispose();
        }

        private void can_Click(object sender, EventArgs e)
        {
            DataStore.exit = true;
            Hide();
            GC.Collect();
            Dispose();
        }

        private void EnterKey_Load(object sender, EventArgs e)
        {
            DataStore.exit = false;
        }
    }
}
