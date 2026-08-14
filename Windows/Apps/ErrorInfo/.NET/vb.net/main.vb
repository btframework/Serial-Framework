Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView

Public Class fmMain
    Private Sub btGetDetails_Click(sender As Object, e As EventArgs) Handles btGetDetails.Click
        If edError.Text = "" Then
            MessageBox.Show("Enter error code.")
            Return
        End If

        Dim Base As Int32
        If edError.Text.StartsWith("0x") OrElse edError.Text.StartsWith("$") Then
            Base = 16
        Else
            Base = 10
        End If
        Dim Err As Int32 = Convert.ToInt32(edError.Text, Base)

        lbErrorInfo.Items.Clear()

        Dim Info As wclErrorInformation = New wclErrorInformation()
        If Not Info.Open(edPath.Text) Then
            MessageBox.Show("Open errors definition file failed")
            Return
        End If

        Try
            Dim Details As wclErrorDetails = New wclErrorDetails()
            If Not Info.GetDetails(Err, Details) Then
                MessageBox.Show("Unable to get error details")
                Return
            End If

            lbErrorInfo.Items.Add("Error code: 0x" + Details.Error.ToString("X8"))
            lbErrorInfo.Items.Add("Framework: " + Details.Framework)
            lbErrorInfo.Items.Add("Category: " + Details.Category)
            lbErrorInfo.Items.Add("Constant name: " + Details.Constant)
            lbErrorInfo.Items.Add(Details.Description)
        Finally
            Info.Close()
        End Try
    End Sub

    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 'Allows to access errors.xml from our site.
        ServicePointManager.Expect100Continue = True
        ' SecurityProtocolType.Tls12
        ServicePointManager.SecurityProtocol = CType(&HC0 Or &H300 Or &HC00, SecurityProtocolType)
    End Sub
End Class
