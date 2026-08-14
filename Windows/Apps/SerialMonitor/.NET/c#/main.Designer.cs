namespace SerialMonitor
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
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btEnumSerial = new System.Windows.Forms.Button();
            this.btEnumUsb = new System.Windows.Forms.Button();
            this.btDisable = new System.Windows.Forms.Button();
            this.btEnable = new System.Windows.Forms.Button();
            this.lvDevices = new System.Windows.Forms.ListView();
            this.btClear = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(93, 12);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btEnumSerial
            // 
            this.btEnumSerial.Location = new System.Drawing.Point(185, 12);
            this.btEnumSerial.Name = "btEnumSerial";
            this.btEnumSerial.Size = new System.Drawing.Size(75, 23);
            this.btEnumSerial.TabIndex = 2;
            this.btEnumSerial.Text = "Enum serial";
            this.btEnumSerial.UseVisualStyleBackColor = true;
            this.btEnumSerial.Click += new System.EventHandler(this.btEnumSerial_Click);
            // 
            // btEnumUsb
            // 
            this.btEnumUsb.Location = new System.Drawing.Point(266, 12);
            this.btEnumUsb.Name = "btEnumUsb";
            this.btEnumUsb.Size = new System.Drawing.Size(75, 23);
            this.btEnumUsb.TabIndex = 3;
            this.btEnumUsb.Text = "Enum USB";
            this.btEnumUsb.UseVisualStyleBackColor = true;
            this.btEnumUsb.Click += new System.EventHandler(this.btEnumUsb_Click);
            // 
            // btDisable
            // 
            this.btDisable.Location = new System.Drawing.Point(391, 12);
            this.btDisable.Name = "btDisable";
            this.btDisable.Size = new System.Drawing.Size(75, 23);
            this.btDisable.TabIndex = 4;
            this.btDisable.Text = "Disable";
            this.btDisable.UseVisualStyleBackColor = true;
            this.btDisable.Click += new System.EventHandler(this.btDisable_Click);
            // 
            // btEnable
            // 
            this.btEnable.Location = new System.Drawing.Point(472, 12);
            this.btEnable.Name = "btEnable";
            this.btEnable.Size = new System.Drawing.Size(75, 23);
            this.btEnable.TabIndex = 5;
            this.btEnable.Text = "Enable";
            this.btEnable.UseVisualStyleBackColor = true;
            this.btEnable.Click += new System.EventHandler(this.btEnable_Click);
            // 
            // lvDevices
            // 
            this.lvDevices.FullRowSelect = true;
            this.lvDevices.GridLines = true;
            this.lvDevices.HideSelection = false;
            this.lvDevices.Location = new System.Drawing.Point(12, 41);
            this.lvDevices.Name = "lvDevices";
            this.lvDevices.Size = new System.Drawing.Size(535, 182);
            this.lvDevices.TabIndex = 6;
            this.lvDevices.UseCompatibleStateImageBehavior = false;
            this.lvDevices.View = System.Windows.Forms.View.Details;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(472, 229);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 7;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(12, 258);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(535, 225);
            this.lbLog.TabIndex = 8;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 496);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.lvDevices);
            this.Controls.Add(this.btEnable);
            this.Controls.Add(this.btDisable);
            this.Controls.Add(this.btEnumUsb);
            this.Controls.Add(this.btEnumSerial);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btEnumSerial;
        private System.Windows.Forms.Button btEnumUsb;
        private System.Windows.Forms.Button btDisable;
        private System.Windows.Forms.Button btEnable;
        private System.Windows.Forms.ListView lvDevices;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.ListBox lbLog;
    }
}

