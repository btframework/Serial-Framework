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
        Me.lbErrorInfo = New System.Windows.Forms.ListBox()
        Me.btGetDetails = New System.Windows.Forms.Button()
        Me.edError = New System.Windows.Forms.TextBox()
        Me.laDescr = New System.Windows.Forms.Label()
        Me.edPath = New System.Windows.Forms.TextBox()
        Me.laPath = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbErrorInfo
        '
        Me.lbErrorInfo.FormattingEnabled = True
        Me.lbErrorInfo.Location = New System.Drawing.Point(17, 67)
        Me.lbErrorInfo.Name = "lbErrorInfo"
        Me.lbErrorInfo.Size = New System.Drawing.Size(463, 264)
        Me.lbErrorInfo.TabIndex = 11
        '
        'btGetDetails
        '
        Me.btGetDetails.Location = New System.Drawing.Point(385, 38)
        Me.btGetDetails.Name = "btGetDetails"
        Me.btGetDetails.Size = New System.Drawing.Size(95, 23)
        Me.btGetDetails.TabIndex = 10
        Me.btGetDetails.Text = "Get details"
        Me.btGetDetails.UseVisualStyleBackColor = True
        '
        'edError
        '
        Me.edError.Location = New System.Drawing.Point(267, 40)
        Me.edError.Name = "edError"
        Me.edError.Size = New System.Drawing.Size(112, 20)
        Me.edError.TabIndex = 9
        Me.edError.Text = "0x00000000"
        '
        'laDescr
        '
        Me.laDescr.AutoSize = True
        Me.laDescr.Location = New System.Drawing.Point(14, 43)
        Me.laDescr.Name = "laDescr"
        Me.laDescr.Size = New System.Drawing.Size(247, 13)
        Me.laDescr.TabIndex = 8
        Me.laDescr.Text = "Error code. Start with $ or 0x for hexadecimal value"
        '
        'edPath
        '
        Me.edPath.Location = New System.Drawing.Point(139, 12)
        Me.edPath.Name = "edPath"
        Me.edPath.Size = New System.Drawing.Size(341, 20)
        Me.edPath.TabIndex = 7
        Me.edPath.Text = "https://www.btframework.com/errors8.xml"
        '
        'laPath
        '
        Me.laPath.AutoSize = True
        Me.laPath.Location = New System.Drawing.Point(14, 15)
        Me.laPath.Name = "laPath"
        Me.laPath.Size = New System.Drawing.Size(119, 13)
        Me.laPath.TabIndex = 6
        Me.laPath.Text = "Errors definition file path"
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 343)
        Me.Controls.Add(Me.lbErrorInfo)
        Me.Controls.Add(Me.btGetDetails)
        Me.Controls.Add(Me.edError)
        Me.Controls.Add(Me.laDescr)
        Me.Controls.Add(Me.edPath)
        Me.Controls.Add(Me.laPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "fmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Error Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents lbErrorInfo As ListBox
    Private WithEvents btGetDetails As Button
    Private WithEvents edError As TextBox
    Private WithEvents laDescr As Label
    Private WithEvents edPath As TextBox
    Private WithEvents laPath As Label
End Class
