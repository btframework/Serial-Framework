Public Class fmMain
    Private WithEvents FMonitor As wclPowerEventsMonitor

    Private Sub FMonitor_OnPowerStateChanged(Sender As Object, State As wclPowerState) Handles FMonitor.OnPowerStateChanged
        Select Case State
            Case wclPowerState.psPowerStatusChanged
                lbLog.Items.Add("Power status changed")
            Case wclPowerState.psResumeAutomatic
                lbLog.Items.Add("Resumed")
            Case wclPowerState.psResume
                lbLog.Items.Add("Resumed by user")
            Case wclPowerState.psSuspend
                lbLog.Items.Add("Suspended")
            Case wclPowerState.psUnknown
                lbLog.Items.Add("Unknonw")
        End Select
    End Sub

    Private Sub FMonitor_OnStarted(sender As Object, e As EventArgs) Handles FMonitor.OnStarted
        lbLog.Items.Add("Monitor started")
    End Sub

    Private Sub FMonitor_OnStopped(sender As Object, e As EventArgs) Handles FMonitor.OnStopped
        lbLog.Items.Add("Monitor stopped")
    End Sub

    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FMonitor = New wclPowerEventsMonitor()
    End Sub

    Private Sub fmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FMonitor.Stop()
        FMonitor = Nothing
    End Sub

    Private Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        Dim Res As Int32 = FMonitor.Start()
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbLog.Items.Add("Start failed: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btStop_Click(sender As Object, e As EventArgs) Handles btStop.Click
        Dim Res As Int32 = FMonitor.Stop()
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbLog.Items.Add("Stop failed: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btStatus_Click(sender As Object, e As EventArgs) Handles btStatus.Click
        Dim Status As wclPowerStatus
        If Not FMonitor.GetPowerStatus(Status) Then
            lbLog.Items.Add("Get status failed")
        Else
            Select Case Status.ACLineStatus
                Case wclACLineStatus.lsOffline
                    lbLog.Items.Add("AC: Offline")
                Case wclACLineStatus.lsOnline
                    lbLog.Items.Add("AC: Online")
                Case wclACLineStatus.lsBackup
                    lbLog.Items.Add("AC: Backup")
                Case wclACLineStatus.lsUnknown
                    lbLog.Items.Add("AC: Unknown")
            End Select

            Dim Str As String = "["
            If (wclBatteryChargeStatus.csCapacityHigh And Status.BatteryChargeStatus) <> 0 Then
                Str += " csCapacityHigh"
            End If
            If (wclBatteryChargeStatus.csCapacityLow And Status.BatteryChargeStatus) <> 0 Then
                Str += " csCapacityLow"
            End If
            If (wclBatteryChargeStatus.csCapacityCritical And Status.BatteryChargeStatus) <> 0 Then
                Str += " csCapacityCritical"
            End If
            If (wclBatteryChargeStatus.csCharging And Status.BatteryChargeStatus) <> 0 Then
                Str += " csCharging"
            End If
            If (wclBatteryChargeStatus.csNoSystemBattery And Status.BatteryChargeStatus) <> 0 Then
                Str += " csNoSystemBattery"
            End If
            Str += " ]"
            lbLog.Items.Add("Batt: " + Str)

            lbLog.Items.Add("Batt percent: " + Status.BatteryLifePercent.ToString())

            If Status.BatterySavingState Then
                lbLog.Items.Add("Battery saving")
            End If

            If Status.BatteryLifeTime <> UInt32.MaxValue Then
                lbLog.Items.Add("Batt life: " + Status.BatteryLifeTime.ToString())
            End If

            If Status.BatteryFullLifeTime <> UInt32.MaxValue Then
                lbLog.Items.Add("Batt full life: " + Status.BatteryFullLifeTime.ToString())
            End If
        End If
    End Sub
End Class
