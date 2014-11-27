namespace PowerOnLoggerManagmentTool
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lo = new System.Windows.Forms.Button();
            this.x = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Viewer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Delete Util";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "Account\r\nManager";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lo
            // 
            this.lo.Location = new System.Drawing.Point(19, 130);
            this.lo.Name = "lo";
            this.lo.Size = new System.Drawing.Size(77, 35);
            this.lo.TabIndex = 4;
            this.lo.Text = "Logoff";
            this.lo.UseVisualStyleBackColor = true;
            this.lo.Click += new System.EventHandler(this.lo_Click);
            // 
            // x
            // 
            this.x.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.x.Location = new System.Drawing.Point(129, 130);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(77, 35);
            this.x.TabIndex = 5;
            this.x.Text = "Exit";
            this.x.UseVisualStyleBackColor = true;
            this.x.Click += new System.EventHandler(this.x_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(129, 74);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(77, 36);
            this.export.TabIndex = 6;
            this.export.Text = "Export\r\nBackup";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.x;
            this.ClientSize = new System.Drawing.Size(225, 177);
            this.Controls.Add(this.export);
            this.Controls.Add(this.x);
            this.Controls.Add(this.lo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Manager";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button lo;
        internal System.Windows.Forms.Button x;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Button export;

    }
}