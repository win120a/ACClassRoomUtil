namespace RMCrypt_GUI
{
    partial class EnterRandomKey
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
            this.ok = new System.Windows.Forms.Button();
            this.can = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.d1 = new System.Windows.Forms.TextBox();
            this.d2 = new System.Windows.Forms.TextBox();
            this.d3 = new System.Windows.Forms.TextBox();
            this.d4 = new System.Windows.Forms.TextBox();
            this.d5 = new System.Windows.Forms.TextBox();
            this.d6 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(31, 67);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 7;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // can
            // 
            this.can.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.can.Location = new System.Drawing.Point(223, 67);
            this.can.Name = "can";
            this.can.Size = new System.Drawing.Size(75, 23);
            this.can.TabIndex = 8;
            this.can.Text = "Cancel";
            this.can.UseVisualStyleBackColor = true;
            this.can.Click += new System.EventHandler(this.can_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入验证码：";
            // 
            // d1
            // 
            this.d1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.d1.Location = new System.Drawing.Point(12, 40);
            this.d1.MaxLength = 1;
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(42, 21);
            this.d1.TabIndex = 1;
            this.d1.TextChanged += new System.EventHandler(this.d1_TextChanged);
            // 
            // d2
            // 
            this.d2.Location = new System.Drawing.Point(64, 40);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(42, 21);
            this.d2.TabIndex = 2;
            this.d2.TextChanged += new System.EventHandler(this.d2_TextChanged);
            // 
            // d3
            // 
            this.d3.Location = new System.Drawing.Point(112, 40);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(42, 21);
            this.d3.TabIndex = 3;
            this.d3.TextChanged += new System.EventHandler(this.d3_TextChanged);
            // 
            // d4
            // 
            this.d4.Location = new System.Drawing.Point(160, 40);
            this.d4.Name = "d4";
            this.d4.Size = new System.Drawing.Size(42, 21);
            this.d4.TabIndex = 4;
            this.d4.TextChanged += new System.EventHandler(this.d4_TextChanged);
            // 
            // d5
            // 
            this.d5.Location = new System.Drawing.Point(208, 40);
            this.d5.Name = "d5";
            this.d5.Size = new System.Drawing.Size(42, 21);
            this.d5.TabIndex = 5;
            this.d5.TextChanged += new System.EventHandler(this.d5_TextChanged);
            // 
            // d6
            // 
            this.d6.Location = new System.Drawing.Point(257, 40);
            this.d6.Name = "d6";
            this.d6.Size = new System.Drawing.Size(42, 21);
            this.d6.TabIndex = 6;
            this.d6.TextChanged += new System.EventHandler(this.d6_TextChanged);
            // 
            // EnterRandomKey
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.can;
            this.ClientSize = new System.Drawing.Size(311, 104);
            this.Controls.Add(this.d6);
            this.Controls.Add(this.d5);
            this.Controls.Add(this.d4);
            this.Controls.Add(this.d3);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.can);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterRandomKey";
            this.Text = "EnterKey";
            this.Load += new System.EventHandler(this.EnterKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button can;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox d1;
        private System.Windows.Forms.TextBox d2;
        private System.Windows.Forms.TextBox d3;
        private System.Windows.Forms.TextBox d4;
        private System.Windows.Forms.TextBox d5;
        private System.Windows.Forms.TextBox d6;
    }
}