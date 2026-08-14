namespace LafManager
{
    partial class fmMain
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
            this.lbLog = new System.Windows.Forms.ListBox();
            this.btUnlock = new System.Windows.Forms.Button();
            this.cbLaf = new System.Windows.Forms.ComboBox();
            this.laLaf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(15, 39);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(539, 316);
            this.lbLog.TabIndex = 7;
            // 
            // btUnlock
            // 
            this.btUnlock.Location = new System.Drawing.Point(479, 10);
            this.btUnlock.Name = "btUnlock";
            this.btUnlock.Size = new System.Drawing.Size(75, 23);
            this.btUnlock.TabIndex = 6;
            this.btUnlock.Text = "Unlock";
            this.btUnlock.UseVisualStyleBackColor = true;
            this.btUnlock.Click += new System.EventHandler(this.btUnlockClick);
            // 
            // cbLaf
            // 
            this.cbLaf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLaf.FormattingEnabled = true;
            this.cbLaf.Location = new System.Drawing.Point(93, 12);
            this.cbLaf.Name = "cbLaf";
            this.cbLaf.Size = new System.Drawing.Size(376, 21);
            this.cbLaf.TabIndex = 5;
            // 
            // laLaf
            // 
            this.laLaf.AutoSize = true;
            this.laLaf.Location = new System.Drawing.Point(12, 15);
            this.laLaf.Name = "laLaf";
            this.laLaf.Size = new System.Drawing.Size(75, 13);
            this.laLaf.TabIndex = 4;
            this.laLaf.Text = "Available LAF:";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 366);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btUnlock);
            this.Controls.Add(this.cbLaf);
            this.Controls.Add(this.laLaf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAF Manager";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btUnlock;
        private System.Windows.Forms.ComboBox cbLaf;
        private System.Windows.Forms.Label laLaf;
    }
}

