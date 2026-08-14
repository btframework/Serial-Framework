Imports System

Public Class fmMain
    Dim WithEvents FMonitor As wclSerialMonitor
    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FMonitor = New wclSerialMonitor()
    End Sub

    Private Sub fmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FMonitor.Stop()
    End Sub

    Private Sub btClear_Click(sender As Object, e As EventArgs) Handles btClear.Click
        lbLog.Items.Clear()
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

    Private Sub btEnumSerial_Click(sender As Object, e As EventArgs) Handles btEnumSerial.Click
        lvDevices.Items.Clear()
        lvDevices.Columns.Clear()

        Dim Column As ColumnHeader = lvDevices.Columns.Add("Device name")
        Column.Width = 80
        Column = lvDevices.Columns.Add("Friendly name")
        Column.Width = 350
        Column = lvDevices.Columns.Add("IsModem")
        Column.Width = 70

        Dim Devices As List(Of wclSerialDevice) = Nothing
        Dim Res As Int32 = FMonitor.EnumSerialDevices(Devices)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbLog.Items.Add("Enum serial devices failed: 0x" + Res.ToString("X8"))
            Return
        End If


        If Devices Is Nothing Or Devices.Count = 0 Then
            lbLog.Items.Add("No serial devices found")
            Return
        End If

        lbLog.Items.Add("Found " + Devices.Count.ToString() + " serial devices")
        For Each Device As wclSerialDevice In Devices
            Dim Item As ListViewItem = lvDevices.Items.Add(Device.DeviceName)
            Item.SubItems.Add(Device.FriendlyName)
            Item.SubItems.Add(Device.IsModem.ToString())
        Next
    End Sub

    Private Sub btEnumUsb_Click(sender As Object, e As EventArgs) Handles btEnumUsb.Click
        lvDevices.Items.Clear()
        lvDevices.Columns.Clear()

        Dim Column As ColumnHeader = lvDevices.Columns.Add("Instance")
        Column.Width = 250
        Column = lvDevices.Columns.Add("Friendly name")
        Column.Width = 250
        Column = lvDevices.Columns.Add("VID")
        Column.Width = 50
        Column = lvDevices.Columns.Add("PID")
        Column.Width = 50
        Column = lvDevices.Columns.Add("Class")
        Column.Width = 250
        Column = lvDevices.Columns.Add("Manufacturer")
        Column.Width = 200
        Column = lvDevices.Columns.Add("Enabled")
        Column.Width = 70

        Dim Devices As List(Of wclUsbDevice) = Nothing
        Dim Res As Int32 = FMonitor.EnumUsbDevices(Devices)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbLog.Items.Add("Enum USB devices failed: 0x" + Res.ToString("X8"))
            Return
        End If

        If Devices Is Nothing Or Devices.Count = 0 Then
            lbLog.Items.Add("No USB devices found")
            Return
        End If

        lbLog.Items.Add("Found " + Devices.Count.ToString() + " USB devices")
        For Each Device As wclUsbDevice In Devices
            Dim Item As ListViewItem = lvDevices.Items.Add(Device.Instance)
            Item.SubItems.Add(Device.FriendlyName)
            Item.SubItems.Add(Device.VendorId.ToString("X4"))
            Item.SubItems.Add(Device.ProductId.ToString("X4"))
            Item.SubItems.Add(Device.ClassGuid.ToString())
            Item.SubItems.Add(Device.Manufacturer)
            Item.SubItems.Add(Device.Enabled.ToString())
        Next
    End Sub

    Private Sub btDisable_Click(sender As Object, e As EventArgs) Handles btDisable.Click
        SwitchUsbDevice(False)
    End Sub

    Private Sub btEnable_Click(sender As Object, e As EventArgs) Handles btEnable.Click
        SwitchUsbDevice(True)
    End Sub

    Private Sub SwitchUsbDevice(Enable As Boolean)
        If lvDevices.Columns.Count < 7 Then
            MessageBox.Show("Enumerate USB devices")
            Return
        End If

        If lvDevices.Items.Count = 0 Then
            MessageBox.Show("No USB devices found")
            Return
        End If

        If lvDevices.SelectedItems.Count = 0 Then
            MessageBox.Show("Select USB device")
            Return
        End If

        Dim Instance As String = lvDevices.SelectedItems(0).Text
        Dim Res As Int32
        If Enable Then
            Res = FMonitor.EnableUsbDevice(Instance)
        Else
            Res = FMonitor.DisableUsbDevice(Instance)
        End If
        If Res <> wclErrors.WCL_E_SUCCESS Then
            If Enable Then
                MessageBox.Show("Error enabling USB: 0x" + Res.ToString("X8"))
                Return
            End If
            MessageBox.Show("Error disabling USB: 0x" + Res.ToString("X8"))
            Return
        End If

        If Enable Then
            MessageBox.Show("Device enabled")
            Return
        End If
        MessageBox.Show("Device disabled")
    End Sub

    Private Sub FMonitor_OnUsbDeviceRemoved(Sender As Object, Instance As String) Handles FMonitor.OnUsbDeviceRemoved
        lbLog.Items.Add("Device removed: " + Instance)
    End Sub

    Private Sub FMonitor_OnUsbDeviceAdded(Sender As Object, Instance As String) Handles FMonitor.OnUsbDeviceAdded
        lbLog.Items.Add("Device added: " + Instance)
    End Sub

    Private Sub FMonitor_OnSerialDeviceRemoved(Sender As Object, DeviceName As String) Handles FMonitor.OnSerialDeviceRemoved
        lbLog.Items.Add("Device removed: " + DeviceName)
    End Sub

    Private Sub FMonitor_OnSerialDeviceAdded(Sender As Object, DeviceName As String) Handles FMonitor.OnSerialDeviceAdded
        lbLog.Items.Add("Device added: " + DeviceName)
    End Sub

    Private Sub FMonitor_OnStarted(sender As Object, e As EventArgs) Handles FMonitor.OnStarted
        lbLog.Items.Add("Monitor stopped")
    End Sub

    Private Sub FMonitor_OnStopped(sender As Object, e As EventArgs) Handles FMonitor.OnStopped
        lbLog.Items.Add("Monitor started")
    End Sub
End Class
