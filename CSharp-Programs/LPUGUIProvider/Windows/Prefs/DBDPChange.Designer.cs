namespace LPUGUIProvider.Windows.Prefs
{
    partial class DBDPChange
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
            this.label1 = new System.Windows.Forms.Label();
            this.o = new System.Windows.Forms.TextBox();
            this.n = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 999;
            this.label1.Text = "原密码：";
            // 
            // o
            // 
            this.o.Location = new System.Drawing.Point(59, 6);
            this.o.Name = "o";
            this.o.PasswordChar = '*';
            this.o.Size = new System.Drawing.Size(491, 21);
            this.o.TabIndex = 1;
            // 
            // n
            // 
            this.n.Location = new System.Drawing.Point(59, 33);
            this.n.Name = "n";
            this.n.PasswordChar = '*';
            this.n.Size = new System.Drawing.Size(491, 21);
            this.n.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 999;
            this.label2.Text = "新密码：";
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(59, 60);
            this.c.Name = "c";
            this.c.PasswordChar = '*';
            this.c.Size = new System.Drawing.Size(491, 21);
            this.c.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 999;
            this.label3.Text = "确认：";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(59, 87);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 4;
            this.ok.Text = "确定";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(475, 87);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // DBDPChange
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(563, 121);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.c);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.n);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.o);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBDPChange";
            this.Text = "数据库解密密码修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox o;
        private System.Windows.Forms.TextBox n;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}