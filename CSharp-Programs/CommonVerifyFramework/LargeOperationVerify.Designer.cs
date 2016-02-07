namespace ACCVF
{
    partial class LargeOperationVerify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hint = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pv = new System.Windows.Forms.Button();
            this.olp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 21);
            this.textBox1.TabIndex = 1;
            // 
            // hint
            // 
            this.hint.Location = new System.Drawing.Point(12, 104);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(69, 25);
            this.hint.TabIndex = 3;
            this.hint.Text = "提示";
            this.hint.UseVisualStyleBackColor = true;
            this.hint.Click += new System.EventHandler(this.hint_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(343, 105);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(69, 25);
            this.ok.TabIndex = 5;
            this.ok.Text = "确定";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(418, 105);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(69, 25);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "第一验证字符：";
            // 
            // pv
            // 
            this.pv.Location = new System.Drawing.Point(87, 105);
            this.pv.Name = "pv";
            this.pv.Size = new System.Drawing.Size(74, 24);
            this.pv.TabIndex = 4;
            this.pv.Text = "预验证";
            this.pv.UseVisualStyleBackColor = true;
            this.pv.Click += new System.EventHandler(this.pv_Click);
            // 
            // olp
            // 
            this.olp.Location = new System.Drawing.Point(12, 77);
            this.olp.Name = "olp";
            this.olp.Size = new System.Drawing.Size(475, 21);
            this.olp.TabIndex = 2;
            this.olp.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 999;
            this.label2.Text = "第二验证字符：";
            // 
            // LargeOperationVerify
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(499, 137);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.olp);
            this.Controls.Add(this.pv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.hint);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LargeOperationVerify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AC统一验证框架";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LargeOperationVerify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button hint;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pv;
        private System.Windows.Forms.TextBox olp;
        private System.Windows.Forms.Label label2;
    }
}