namespace RMCrypt_GUI
{
    partial class Main
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
            this.result = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.tm = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.test = new System.Windows.Forms.Button();
            this.MixCryptStrongest = new System.Windows.Forms.RadioButton();
            this.MixCryptStronger = new System.Windows.Forms.RadioButton();
            this.MixCryptMid = new System.Windows.Forms.RadioButton();
            this.MixCryptWeak = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(46, 194);
            this.result.MaxLength = 3276700;
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result.Size = new System.Drawing.Size(609, 170);
            this.result.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(520, 370);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 41);
            this.button3.TabIndex = 5;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(46, 12);
            this.input.MaxLength = 3276700;
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.input.Size = new System.Drawing.Size(609, 170);
            this.input.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Result";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(366, 370);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(97, 41);
            this.clear.TabIndex = 4;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // tm
            // 
            this.tm.AutoSize = true;
            this.tm.Location = new System.Drawing.Point(638, 383);
            this.tm.Name = "tm";
            this.tm.Size = new System.Drawing.Size(66, 16);
            this.tm.TabIndex = 7;
            this.tm.Text = "TopMost";
            this.tm.UseVisualStyleBackColor = true;
            this.tm.CheckedChanged += new System.EventHandler(this.tm_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(661, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 38);
            this.button4.TabIndex = 8;
            this.button4.Text = "Paste";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(661, 260);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 38);
            this.button5.TabIndex = 9;
            this.button5.Text = "Copy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.test);
            this.groupBox1.Controls.Add(this.MixCryptStrongest);
            this.groupBox1.Controls.Add(this.MixCryptStronger);
            this.groupBox1.Controls.Add(this.MixCryptMid);
            this.groupBox1.Controls.Add(this.MixCryptWeak);
            this.groupBox1.Location = new System.Drawing.Point(46, 417);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 94);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crypt Method";
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(588, 52);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(53, 31);
            this.test.TabIndex = 8;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Visible = false;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // MixCryptStrongest
            // 
            this.MixCryptStrongest.AutoSize = true;
            this.MixCryptStrongest.Location = new System.Drawing.Point(279, 59);
            this.MixCryptStrongest.Name = "MixCryptStrongest";
            this.MixCryptStrongest.Size = new System.Drawing.Size(167, 16);
            this.MixCryptStrongest.TabIndex = 7;
            this.MixCryptStrongest.Text = "MixCrypt Strongest (All)";
            this.MixCryptStrongest.UseVisualStyleBackColor = true;
            this.MixCryptStrongest.CheckedChanged += new System.EventHandler(this.MixCryptStrongest_CheckedChanged);
            // 
            // MixCryptStronger
            // 
            this.MixCryptStronger.AutoSize = true;
            this.MixCryptStronger.Location = new System.Drawing.Point(23, 59);
            this.MixCryptStronger.Name = "MixCryptStronger";
            this.MixCryptStronger.Size = new System.Drawing.Size(227, 16);
            this.MixCryptStronger.TabIndex = 6;
            this.MixCryptStronger.Text = "MixCrypt Stronger (3AES+3DES+3RC2)";
            this.MixCryptStronger.UseVisualStyleBackColor = true;
            this.MixCryptStronger.CheckedChanged += new System.EventHandler(this.MixCryptStronger_CheckedChanged);
            // 
            // MixCryptMid
            // 
            this.MixCryptMid.AutoSize = true;
            this.MixCryptMid.Location = new System.Drawing.Point(279, 30);
            this.MixCryptMid.Name = "MixCryptMid";
            this.MixCryptMid.Size = new System.Drawing.Size(143, 16);
            this.MixCryptMid.TabIndex = 5;
            this.MixCryptMid.Text = "MixCrypt (3AES+3DES)";
            this.MixCryptMid.UseVisualStyleBackColor = true;
            this.MixCryptMid.CheckedChanged += new System.EventHandler(this.MixCryptMid_CheckedChanged);
            // 
            // MixCryptWeak
            // 
            this.MixCryptWeak.AutoSize = true;
            this.MixCryptWeak.Checked = true;
            this.MixCryptWeak.Location = new System.Drawing.Point(23, 30);
            this.MixCryptWeak.Name = "MixCryptWeak";
            this.MixCryptWeak.Size = new System.Drawing.Size(173, 16);
            this.MixCryptWeak.TabIndex = 4;
            this.MixCryptWeak.TabStop = true;
            this.MixCryptWeak.Text = "MixCrypt Weak (3AES Only)";
            this.MixCryptWeak.UseVisualStyleBackColor = true;
            this.MixCryptWeak.CheckedChanged += new System.EventHandler(this.MixCryptWeak_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tm);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.result);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "MCrypt-Gui";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.CheckBox tm;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton MixCryptStrongest;
        private System.Windows.Forms.RadioButton MixCryptStronger;
        private System.Windows.Forms.RadioButton MixCryptMid;
        private System.Windows.Forms.RadioButton MixCryptWeak;
        private System.Windows.Forms.Button test;
    }
}

