namespace LPUGUIProvider
{
    partial class DayOfWeekPasswordChangeMode
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
            this.label3 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sBox = new System.Windows.Forms.ComboBox();
            this.OK2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "请输入密码根进行确认：";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(90, 124);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(57, 26);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "今天星期几";
            // 
            // sBox
            // 
            this.sBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sBox.FormattingEnabled = true;
            this.sBox.Location = new System.Drawing.Point(12, 59);
            this.sBox.Name = "sBox";
            this.sBox.Size = new System.Drawing.Size(121, 20);
            this.sBox.TabIndex = 11;
            // 
            // OK2
            // 
            this.OK2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OK2.Location = new System.Drawing.Point(12, 124);
            this.OK2.Name = "OK2";
            this.OK2.Size = new System.Drawing.Size(57, 26);
            this.OK2.TabIndex = 12;
            this.OK2.Text = "确定";
            this.OK2.UseVisualStyleBackColor = true;
            this.OK2.Click += new System.EventHandler(this.OK2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "请选择星期：";
            // 
            // AnotherPasswordChangeMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(157, 162);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OK2);
            this.Controls.Add(this.sBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnotherPasswordChangeMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "星期模式";
            this.Load += new System.EventHandler(this.AnotherPasswordChangeMode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sBox;
        private System.Windows.Forms.Button OK2;
        private System.Windows.Forms.Label label2;
    }
}