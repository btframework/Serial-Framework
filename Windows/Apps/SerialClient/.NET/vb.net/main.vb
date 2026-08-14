Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class fmMain
    Private WithEvents FClient As wclSerialClient
    Private FMonitor As wclSerialMonitor

    Private Function DtrControlToIndex(Control As wclSerialDtrControl) As Int32
        Select Case Control
            Case wclSerialDtrControl.dtrControlDisable
                Return 0
            Case wclSerialDtrControl.dtrControlEnable
                Return 1
            Case wclSerialDtrControl.dtrControlHandshake
                Return 2
            Case Else
                Return -1
        End Select
    End Function

    Private Function IndexToDtrControl(Index As Int32) As wclSerialDtrControl
        Select Case Index
            Case 0
                Return wclSerialDtrControl.dtrControlDisable
            Case 1
                Return wclSerialDtrControl.dtrControlEnable
            Case 2
                Return wclSerialDtrControl.dtrControlHandshake
            Case Else
                Return wclSerialDtrControl.dtrControlDisable
        End Select
    End Function

    Private Function RtsControlToIndex(Control As wclSerialRtsControl) As Int32
        Select Case Control
            Case wclSerialRtsControl.rtsControlDisable
                Return 0
            Case wclSerialRtsControl.rtsControlEnable
                Return 1
            Case wclSerialRtsControl.rtsControlHandshake
                Return 2
            Case wclSerialRtsControl.rtsControlToggle
                Return 3
            Case Else
                Return -1
        End Select
    End Function

    Private Function IndexToRtsControl(Index As Int32) As wclSerialRtsControl
        Select Case Index
            Case 0
                Return wclSerialRtsControl.rtsControlDisable
            Case 1
                Return wclSerialRtsControl.rtsControlEnable
            Case 2
                Return wclSerialRtsControl.rtsControlHandshake
            Case 3
                Return wclSerialRtsControl.rtsControlToggle
            Case Else
                Return wclSerialRtsControl.rtsControlDisable
        End Select
    End Function

    Private Function ParityToIndex(Parity As wclSerialParity) As Int32
        Select Case Parity
            Case wclSerialParity.spNo
                Return 0
            Case wclSerialParity.spOdd
                Return 1
            Case wclSerialParity.spEven
                Return 2
            Case wclSerialParity.spMark
                Return 3
            Case wclSerialParity.spSpace
                Return 4
            Case Else
                Return -1
        End Select
    End Function

    Private Function IndexToParity(Index As Int32) As wclSerialParity
        Select Case Index
            Case 0
                Return wclSerialParity.spNo
            Case 1
                Return wclSerialParity.spOdd
            Case 2
                Return wclSerialParity.spEven
            Case 3
                Return wclSerialParity.spMark
            Case 4
                Return wclSerialParity.spSpace
            Case Else
                Return wclSerialParity.spNo
        End Select
    End Function

    Private Function StopBitsToIndex(StopBits As wclSerialStopBits) As Int32
        Select Case StopBits
            Case wclSerialStopBits.sbOne
                Return 0
            Case wclSerialStopBits.sbOne5
                Return 1
            Case wclSerialStopBits.sbTwo
                Return 2
            Case Else
                Return -1
        End Select
    End Function

    Private Function IndexToStopBits(Index As Int32) As wclSerialStopBits
        Select Case Index
            Case 0
                Return wclSerialStopBits.sbOne
            Case 1
                Return wclSerialStopBits.sbOne5
            Case 2
                Return wclSerialStopBits.sbTwo
            Case Else
                Return wclSerialStopBits.sbOne
        End Select
    End Function

    Private Sub fmMainLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        FClient = New wclSerialClient()
        FMonitor = New wclSerialMonitor()

        EnumComPorts()

        ClearConfig()
        ClearTimeouts()
        ClearBuffers()

        edWriteTimeout.Text = FClient.WriteTimeout.ToString()
        cbFunc.SelectedIndex = 0
        cbLineFeed.SelectedIndex = 0
    End Sub

    Private Sub fmMainClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FClient.Disconnect()
        FMonitor.Stop()
    End Sub

    Private Sub btClearClick(sender As Object, e As EventArgs) Handles btClear.Click
        lbEvents.Items.Clear()
    End Sub

    Private Sub ReadConfiguration()
        Dim Config As wclSerialConfig
        Dim Res As Int32 = FClient.GetConfig(Config)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Read configuration error: 0x" + Res.ToString("X8"))
        Else
            edBaudRate.Text = Config.BaudRate.ToString()
            edXonLim.Text = Config.XonLim.ToString()
            edXoffLim.Text = Config.XoffLim.ToString()
            edXonChar.Text = Config.XonChar.ToString()
            edXoffChar.Text = Config.XoffChar.ToString()
            edErrorChar.Text = Config.ErrorChar.ToString()
            edEofChar.Text = Config.EofChar.ToString()
            edEvtChar.Text = Config.EvtChar.ToString()

            cbParityCheck.Checked = Config.ParityCheck
            cbOutxCtsFlow.Checked = Config.OutxCtsFlow
            cbOutxDsrFlow.Checked = Config.OutxDsrFlow
            cbDsrSensitivity.Checked = Config.DsrSensitivity
            cbTXContinueOnXoff.Checked = Config.TxContinueOnXoff
            cbOutX.Checked = Config.OutX
            cbInX.Checked = Config.InX
            cbErrorCharReplace.Checked = Config.ErrorCharReplace
            cbNullStrip.Checked = Config.NullStrip
            cbAbortOnError.Checked = Config.AbortOnError

            cbRtsControl.SelectedIndex = RtsControlToIndex(Config.RtsControl)
            cbDtrControl.SelectedIndex = DtrControlToIndex(Config.DtrControl)
            cbParity.SelectedIndex = ParityToIndex(Config.Parity)
            cbStopBits.SelectedIndex = StopBitsToIndex(Config.StopBits)
            cbByteSize.SelectedIndex = Config.ByteSize - 4
        End If
    End Sub

    Private Sub ReadTimeouts()
        Dim Times As wclSerialTimeouts
        Dim Res As Int32 = FClient.GetTimeouts(Times)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Get timeouts error: 0x" + Res.ToString("X8"))
        Else
            edReadInterval.Text = Times.ReadInterval.ToString()
            edReadMultiplier.Text = Times.ReadMultiplier.ToString()
            edReadConstant.Text = Times.ReadConstant.ToString()
            edWriteMultiplier.Text = Times.WriteMultiplier.ToString()
            edWriteConstant.Text = Times.WriteConstant.ToString()
        End If
    End Sub

    Private Sub btEnumClick(sender As Object, e As EventArgs) Handles btEnum.Click
        EnumComPorts()
    End Sub

    Private Sub EnumComPorts()
        cbPorts.Items.Clear()

        Dim Ports As List(Of wclSerialDevice) = Nothing
        Dim Res As Int32 = FMonitor.EnumSerialDevices(Ports)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Error enumerating COM ports: 0x" + Res.ToString("X8"))
        Else
            If Ports.Count > 0 Then
                For Each Port As wclSerialDevice In Ports
                    cbPorts.Items.Add(Port.DeviceName)
                Next
            End If

            If cbPorts.Items.Count > 0 Then
                cbPorts.SelectedIndex = 0
            Else
                cbPorts.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub btConnectClick(sender As Object, e As EventArgs) Handles btConnect.Click
        If cbPorts.SelectedIndex = -1 Then
            MessageBox.Show("Select COM port")
        Else
            Dim Res As Int32 = FClient.Connect(cbPorts.Items(cbPorts.SelectedIndex).ToString())
            If Res <> wclErrors.WCL_E_SUCCESS Then
                MessageBox.Show("Error: 0x" + Res.ToString("X8"))
            End If
        End If
    End Sub

    Private Sub btDisconnect_Click(sender As Object, e As EventArgs) Handles btDisconnect.Click
        Dim Res As Int32 = FClient.Disconnect()
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub ClearConfig()
        edBaudRate.Text = ""
        edXonLim.Text = ""
        edXoffLim.Text = ""
        edXonChar.Text = ""
        edXoffChar.Text = ""
        edErrorChar.Text = ""
        edEofChar.Text = ""
        edEvtChar.Text = ""

        cbParityCheck.Checked = False
        cbOutxCtsFlow.Checked = False
        cbOutxDsrFlow.Checked = False
        cbDsrSensitivity.Checked = False
        cbTXContinueOnXoff.Checked = False
        cbOutX.Checked = False
        cbInX.Checked = False
        cbErrorCharReplace.Checked = False
        cbNullStrip.Checked = False
        cbAbortOnError.Checked = False

        cbRtsControl.SelectedIndex = -1
        cbDtrControl.SelectedIndex = -1
        cbByteSize.SelectedIndex = -1
        cbParity.SelectedIndex = -1
        cbStopBits.SelectedIndex = -1
    End Sub

    Private Sub btSetConfigClick(sender As Object, e As EventArgs) Handles btSetConfig.Click
        Dim Config As wclSerialConfig = New wclSerialConfig()

        Config.BaudRate = Convert.ToUInt32(edBaudRate.Text)
        Config.XonLim = Convert.ToUInt16(edXonLim.Text)
        Config.XoffLim = Convert.ToUInt16(edXoffLim.Text)
        Config.XonChar = Convert.ToByte(edXonChar.Text)
        Config.XoffChar = Convert.ToByte(edXoffChar.Text)
        Config.ErrorChar = Convert.ToByte(edErrorChar.Text)
        Config.EofChar = Convert.ToByte(edEofChar.Text)
        Config.EvtChar = Convert.ToByte(edEvtChar.Text)

        Config.ParityCheck = cbParityCheck.Checked
        Config.OutxCtsFlow = cbOutxCtsFlow.Checked
        Config.OutxDsrFlow = cbOutxDsrFlow.Checked
        Config.DsrSensitivity = cbDsrSensitivity.Checked
        Config.TxContinueOnXoff = cbTXContinueOnXoff.Checked
        Config.OutX = cbOutX.Checked
        Config.InX = cbInX.Checked
        Config.ErrorCharReplace = cbErrorCharReplace.Checked
        Config.NullStrip = cbNullStrip.Checked
        Config.AbortOnError = cbAbortOnError.Checked

        Config.RtsControl = IndexToRtsControl(cbRtsControl.SelectedIndex)
        Config.DtrControl = IndexToDtrControl(cbDtrControl.SelectedIndex)
        Config.Parity = IndexToParity(cbParity.SelectedIndex)
        Config.StopBits = IndexToStopBits(cbStopBits.SelectedIndex)
        Config.ByteSize = CType(cbByteSize.SelectedIndex + 4, Byte)

        Dim Res As Int32 = FClient.SetConfig(Config)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btGetConfigClick(sender As Object, e As EventArgs) Handles btGetConfig.Click
        ReadConfiguration()
    End Sub

    Private Sub ClearBuffers()
        edReadBufferSize.Text = ""
        edWriteBufferSize.Text = ""
    End Sub

    Private Sub ClearTimeouts()
        edReadInterval.Text = ""
        edReadMultiplier.Text = ""
        edReadConstant.Text = ""
        edWriteMultiplier.Text = ""
        edWriteConstant.Text = ""
    End Sub

    Private Sub ReadBuffers()
        Dim Size As UInt32
        Dim Res As Int32 = FClient.GetReadBufferSize(Size)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Get read buffer size error: 0x" + Res.ToString("X8"))
        Else
            edReadBufferSize.Text = Size.ToString()
        End If

        Res = FClient.GetWriteBufferSize(Size)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Get write buffer size error: 0x" + Res.ToString("X8"))
        Else
            edWriteBufferSize.Text = Size.ToString()
        End If
    End Sub

    Private Sub btGetBuffersClick(sender As Object, e As EventArgs) Handles btGetBuffers.Click
        ReadBuffers()
    End Sub

    Private Sub btSetBuffersClick(sender As Object, e As EventArgs) Handles btSetBuffers.Click
        Dim Res As Int32 = FClient.SetReadBufferSize(Convert.ToUInt32(edReadBufferSize.Text))
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Set read buffer size error: 0x" + Res.ToString("X8"))

            Res = FClient.SetWriteBufferSize(Convert.ToUInt32(edWriteBufferSize.Text))
            If Res <> wclErrors.WCL_E_SUCCESS Then
                lbEvents.Items.Add("Set write buffer size error: 0x" + Res.ToString("X8"))
            End If
        End If
    End Sub

    Private Sub btGetTimeoutsClick(sender As Object, e As EventArgs) Handles btGetTimeouts.Click
        ReadTimeouts()
    End Sub

    Private Sub btSetTimeoutsClick(sender As Object, e As EventArgs) Handles btSetTimeouts.Click
        Dim Times As wclSerialTimeouts
        Times.ReadInterval = Convert.ToUInt32(edReadInterval.Text)
        Times.ReadMultiplier = Convert.ToUInt32(edReadMultiplier.Text)
        Times.ReadConstant = Convert.ToUInt32(edReadConstant.Text)
        Times.WriteMultiplier = Convert.ToUInt32(edWriteMultiplier.Text)
        Times.WriteConstant = Convert.ToUInt32(edWriteConstant.Text)
        Dim Res As Int32 = FClient.SetTimeouts(Times)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Set timeouts error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btClearCommBreakClick(sender As Object, e As EventArgs) Handles btClearCommBreak.Click
        Dim Res As Int32 = FClient.ClearCommBreak()
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btSetCommBreakClick(sender As Object, e As EventArgs) Handles btSetCommBreak.Click
        Dim Res As Int32 = FClient.SetCommBreak()
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btFlushBuffersClick(sender As Object, e As EventArgs) Handles btFlushBuffers.Click
        Dim Res As Int32 = FClient.FlushBuffers()
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btFuncClick(sender As Object, e As EventArgs) Handles btFunc.Click
        Dim Res As Int32 = FClient.EscapeCommFunction(CType(cbFunc.SelectedIndex, wclSerialEscapeFunction))
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btPurgeClick(sender As Object, e As EventArgs) Handles btPurge.Click
        Dim Flags As wclSerialPurgeFlag = 0
        If cbPurgeRxAbort.Checked Then
            Flags += wclSerialPurgeFlag.purgeRxAbort
        End If
        If cbPurgeRxClear.Checked Then
            Flags += wclSerialPurgeFlag.purgeRxClear
        End If
        If cbPurgeTxAbort.Checked Then
            Flags += wclSerialPurgeFlag.purgeTxAbort
        End If
        If cbPurgeTxClear.Checked Then
            Flags += wclSerialPurgeFlag.purgeTxClear
        End If

        Dim Res As Int32 = FClient.PurgeComm(Flags)
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X"))
        End If
    End Sub

    Private Sub btTransmitClick(sender As Object, e As EventArgs) Handles btTransmit.Click
        Dim Res As Int32 = FClient.TransmitCommChar(Convert.ToByte(edChar.Text))
        If Res <> wclErrors.WCL_E_SUCCESS Then
            MessageBox.Show("Error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btSendClick(sender As Object, e As EventArgs) Handles btSend.Click
        Dim Str As String = edText.Text
        Select Case cbLineFeed.SelectedIndex
            Case 1
                Str += "\r"
            Case 2
                Str += "\n"
            Case 3
                Str += "\r\n"
        End Select
        Dim Ansi As Byte() = Encoding.ASCII.GetBytes(Str)
        Dim Sent As UInt32 = 0
        Dim Res As Int32 = FClient.Write(Ansi, Sent)
        lbEvents.Items.Add("Sent: " + Sent.ToString() + " bytes from " + Ansi.Length.ToString())
        If Res <> wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Write error: 0x" + Res.ToString("X8"))
        End If
    End Sub

    Private Sub btSetWriteTimeoutClick(sender As Object, e As EventArgs) Handles btSetWriteTimeout.Click
        FClient.WriteTimeout = Convert.ToUInt32(edWriteTimeout.Text)
    End Sub

    Private Sub ClientConnect(Sender As Object, [Error] As Integer) Handles FClient.OnConnect
        If [Error] = wclErrors.WCL_E_SUCCESS Then
            lbEvents.Items.Add("Connected to Serial Device: " + FClient.DeviceName)

            ReadConfiguration()
            ReadTimeouts()
            ReadBuffers()
        Else
            lbEvents.Items.Add("Connect error: 0x" + [Error].ToString("X8"))
        End If
    End Sub

    Private Sub ClientData(Sender As Object, Data() As Byte) Handles FClient.OnData
        If Data IsNot Nothing AndAlso Data.Length > 0 Then
            Dim Str As String = Encoding.ASCII.GetString(Data)
            lbEvents.Items.Add("Received: " + Str)
        Else
            lbEvents.Items.Add("Empty data received")
        End If
    End Sub

    Private Sub ClientDisconnect(Sender As Object, Reason As Integer) Handles FClient.OnDisconnect
        lbEvents.Items.Add("Disconnected: 0x" + Reason.ToString("X8"))

        ClearConfig()
        ClearTimeouts()
        ClearBuffers()
    End Sub

    Private Sub ClientError(Sender As Object, Errors As wclSerialError, States As wclSerialCommunicationState) Handles FClient.OnError
        Dim Str As String = ""
        If (Errors And wclSerialError.erBreak) <> 0 Then
            Str += "erBreak "
        End If
        If (Errors And wclSerialError.erFrame) <> 0 Then
            Str += "erFrame "
        End If
        If (Errors And wclSerialError.erOverrun) <> 0 Then
            Str += "erOverrun "
        End If
        If (Errors And wclSerialError.erRxOver) <> 0 Then
            Str += "erRxOver "
        End If
        If (Errors And wclSerialError.erRxParity) <> 0 Then
            Str += "erRxParity "
        End If
        lbEvents.Items.Add("Error: " + Str)

        Str = ""
        If (States And wclSerialCommunicationState.csCtsHold) <> 0 Then
            Str += "csCtsHold "
        End If
        If (States And wclSerialCommunicationState.csDsrHold) <> 0 Then
            Str += "csDsrHold "
        End If
        If (States And wclSerialCommunicationState.csRlsdHold) <> 0 Then
            Str += "csRlsdHold "
        End If
        If (States And wclSerialCommunicationState.csXoffHold) <> 0 Then
            Str += "csXoffHold "
        End If
        If (States And wclSerialCommunicationState.csXoffSent) <> 0 Then
            Str += "csXoffSent "
        End If
        If (States And wclSerialCommunicationState.csEof) <> 0 Then
            Str += "csEof "
        End If
        If (States And wclSerialCommunicationState.csTxim) <> 0 Then
            Str += "csTxim "
        End If
        lbEvents.Items.Add("States: " + Str)
    End Sub

    Private Sub ClientReadError(Sender As Object, [Error] As Integer) Handles FClient.OnReadError
        lbEvents.Items.Add("Read error: 0x" + [Error].ToString("X8"))
    End Sub

    Private Sub FClient_OnEvents(Sender As Object, Events As wclSerialEvent) Handles FClient.OnEvents
        Dim Str As String = ""
        If (Events And wclSerialEvent.evBreak) <> 0 Then
            Str += "evBreak "
        End If
        If (Events And wclSerialEvent.evCts) <> 0 Then
            Str += "evCts "
        End If
        If (Events And wclSerialEvent.evDsr) <> 0 Then
            Str += "evDsr "
        End If
        If (Events And wclSerialEvent.evRing) <> 0 Then
            Str += "evRing "
        End If
        If (Events And wclSerialEvent.evRlsd) <> 0 Then
            Str += "evRlsd "
        End If
        If (Events And wclSerialEvent.evChar) <> 0 Then
            Str += "evChar "
        End If
        lbEvents.Items.Add("Event: " + Str)

        If Events <> 0 Then
            Dim Status As wclModemStatus
            Dim Res As Int32 = FClient.GetModemStatus(Status)
            If Res <> wclErrors.WCL_E_SUCCESS Then
                lbEvents.Items.Add("GetModemStatus error: 0x" + Res.ToString("X8"))
            Else
                Str = ""
                If (Status And wclModemStatus.msCtsOn) <> 0 Then
                    Str += "msCtsOn "
                End If
                If (Status And wclModemStatus.msDsrOn) <> 0 Then
                    Str += "msDsrOn "
                End If
                If (Status And wclModemStatus.msRingOn) <> 0 Then
                    Str += "msRingOn "
                End If
                If (Status And wclModemStatus.msDsrOn) <> 0 Then
                    Str += "msDsrOn "
                End If
                If (Status And wclModemStatus.msRlsdOn) <> 0 Then
                    Str += "msRlsdOn "
                End If
                If Str <> "" Then
                    lbEvents.Items.Add("Modem status: " + Str)
                End If
            End If
        End If
    End Sub
End Class
