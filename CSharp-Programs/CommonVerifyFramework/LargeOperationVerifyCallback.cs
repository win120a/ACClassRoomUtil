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
using System.Windows.Forms;

namespace ACCVF
{
    public partial class LargeOperationVerifyCallback : Form
    {
        public delegate void Callback(bool result);

        private Callback callback;

        internal IVerifier Verifier { get; }

        public LargeOperationVerifyCallback(IVerifier verifier, Callback cb)
        {
            InitializeComponent();
            this.Verifier = verifier;
            callback = cb;
        }

        private void hint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Verifier.Hints(), "部分提示");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            callback.Invoke(false);
            Hide();
            GC.Collect();
        }

        private void pv_Click(object sender, EventArgs e)
        {
            MessageBox.Show(VerifyValue(textBox1.Text) ? "通过" : "未通过", "结果");
        }

        private bool VerifyValue(string value)
        {
            return Verifier.VerifyValue(value, olp.Text);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Hide();
            callback.Invoke(VerifyValue(textBox1.Text));
        }

        private void LargeOperationVerify_Load(object sender, EventArgs e)
        {
            label1.Text = Verifier.GetFirstVerifyInstructionString();
            label2.Text = Verifier.GetSecondVerifyInstructionString();
        }
    }
}
