Public Class fmMain
    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Str As String
        Select Case wclOsVersion.OsType
            Case wclOsType.osUnknown
                Str = "OS unknown"
            Case wclOsType.osMacOS
                Str = "Mac OS"
            Case wclOsType.osWinXP
                Str = "Windows XP"
            Case wclOsType.osWinVista
                Str = "Windows Vista"
            Case wclOsType.osWin7
                Str = "Windows 7"
            Case wclOsType.osWin8
                Str = "Windows 8"
            Case wclOsType.osWin81
                Str = "Windows 8.1"
            Case wclOsType.osWin10
                Str = "Windows 10"
            Case wclOsType.osWin11
                Str = "Windows 11"
            Case Else
                Str = "Undefined OS"
        End Select

        Str = Str + " " + wclOsVersion.Major.ToString() + "." +
            wclOsVersion.Minor.ToString() + "." + wclOsVersion.Build.ToString()
        laOsVersion.Text = Str
    End Sub
End Class
