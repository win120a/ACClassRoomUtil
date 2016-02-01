﻿namespace LPUGUIProvider
{
    partial class Prefs
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dbdpc = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ignoreSPC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(84, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 20);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "执行完后：";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(2, 60);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(155, 21);
            this.userName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "要修改密码的用户名：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 26);
            this.button3.TabIndex = 8;
            this.button3.Text = "修改密码根";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 116);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 25);
            this.button4.TabIndex = 9;
            this.button4.Text = "消除密码";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dbdpc
            // 
            this.dbdpc.Location = new System.Drawing.Point(2, 147);
            this.dbdpc.Name = "dbdpc";
            this.dbdpc.Size = new System.Drawing.Size(155, 25);
            this.dbdpc.TabIndex = 10;
            this.dbdpc.Text = "更改数据库解密密码";
            this.dbdpc.UseVisualStyleBackColor = true;
            this.dbdpc.Click += new System.EventHandler(this.dbdpc_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 178);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 25);
            this.button5.TabIndex = 11;
            this.button5.Text = "更改暗语";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ignoreSPC
            // 
            this.ignoreSPC.Location = new System.Drawing.Point(2, 209);
            this.ignoreSPC.Name = "ignoreSPC";
            this.ignoreSPC.Size = new System.Drawing.Size(154, 25);
            this.ignoreSPC.TabIndex = 12;
            this.ignoreSPC.Text = "忽略今天的自动密码修改";
            this.ignoreSPC.UseVisualStyleBackColor = true;
            this.ignoreSPC.Click += new System.EventHandler(this.ignoreSPC_Click);
            // 
            // Prefs
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(164, 272);
            this.Controls.Add(this.ignoreSPC);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dbdpc);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prefs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设定";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Prefs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button dbdpc;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button ignoreSPC;
    }
}