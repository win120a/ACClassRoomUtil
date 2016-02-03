namespace PowerOnLoggerManagmentTool
{
    partial class Verify
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.u = new System.Windows.Forms.TextBox();
            this.p = new System.Windows.Forms.TextBox();
            this.co = new System.Windows.Forms.Button();
            this.ca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // u
            // 
            this.u.Location = new System.Drawing.Point(41, 35);
            this.u.Name = "u";
            this.u.Size = new System.Drawing.Size(224, 21);
            this.u.TabIndex = 0;
            // 
            // p
            // 
            this.p.Location = new System.Drawing.Point(41, 63);
            this.p.Name = "p";
            this.p.PasswordChar = '#';
            this.p.Size = new System.Drawing.Size(223, 21);
            this.p.TabIndex = 1;
            // 
            // co
            // 
            this.co.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.co.Location = new System.Drawing.Point(39, 104);
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(66, 26);
            this.co.TabIndex = 2;
            this.co.Text = "Commit";
            this.co.UseVisualStyleBackColor = true;
            this.co.Click += new System.EventHandler(this.co_Click);
            // 
            // ca
            // 
            this.ca.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ca.Location = new System.Drawing.Point(196, 105);
            this.ca.Name = "ca";
            this.ca.Size = new System.Drawing.Size(66, 25);
            this.ca.TabIndex = 3;
            this.ca.Text = "Cancel";
            this.ca.UseVisualStyleBackColor = true;
            this.ca.Click += new System.EventHandler(this.cc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pass";
            // 
            // fp
            // 
            this.fp.Location = new System.Drawing.Point(128, 6);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(137, 23);
            this.fp.TabIndex = 6;
            this.fp.Text = "Forgot Password?";
            this.fp.UseVisualStyleBackColor = true;
            this.fp.Click += new System.EventHandler(this.fp_Click);
            // 
            // Verify
            // 
            this.AcceptButton = this.co;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ca;
            this.ClientSize = new System.Drawing.Size(278, 142);
            this.Controls.Add(this.fp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ca);
            this.Controls.Add(this.co);
            this.Controls.Add(this.p);
            this.Controls.Add(this.u);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Verify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login to Log Manager";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Verify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox u;
        private System.Windows.Forms.TextBox p;
        private System.Windows.Forms.Button co;
        private System.Windows.Forms.Button ca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fp;
    }
}

