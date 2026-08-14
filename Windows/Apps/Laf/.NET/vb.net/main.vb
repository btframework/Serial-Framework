Imports System.Security.Policy

Public Class fmMain
    Private Sub FormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Pfn As String = ""
        Dim AppName As String = ""
        Dim Publisher As String = ""
        Dim Res As Int32 = wclLafManager.GetIdentity(Pfn, AppName, Publisher)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbLog.Items.Add("Get identity failed: 0x" + Res.ToString("X8"))
        Else
            lbLog.Items.Add("PFN: " + Pfn)
            lbLog.Items.Add("AppName: " + AppName)
            lbLog.Items.Add("Publisher: " + Publisher)

            Dim Laf As List(Of String) = New List(Of String)()
            Res = wclLafManager.Enum(Laf)
            If Res <> wclErrors.WCL_E_SUCCESS Then
                lbLog.Items.Add("Enum LAF failed: 0x" + Res.ToString("X8"))
            Else
                If Laf.Count = 0 Then
                    lbLog.Items.Add("No LAF found")
                Else
                    For i As Int32 = 0 To Laf.Count - 1
                        cbLaf.Items.Add(Laf(i))
                    Next i

                    cbLaf.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub btUnlockClick(sender As Object, e As EventArgs) Handles btUnlock.Click
        If cbLaf.SelectedIndex = -1 Then
            lbLog.Items.Add("No LAF found")
        Else
            Dim Laf As String = cbLaf.Text
            Dim Res As Int32 = wclLafManager.Unlock(Laf)
            If Res <> wclErrors.WCL_E_SUCCESS Then
                lbLog.Items.Add("Unlock " + Laf + " failed: 0x" + Res.ToString("X8"))
            Else
                lbLog.Items.Add("LAF " + Laf + " unlocked")
            End If
        End If
    End Sub
End Class
