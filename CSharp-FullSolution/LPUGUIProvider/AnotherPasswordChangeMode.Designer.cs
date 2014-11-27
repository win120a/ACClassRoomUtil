namespace LPUGUIProvider
{
    partial class AnotherPasswordChangeMode
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
            this.sun = new System.Windows.Forms.Button();
            this.sat = new System.Windows.Forms.Button();
            this.mon = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.tue = new System.Windows.Forms.Button();
            this.wed = new System.Windows.Forms.Button();
            this.thu = new System.Windows.Forms.Button();
            this.fri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(478, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "请输入密码根进行确认：";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(524, 162);
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
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "今天星期几";
            // 
            // sun
            // 
            this.sun.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sun.Location = new System.Drawing.Point(375, 93);
            this.sun.Name = "sun";
            this.sun.Size = new System.Drawing.Size(57, 26);
            this.sun.TabIndex = 7;
            this.sun.Text = "周日";
            this.sun.UseVisualStyleBackColor = true;
            this.sun.Click += new System.EventHandler(this.sun_Click);
            // 
            // sat
            // 
            this.sat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sat.Location = new System.Drawing.Point(148, 93);
            this.sat.Name = "sat";
            this.sat.Size = new System.Drawing.Size(57, 26);
            this.sat.TabIndex = 6;
            this.sat.Text = "周六";
            this.sat.UseVisualStyleBackColor = true;
            this.sat.Click += new System.EventHandler(this.sat_Click);
            // 
            // mon
            // 
            this.mon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mon.Location = new System.Drawing.Point(43, 61);
            this.mon.Name = "mon";
            this.mon.Size = new System.Drawing.Size(57, 26);
            this.mon.TabIndex = 1;
            this.mon.Text = "周一";
            this.mon.UseVisualStyleBackColor = true;
            this.mon.Click += new System.EventHandler(this.mon_Click);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ok.Location = new System.Drawing.Point(524, 132);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(57, 26);
            this.ok.TabIndex = 9;
            this.ok.Text = "确定";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // tue
            // 
            this.tue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tue.Location = new System.Drawing.Point(148, 61);
            this.tue.Name = "tue";
            this.tue.Size = new System.Drawing.Size(57, 26);
            this.tue.TabIndex = 2;
            this.tue.Text = "周二";
            this.tue.UseVisualStyleBackColor = true;
            this.tue.Click += new System.EventHandler(this.tue_Click);
            // 
            // wed
            // 
            this.wed.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.wed.Location = new System.Drawing.Point(260, 61);
            this.wed.Name = "wed";
            this.wed.Size = new System.Drawing.Size(57, 26);
            this.wed.TabIndex = 3;
            this.wed.Text = "周三";
            this.wed.UseVisualStyleBackColor = true;
            this.wed.Click += new System.EventHandler(this.wed_Click);
            // 
            // thu
            // 
            this.thu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.thu.Location = new System.Drawing.Point(375, 61);
            this.thu.Name = "thu";
            this.thu.Size = new System.Drawing.Size(57, 26);
            this.thu.TabIndex = 4;
            this.thu.Text = "周四";
            this.thu.UseVisualStyleBackColor = true;
            this.thu.Click += new System.EventHandler(this.thu_Click);
            // 
            // fri
            // 
            this.fri.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fri.Location = new System.Drawing.Point(483, 61);
            this.fri.Name = "fri";
            this.fri.Size = new System.Drawing.Size(57, 26);
            this.fri.TabIndex = 5;
            this.fri.Text = "周五";
            this.fri.UseVisualStyleBackColor = true;
            this.fri.Click += new System.EventHandler(this.fri_Click);
            // 
            // AnotherPasswordChangeMode
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(593, 207);
            this.Controls.Add(this.fri);
            this.Controls.Add(this.thu);
            this.Controls.Add(this.wed);
            this.Controls.Add(this.tue);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.mon);
            this.Controls.Add(this.sat);
            this.Controls.Add(this.sun);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnotherPasswordChangeMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码修改（特殊原因模式）";
            this.Load += new System.EventHandler(this.AnotherPasswordChangeMode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sun;
        private System.Windows.Forms.Button sat;
        private System.Windows.Forms.Button mon;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button tue;
        private System.Windows.Forms.Button wed;
        private System.Windows.Forms.Button thu;
        private System.Windows.Forms.Button fri;
    }
}