namespace ErrorInfo
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
            this.laPath = new System.Windows.Forms.Label();
            this.edPath = new System.Windows.Forms.TextBox();
            this.laDescr = new System.Windows.Forms.Label();
            this.edError = new System.Windows.Forms.TextBox();
            this.btGetDetails = new System.Windows.Forms.Button();
            this.lbErrorInfo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // laPath
            // 
            this.laPath.AutoSize = true;
            this.laPath.Location = new System.Drawing.Point(12, 15);
            this.laPath.Name = "laPath";
            this.laPath.Size = new System.Drawing.Size(119, 13);
            this.laPath.TabIndex = 0;
            this.laPath.Text = "Errors definition file path";
            // 
            // edPath
            // 
            this.edPath.Location = new System.Drawing.Point(137, 12);
            this.edPath.Name = "edPath";
            this.edPath.Size = new System.Drawing.Size(341, 20);
            this.edPath.TabIndex = 1;
            this.edPath.Text = "https://www.btframework.com/errors8.xml";
            // 
            // laDescr
            // 
            this.laDescr.AutoSize = true;
            this.laDescr.Location = new System.Drawing.Point(12, 43);
            this.laDescr.Name = "laDescr";
            this.laDescr.Size = new System.Drawing.Size(247, 13);
            this.laDescr.TabIndex = 2;
            this.laDescr.Text = "Error code. Start with $ or 0x for hexadecimal value";
            // 
            // edError
            // 
            this.edError.Location = new System.Drawing.Point(265, 40);
            this.edError.Name = "edError";
            this.edError.Size = new System.Drawing.Size(112, 20);
            this.edError.TabIndex = 3;
            this.edError.Text = "0x00000000";
            // 
            // btGetDetails
            // 
            this.btGetDetails.Location = new System.Drawing.Point(383, 38);
            this.btGetDetails.Name = "btGetDetails";
            this.btGetDetails.Size = new System.Drawing.Size(95, 23);
            this.btGetDetails.TabIndex = 4;
            this.btGetDetails.Text = "Get details";
            this.btGetDetails.UseVisualStyleBackColor = true;
            this.btGetDetails.Click += new System.EventHandler(this.btGetDetails_Click);
            // 
            // lbErrorInfo
            // 
            this.lbErrorInfo.FormattingEnabled = true;
            this.lbErrorInfo.Location = new System.Drawing.Point(15, 67);
            this.lbErrorInfo.Name = "lbErrorInfo";
            this.lbErrorInfo.Size = new System.Drawing.Size(463, 264);
            this.lbErrorInfo.TabIndex = 5;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 343);
            this.Controls.Add(this.lbErrorInfo);
            this.Controls.Add(this.btGetDetails);
            this.Controls.Add(this.edError);
            this.Controls.Add(this.laDescr);
            this.Controls.Add(this.edPath);
            this.Controls.Add(this.laPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laPath;
        private System.Windows.Forms.TextBox edPath;
        private System.Windows.Forms.Label laDescr;
        private System.Windows.Forms.TextBox edError;
        private System.Windows.Forms.Button btGetDetails;
        private System.Windows.Forms.ListBox lbErrorInfo;
    }
}

