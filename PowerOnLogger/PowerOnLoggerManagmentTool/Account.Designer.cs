namespace PowerOnLoggerManagmentTool
{
    partial class Account
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
            this.pc = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nuc = new System.Windows.Forms.TextBox();
            this.nu = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.op = new System.Windows.Forms.TextBox();
            this.np = new System.Windows.Forms.TextBox();
            this.npc = new System.Windows.Forms.TextBox();
            this.uc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pc
            // 
            this.pc.Location = new System.Drawing.Point(142, 260);
            this.pc.Name = "pc";
            this.pc.Size = new System.Drawing.Size(62, 24);
            this.pc.TabIndex = 6;
            this.pc.Text = "Commit";
            this.pc.UseVisualStyleBackColor = true;
            this.pc.Click += new System.EventHandler(this.pc_Click);
            // 
            // exit
            // 
            this.exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit.Location = new System.Drawing.Point(292, 260);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(28, 24);
            this.exit.TabIndex = 7;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nuc);
            this.groupBox1.Controls.Add(this.nu);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 99);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Confirm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "New User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Old User";
            // 
            // nuc
            // 
            this.nuc.Location = new System.Drawing.Point(79, 69);
            this.nuc.Name = "nuc";
            this.nuc.Size = new System.Drawing.Size(218, 21);
            this.nuc.TabIndex = 13;
            // 
            // nu
            // 
            this.nu.Location = new System.Drawing.Point(79, 42);
            this.nu.Name = "nu";
            this.nu.Size = new System.Drawing.Size(218, 21);
            this.nu.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(218, 21);
            this.textBox1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.op);
            this.groupBox2.Controls.Add(this.np);
            this.groupBox2.Controls.Add(this.npc);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 106);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "Confirm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "Old Pass";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "New Pass";
            // 
            // op
            // 
            this.op.Location = new System.Drawing.Point(76, 14);
            this.op.Name = "op";
            this.op.PasswordChar = '#';
            this.op.Size = new System.Drawing.Size(218, 21);
            this.op.TabIndex = 16;
            // 
            // np
            // 
            this.np.Location = new System.Drawing.Point(76, 41);
            this.np.Name = "np";
            this.np.PasswordChar = '#';
            this.np.Size = new System.Drawing.Size(218, 21);
            this.np.TabIndex = 17;
            // 
            // npc
            // 
            this.npc.Location = new System.Drawing.Point(76, 68);
            this.npc.Name = "npc";
            this.npc.PasswordChar = '#';
            this.npc.Size = new System.Drawing.Size(218, 21);
            this.npc.TabIndex = 18;
            // 
            // uc
            // 
            this.uc.Location = new System.Drawing.Point(142, 117);
            this.uc.Name = "uc";
            this.uc.Size = new System.Drawing.Size(62, 24);
            this.uc.TabIndex = 16;
            this.uc.Text = "Commit";
            this.uc.UseVisualStyleBackColor = true;
            this.uc.Click += new System.EventHandler(this.uc_Click);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exit;
            this.ClientSize = new System.Drawing.Size(332, 296);
            this.Controls.Add(this.uc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.pc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Manager";
            this.Load += new System.EventHandler(this.Account_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pc;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nuc;
        private System.Windows.Forms.TextBox nu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox op;
        private System.Windows.Forms.TextBox np;
        private System.Windows.Forms.TextBox npc;
        private System.Windows.Forms.Button uc;
    }
}