namespace LPUGUIProvider.Windows.Prefs
{
    partial class SettPassChange
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
            this.s = new System.Windows.Forms.TextBox();
            this.o = new System.Windows.Forms.Button();
            this.c = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(12, 12);
            this.s.Name = "s";
            this.s.PasswordChar = '*';
            this.s.Size = new System.Drawing.Size(440, 21);
            this.s.TabIndex = 0;
            // 
            // o
            // 
            this.o.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.o.Location = new System.Drawing.Point(12, 39);
            this.o.Name = "o";
            this.o.Size = new System.Drawing.Size(94, 30);
            this.o.TabIndex = 1;
            this.o.Text = "确定";
            this.o.UseVisualStyleBackColor = true;
            this.o.Click += new System.EventHandler(this.o_Click);
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(358, 39);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(94, 30);
            this.c.TabIndex = 2;
            this.c.Text = "取消";
            this.c.UseVisualStyleBackColor = true;
            this.c.Click += new System.EventHandler(this.c_Click);
            // 
            // SettPassChange
            // 
            this.AcceptButton = this.o;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c;
            this.ClientSize = new System.Drawing.Size(464, 77);
            this.Controls.Add(this.c);
            this.Controls.Add(this.o);
            this.Controls.Add(this.s);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettPassChange";
            this.Text = "暗语设定，以下为暗语";
            this.Load += new System.EventHandler(this.SettPassChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox s;
        private System.Windows.Forms.Button o;
        private System.Windows.Forms.Button c;
    }
}