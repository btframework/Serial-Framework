<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbLog = New System.Windows.Forms.ListBox()
        Me.btClear = New System.Windows.Forms.Button()
        Me.lvDevices = New System.Windows.Forms.ListView()
        Me.btEnable = New System.Windows.Forms.Button()
        Me.btDisable = New System.Windows.Forms.Button()
        Me.btEnumUsb = New System.Windows.Forms.Button()
        Me.btEnumSerial = New System.Windows.Forms.Button()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbLog
        '
        Me.lbLog.FormattingEnabled = True
        Me.lbLog.Location = New System.Drawing.Point(12, 258)
        Me.lbLog.Name = "lbLog"
        Me.lbLog.Size = New System.Drawing.Size(535, 225)
        Me.lbLog.TabIndex = 17
        '
        'btClear
        '
        Me.btClear.Location = New System.Drawing.Point(472, 229)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(75, 23)
        Me.btClear.TabIndex = 16
        Me.btClear.Text = "Clear"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'lvDevices
        '
        Me.lvDevices.FullRowSelect = True
        Me.lvDevices.GridLines = True
        Me.lvDevices.HideSelection = False
        Me.lvDevices.Location = New System.Drawing.Point(12, 41)
        Me.lvDevices.Name = "lvDevices"
        Me.lvDevices.Size = New System.Drawing.Size(535, 182)
        Me.lvDevices.TabIndex = 15
        Me.lvDevices.UseCompatibleStateImageBehavior = False
        Me.lvDevices.View = System.Windows.Forms.View.Details
        '
        'btEnable
        '
        Me.btEnable.Location = New System.Drawing.Point(472, 12)
        Me.btEnable.Name = "btEnable"
        Me.btEnable.Size = New System.Drawing.Size(75, 23)
        Me.btEnable.TabIndex = 14
        Me.btEnable.Text = "Enable"
        Me.btEnable.UseVisualStyleBackColor = True
        '
        'btDisable
        '
        Me.btDisable.Location = New System.Drawing.Point(391, 12)
        Me.btDisable.Name = "btDisable"
        Me.btDisable.Size = New System.Drawing.Size(75, 23)
        Me.btDisable.TabIndex = 13
        Me.btDisable.Text = "Disable"
        Me.btDisable.UseVisualStyleBackColor = True
        '
        'btEnumUsb
        '
        Me.btEnumUsb.Location = New System.Drawing.Point(266, 12)
        Me.btEnumUsb.Name = "btEnumUsb"
        Me.btEnumUsb.Size = New System.Drawing.Size(75, 23)
        Me.btEnumUsb.TabIndex = 12
        Me.btEnumUsb.Text = "Enum USB"
        Me.btEnumUsb.UseVisualStyleBackColor = True
        '
        'btEnumSerial
        '
        Me.btEnumSerial.Location = New System.Drawing.Point(185, 12)
        Me.btEnumSerial.Name = "btEnumSerial"
        Me.btEnumSerial.Size = New System.Drawing.Size(75, 23)
        Me.btEnumSerial.TabIndex = 11
        Me.btEnumSerial.Text = "Enum serial"
        Me.btEnumSerial.UseVisualStyleBackColor = True
        '
        'btStop
        '
        Me.btStop.Location = New System.Drawing.Point(93, 12)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(75, 23)
        Me.btStop.TabIndex = 10
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btStart
        '
        Me.btStart.Location = New System.Drawing.Point(12, 12)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(75, 23)
        Me.btStart.TabIndex = 9
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 496)
        Me.Controls.Add(Me.lbLog)
        Me.Controls.Add(Me.btClear)
        Me.Controls.Add(Me.lvDevices)
        Me.Controls.Add(Me.btEnable)
        Me.Controls.Add(Me.btDisable)
        Me.Controls.Add(Me.btEnumUsb)
        Me.Controls.Add(Me.btEnumSerial)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.btStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "fmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serial Monitor"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lbLog As ListBox
    Private WithEvents btClear As Button
    Private WithEvents lvDevices As ListView
    Private WithEvents btEnable As Button
    Private WithEvents btDisable As Button
    Private WithEvents btEnumUsb As Button
    Private WithEvents btEnumSerial As Button
    Private WithEvents btStop As Button
    Private WithEvents btStart As Button
End Class
