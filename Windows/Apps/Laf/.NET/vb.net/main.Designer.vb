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
        Me.btUnlock = New System.Windows.Forms.Button()
        Me.cbLaf = New System.Windows.Forms.ComboBox()
        Me.laLaf = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbLog
        '
        Me.lbLog.FormattingEnabled = True
        Me.lbLog.Location = New System.Drawing.Point(15, 40)
        Me.lbLog.Name = "lbLog"
        Me.lbLog.Size = New System.Drawing.Size(539, 316)
        Me.lbLog.TabIndex = 11
        '
        'btUnlock
        '
        Me.btUnlock.Location = New System.Drawing.Point(479, 11)
        Me.btUnlock.Name = "btUnlock"
        Me.btUnlock.Size = New System.Drawing.Size(75, 23)
        Me.btUnlock.TabIndex = 10
        Me.btUnlock.Text = "Unlock"
        Me.btUnlock.UseVisualStyleBackColor = True
        '
        'cbLaf
        '
        Me.cbLaf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLaf.FormattingEnabled = True
        Me.cbLaf.Location = New System.Drawing.Point(93, 13)
        Me.cbLaf.Name = "cbLaf"
        Me.cbLaf.Size = New System.Drawing.Size(376, 21)
        Me.cbLaf.TabIndex = 9
        '
        'laLaf
        '
        Me.laLaf.AutoSize = True
        Me.laLaf.Location = New System.Drawing.Point(12, 16)
        Me.laLaf.Name = "laLaf"
        Me.laLaf.Size = New System.Drawing.Size(75, 13)
        Me.laLaf.TabIndex = 8
        Me.laLaf.Text = "Available LAF:"
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 366)
        Me.Controls.Add(Me.lbLog)
        Me.Controls.Add(Me.btUnlock)
        Me.Controls.Add(Me.cbLaf)
        Me.Controls.Add(Me.laLaf)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "fmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAF Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents lbLog As ListBox
    Private WithEvents btUnlock As Button
    Private WithEvents cbLaf As ComboBox
    Private WithEvents laLaf As Label
End Class
