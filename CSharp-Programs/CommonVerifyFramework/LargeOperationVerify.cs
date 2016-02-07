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
    public partial class LargeOperationVerify : Form
    {
        private bool verified = false;
        private IVerifier verifier;

        public bool Verified
        {
            get
            {
                return verified;
            }
        }

        internal IVerifier Verifier
        {
            get
            {
                return verifier;
            }
        }

        public LargeOperationVerify()
        {
            InitializeComponent();
            verifier = new ACCommonVerify();
        }

        public LargeOperationVerify(IVerifier verifier)
        {
            InitializeComponent();
            this.verifier = verifier;
        }

        private void hint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Verifier.Hints(), "部分提示");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            verified = false;
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
            verified = VerifyValue(textBox1.Text);   // Verify Value.
            Hide();
        }

        public static bool ShowAndVerify()
        {
            LargeOperationVerify lov = new LargeOperationVerify();
            lov.ShowDialog();
            return lov.Verified;
        }

        private void LargeOperationVerify_Load(object sender, EventArgs e)
        {
            label1.Text = Verifier.GetFirstVerifyInstructionString();
            label2.Text = Verifier.GetSecondVerifyInstructionString();
        }
    }
}
