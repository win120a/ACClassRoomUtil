namespace PowerOnLoggerManagmentTool
{
    partial class ExportBackup
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
            this.e = new System.Windows.Forms.Button();
            this.b = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.re = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // e
            // 
            this.e.Location = new System.Drawing.Point(12, 4);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(82, 30);
            this.e.TabIndex = 0;
            this.e.Text = "Report";
            this.e.UseVisualStyleBackColor = true;
            this.e.Click += new System.EventHandler(this.e_Click);
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(164, 4);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(82, 30);
            this.b.TabIndex = 1;
            this.b.Text = "Backup";
            this.b.UseVisualStyleBackColor = true;
            this.b.Click += new System.EventHandler(this.b_Click);
            // 
            // exit
            // 
            this.exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit.Location = new System.Drawing.Point(164, 53);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(82, 30);
            this.exit.TabIndex = 2;
            this.exit.Text = "Return";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // re
            // 
            this.re.Location = new System.Drawing.Point(12, 53);
            this.re.Name = "re";
            this.re.Size = new System.Drawing.Size(82, 30);
            this.re.TabIndex = 3;
            this.re.Text = "Restore";
            this.re.UseVisualStyleBackColor = true;
            this.re.Click += new System.EventHandler(this.re_Click);
            // 
            // ExportBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exit;
            this.ClientSize = new System.Drawing.Size(258, 95);
            this.Controls.Add(this.re);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.b);
            this.Controls.Add(this.e);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export and Backup Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button e;
        private System.Windows.Forms.Button b;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button re;
    }
}