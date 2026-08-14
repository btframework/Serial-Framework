using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using wclCommon;
using wclSerialFramework;

namespace SerialClient
{
    public partial class fmMain : Form
    {
        private wclSerialClient FClient;
        private wclSerialMonitor FMonitor;

        private Int32 DtrControlToIndex(wclSerialDtrControl Control)
        {
            switch (Control)
            {
                case wclSerialDtrControl.dtrControlDisable:
                    return 0;
                case wclSerialDtrControl.dtrControlEnable:
                    return 1;
                case wclSerialDtrControl.dtrControlHandshake:
                    return 2;
                default:
                    return -1;
            }
        }

        private wclSerialDtrControl IndexToDtrControl(Int32 Index)
        {
            switch (Index)
            {
                case 0:
                    return wclSerialDtrControl.dtrControlDisable;
                case 1:
                    return wclSerialDtrControl.dtrControlEnable;
                case 2:
                    return wclSerialDtrControl.dtrControlHandshake;
                default:
                    return wclSerialDtrControl.dtrControlDisable;
            }
        }

        private Int32 RtsControlToIndex(wclSerialRtsControl Control)
        {
            switch (Control)
            {
                case wclSerialRtsControl.rtsControlDisable:
                    return 0;
                case wclSerialRtsControl.rtsControlEnable:
                    return 1;
                case wclSerialRtsControl.rtsControlHandshake:
                    return 2;
                case wclSerialRtsControl.rtsControlToggle:
                    return 3;
                default:
                    return -1;
            }
        }

        private wclSerialRtsControl IndexToRtsControl(Int32 Index)
        {
            switch (Index)
            {
                case 0:
                    return wclSerialRtsControl.rtsControlDisable;
                case 1:
                    return wclSerialRtsControl.rtsControlEnable;
                case 2:
                    return wclSerialRtsControl.rtsControlHandshake;
                case 3:
                    return wclSerialRtsControl.rtsControlToggle;
                default:
                    return wclSerialRtsControl.rtsControlDisable;
            }
        }

        private Int32 ParityToIndex(wclSerialParity Parity)
        {
            switch (Parity)
            {
                case wclSerialParity.spNo:
                    return 0;
                case wclSerialParity.spOdd:
                    return 1;
                case wclSerialParity.spEven:
                    return 2;
                case wclSerialParity.spMark:
                    return 3;
                case wclSerialParity.spSpace:
                    return 4;
                default:
                    return -1;
            }
        }

        private wclSerialParity IndexToParity(Int32 Index)
        {
            switch (Index)
            {
                case 0:
                    return wclSerialParity.spNo;
                case 1:
                    return wclSerialParity.spOdd;
                case 2:
                    return wclSerialParity.spEven;
                case 3:
                    return wclSerialParity.spMark;
                case 4:
                    return wclSerialParity.spSpace;
                default:
                    return wclSerialParity.spNo;
            }
        }

        private Int32 StopBitsToIndex(wclSerialStopBits StopBits)
        {
            switch (StopBits)
            {
                case wclSerialStopBits.sbOne:
                    return 0;
                case wclSerialStopBits.sbOne5:
                    return 1;
                case wclSerialStopBits.sbTwo:
                    return 2;
                default:
                    return -1;
            }
        }

        private wclSerialStopBits IndexToStopBits(Int32 Index)
        {
            switch (Index)
            {
                case 0:
                    return wclSerialStopBits.sbOne;
                case 1:
                    return wclSerialStopBits.sbOne5;
                case 2:
                    return wclSerialStopBits.sbTwo;
                default:
                    return wclSerialStopBits.sbOne;
            }
        }

        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMainLoad(Object sender, EventArgs e)
        {
            FClient = new wclSerialClient();
            FClient.OnConnect += ClientConnect;
            FClient.OnData += ClientData;
            FClient.OnDisconnect += ClientDisconnect;
            FClient.OnError += ClientError;
            FClient.OnReadError += ClientReadError;
            FClient.OnEvents += ClientEvents;

            FMonitor = new wclSerialMonitor();

            EnumComPorts();

            ClearConfig();
            ClearTimeouts();
            ClearBuffers();

            edWriteTimeout.Text = FClient.WriteTimeout.ToString();
            cbFunc.SelectedIndex = 0;
            cbLineFeed.SelectedIndex = 0;
        }

        private void fmMainClosed(Object sender, FormClosedEventArgs e)
        {
            FClient.Disconnect();
            FMonitor.Stop();
        }

        private void btClearClick(Object sender, EventArgs e)
        {
            lbEvents.Items.Clear();
        }

        private void ReadConfiguration()
        {
            wclSerialConfig Config;
            Int32 Res = FClient.GetConfig(out Config);
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Read configuration error: 0x" + Res.ToString("X8"));
            else
            {
                edBaudRate.Text = Config.BaudRate.ToString();
                edXonLim.Text = Config.XonLim.ToString();
                edXoffLim.Text = Config.XoffLim.ToString();
                edXonChar.Text = Config.XonChar.ToString();
                edXoffChar.Text = Config.XoffChar.ToString();
                edErrorChar.Text = Config.ErrorChar.ToString();
                edEofChar.Text = Config.EofChar.ToString();
                edEvtChar.Text = Config.EvtChar.ToString();

                cbParityCheck.Checked = Config.ParityCheck;
                cbOutxCtsFlow.Checked = Config.OutxCtsFlow;
                cbOutxDsrFlow.Checked = Config.OutxDsrFlow;
                cbDsrSensitivity.Checked = Config.DsrSensitivity;
                cbTXContinueOnXoff.Checked = Config.TxContinueOnXoff;
                cbOutX.Checked = Config.OutX;
                cbInX.Checked = Config.InX;
                cbErrorCharReplace.Checked = Config.ErrorCharReplace;
                cbNullStrip.Checked = Config.NullStrip;
                cbAbortOnError.Checked = Config.AbortOnError;

                cbRtsControl.SelectedIndex = RtsControlToIndex(Config.RtsControl);
                cbDtrControl.SelectedIndex = DtrControlToIndex(Config.DtrControl);
                cbParity.SelectedIndex = ParityToIndex(Config.Parity);
                cbStopBits.SelectedIndex = StopBitsToIndex(Config.StopBits);
                cbByteSize.SelectedIndex = Config.ByteSize - 4;
            }
        }

        private void ReadTimeouts()
        {
            wclSerialTimeouts Times;
            Int32 Res = FClient.GetTimeouts(out Times);
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Get timeouts error: 0x" + Res.ToString("X8"));
            else
            {
                edReadInterval.Text = Times.ReadInterval.ToString();
                edReadMultiplier.Text = Times.ReadMultiplier.ToString();
                edReadConstant.Text = Times.ReadConstant.ToString();
                edWriteMultiplier.Text = Times.WriteMultiplier.ToString();
                edWriteConstant.Text = Times.WriteConstant.ToString();
            }
        }

        private void btEnumClick(Object sender, EventArgs e)
        {
            EnumComPorts();
        }

        private void EnumComPorts()
        {
            cbPorts.Items.Clear();

            List<wclSerialDevice> Ports;
            Int32 Res = FMonitor.EnumSerialDevices(out Ports);
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Error enumerating COM ports: 0x" + Res.ToString("X8"));
            else
            {
                if (Ports.Count > 0)
                {
                    foreach (wclSerialDevice Port in Ports)
                        cbPorts.Items.Add(Port.DeviceName);
                }

                if (cbPorts.Items.Count > 0)
                    cbPorts.SelectedIndex = 0;
                else
                    cbPorts.SelectedIndex = -1;
            }
        }

        private void btConnectClick(Object sender, EventArgs e)
        {
            if (cbPorts.SelectedIndex == -1)
                MessageBox.Show("Select COM port");
            else
            {
                Int32 Res = FClient.Connect(cbPorts.Items[cbPorts.SelectedIndex].ToString());
                if (Res != wclErrors.WCL_E_SUCCESS)
                    MessageBox.Show("Error: 0x" + Res.ToString("X8"));
            }
        }

        private void btDisconnectClick(Object sender, EventArgs e)
        {
            Int32 Res = FClient.Disconnect();
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X8"));
        }

        private void ClearConfig()
        {
            edBaudRate.Text = "";
            edXonLim.Text = "";
            edXoffLim.Text = "";
            edXonChar.Text = "";
            edXoffChar.Text = "";
            edErrorChar.Text = "";
            edEofChar.Text = "";
            edEvtChar.Text = "";

            cbParityCheck.Checked = false;
            cbOutxCtsFlow.Checked = false;
            cbOutxDsrFlow.Checked = false;
            cbDsrSensitivity.Checked = false;
            cbTXContinueOnXoff.Checked = false;
            cbOutX.Checked = false;
            cbInX.Checked = false;
            cbErrorCharReplace.Checked = false;
            cbNullStrip.Checked = false;
            cbAbortOnError.Checked = false;

            cbRtsControl.SelectedIndex = -1;
            cbDtrControl.SelectedIndex = -1;
            cbByteSize.SelectedIndex = -1;
            cbParity.SelectedIndex = -1;
            cbStopBits.SelectedIndex = -1;
        }

        private void btSetConfigClick(Object sender, EventArgs e)
        {
            wclSerialConfig Config = new wclSerialConfig();

            Config.BaudRate = Convert.ToUInt32(edBaudRate.Text);
            Config.XonLim = Convert.ToUInt16(edXonLim.Text);
            Config.XoffLim = Convert.ToUInt16(edXoffLim.Text);
            Config.XonChar = Convert.ToByte(edXonChar.Text);
            Config.XoffChar = Convert.ToByte(edXoffChar.Text);
            Config.ErrorChar = Convert.ToByte(edErrorChar.Text);
            Config.EofChar = Convert.ToByte(edEofChar.Text);
            Config.EvtChar = Convert.ToByte(edEvtChar.Text);

            Config.ParityCheck = cbParityCheck.Checked;
            Config.OutxCtsFlow = cbOutxCtsFlow.Checked;
            Config.OutxDsrFlow = cbOutxDsrFlow.Checked;
            Config.DsrSensitivity = cbDsrSensitivity.Checked;
            Config.TxContinueOnXoff = cbTXContinueOnXoff.Checked;
            Config.OutX = cbOutX.Checked;
            Config.InX = cbInX.Checked;
            Config.ErrorCharReplace = cbErrorCharReplace.Checked;
            Config.NullStrip = cbNullStrip.Checked;
            Config.AbortOnError = cbAbortOnError.Checked;

            Config.RtsControl = IndexToRtsControl(cbRtsControl.SelectedIndex);
            Config.DtrControl = IndexToDtrControl(cbDtrControl.SelectedIndex);
            Config.Parity = IndexToParity(cbParity.SelectedIndex);
            Config.StopBits = IndexToStopBits(cbStopBits.SelectedIndex);
            Config.ByteSize = (Byte)(cbByteSize.SelectedIndex + 4);

            Int32 Res = FClient.SetConfig(Config);
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X8"));
        }

        private void btGetConfigClick(Object sender, EventArgs e)
        {
            ReadConfiguration();
        }

        private void ClearBuffers()
        {
            edReadBufferSize.Text = "";
            edWriteBufferSize.Text = "";
        }

        private void ClearTimeouts()
        {
            edReadInterval.Text = "";
            edReadMultiplier.Text = "";
            edReadConstant.Text = "";
            edWriteMultiplier.Text = "";
            edWriteConstant.Text = "";
        }

        private void ReadBuffers()
        {
            UInt32 Size;
            Int32 Res = FClient.GetReadBufferSize(out Size);
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Get read buffer size error: 0x" + Res.ToString("X8"));
            else
                edReadBufferSize.Text = Size.ToString();

            Res = FClient.GetWriteBufferSize(out Size);
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Get write buffer size error: 0x" + Res.ToString("X8"));
            else
                edWriteBufferSize.Text = Size.ToString();
        }

        private void btGetBuffersClick(Object sender, EventArgs e)
        {
            ReadBuffers();
        }

        private void btSetBuffersClick(Object sender, EventArgs e)
        {
            Int32 Res = FClient.SetReadBufferSize(Convert.ToUInt32(edReadBufferSize.Text));
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Set read buffer size error: 0x" + Res.ToString("X8"));

            Res = FClient.SetWriteBufferSize(Convert.ToUInt32(edWriteBufferSize.Text));
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Set write buffer size error: 0x" + Res.ToString("X8"));
        }

        private void btGetTimeoutsClick(Object sender, EventArgs e)
        {
            ReadTimeouts();
        }

        private void btSetTimeoutsClick(Object sender, EventArgs e)
        {
            wclSerialTimeouts Times;
            Times.ReadInterval = Convert.ToUInt32(edReadInterval.Text);
            Times.ReadMultiplier = Convert.ToUInt32(edReadMultiplier.Text);
            Times.ReadConstant = Convert.ToUInt32(edReadConstant.Text);
            Times.WriteMultiplier = Convert.ToUInt32(edWriteMultiplier.Text);
            Times.WriteConstant = Convert.ToUInt32(edWriteConstant.Text);
            Int32 Res = FClient.SetTimeouts(Times);
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Set timeouts error: 0x" + Res.ToString("X8"));
        }

        private void btClearCommBreakClick(Object sender, EventArgs e)
        {
            Int32 Res = FClient.ClearCommBreak();
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X8"));
        }

        private void btSetCommBreakClick(Object sender, EventArgs e)
        {
            Int32 Res = FClient.SetCommBreak();
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X8"));
        }

        private void btFlushBuffersClick(Object sender, EventArgs e)
        {
            Int32 Res = FClient.FlushBuffers();
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X8"));
        }

        private void btFuncClick(Object sender, EventArgs e)
        {
            Int32 Res = FClient.EscapeCommFunction((wclSerialEscapeFunction)cbFunc.SelectedIndex);
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X8"));
        }

        private void btPurgeClick(Object sender, EventArgs e)
        {
            wclSerialPurgeFlag Flags = 0;
            if (cbPurgeRxAbort.Checked)
                Flags |= wclSerialPurgeFlag.purgeRxAbort;
            if (cbPurgeRxClear.Checked)
                Flags |= wclSerialPurgeFlag.purgeRxClear;
            if (cbPurgeTxAbort.Checked)
                Flags |= wclSerialPurgeFlag.purgeTxAbort;
            if (cbPurgeTxClear.Checked)
                Flags |= wclSerialPurgeFlag.purgeTxClear;

            Int32 Res = FClient.PurgeComm(Flags);
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X"));
        }

        private void btTransmitClick(Object sender, EventArgs e)
        {
            Int32 Res = FClient.TransmitCommChar(Convert.ToByte(edChar.Text));
            if (Res != wclErrors.WCL_E_SUCCESS)
                MessageBox.Show("Error: 0x" + Res.ToString("X8"));
        }

        private void btSendClick(Object sender, EventArgs e)
        {
            String Str = edText.Text;
            switch (cbLineFeed.SelectedIndex)
            {
                case 1:
                    Str += "\r";
                    break;
                case 2:
                    Str += "\n";
                    break;
                case 3:
                    Str += "\r\n";
                    break;
            }
            Byte[] Ansi = Encoding.ASCII.GetBytes(Str);
            UInt32 Sent = 0;
            Int32 Res = FClient.Write(Ansi, out Sent);
            lbEvents.Items.Add("Sent: " + Sent.ToString() + " bytes from " + Ansi.Length.ToString());
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbEvents.Items.Add("Write error: 0x" + Res.ToString("X8"));
        }

        private void btSetWriteTimeoutClick(Object sender, EventArgs e)
        {
            FClient.WriteTimeout = Convert.ToUInt32(edWriteTimeout.Text);
        }

        private void ClientConnect(Object sender, Int32 Error)
        {
            if (Error == wclErrors.WCL_E_SUCCESS)
            {
                lbEvents.Items.Add("Connected to Serial Device: " + FClient.DeviceName);

                ReadConfiguration();
                ReadTimeouts();
                ReadBuffers();
            }
            else
                lbEvents.Items.Add("Connect error: 0x" + Error.ToString("X8"));
        }

        private void ClientData(Object sender, Byte[] Data)
        {
            if (Data != null && Data.Length > 0)
            {
                String Str = Encoding.ASCII.GetString(Data);
                lbEvents.Items.Add("Received: " + Str);
            }
            else
                lbEvents.Items.Add("Empty data received");
        }

        private void ClientDisconnect(Object sender, Int32 Reason)
        {
            lbEvents.Items.Add("Disconnected: 0x" + Reason.ToString("X8"));

            ClearConfig();
            ClearTimeouts();
            ClearBuffers();
        }

        private void ClientError(Object sender, wclSerialError Errors,
            wclSerialCommunicationState States)
        {
            String Str = "";
            if ((Errors & wclSerialError.erBreak) != 0)
                Str += "erBreak ";
            if ((Errors & wclSerialError.erFrame) != 0)
                Str += "erFrame ";
            if ((Errors & wclSerialError.erOverrun) != 0)
                Str += "erOverrun ";
            if ((Errors & wclSerialError.erRxOver) != 0)
                Str += "erRxOver ";
            if ((Errors & wclSerialError.erRxParity) != 0)
                Str += "erRxParity ";
            lbEvents.Items.Add("Error: " + Str);

            Str = "";
            if ((States & wclSerialCommunicationState.csCtsHold) != 0)
                Str += "csCtsHold ";
            if ((States & wclSerialCommunicationState.csDsrHold) != 0)
                Str += "csDsrHold ";
            if ((States & wclSerialCommunicationState.csRlsdHold) != 0)
                Str += "csRlsdHold ";
            if ((States & wclSerialCommunicationState.csXoffHold) != 0)
                Str += "csXoffHold ";
            if ((States & wclSerialCommunicationState.csXoffSent) != 0)
                Str += "csXoffSent ";
            if ((States & wclSerialCommunicationState.csEof) != 0)
                Str += "csEof ";
            if ((States & wclSerialCommunicationState.csTxim) != 0)
                Str += "csTxim ";
            lbEvents.Items.Add("States: " + Str);
        }

        private void ClientReadError(Object sender, Int32 Error)
        {
            lbEvents.Items.Add("Read error: 0x" + Error.ToString("X8"));
        }

        private void ClientEvents(Object sender, wclSerialEvent Events)
        {
            String Str = "";
            if ((Events & wclSerialEvent.evBreak) != 0)
                Str += "evBreak ";
            if ((Events & wclSerialEvent.evCts) != 0)
                Str += "evCts ";
            if ((Events & wclSerialEvent.evDsr) != 0)
                Str += "evDsr ";
            if ((Events & wclSerialEvent.evRing) != 0)
                Str += "evRing ";
            if ((Events & wclSerialEvent.evRlsd) != 0)
                Str += "evRlsd ";
            if ((Events & wclSerialEvent.evChar) != 0)
                Str += "evChar ";
            lbEvents.Items.Add("Event: " + Str);

            if (Events != 0)
            {
                wclModemStatus Status;
                Int32 Res = FClient.GetModemStatus(out Status);
                if (Res != wclErrors.WCL_E_SUCCESS)
                    lbEvents.Items.Add("GetModemStatus error: 0x" + Res.ToString("X8"));
                else
                {
                    Str = "";
                    if ((Status & wclModemStatus.msCtsOn) != 0)
                        Str += "msCtsOn ";
                    if ((Status & wclModemStatus.msDsrOn) != 0)
                        Str += "msDsrOn ";
                    if ((Status & wclModemStatus.msRingOn) != 0)
                        Str += "msRingOn ";
                    if ((Status & wclModemStatus.msDsrOn) != 0)
                        Str += "msDsrOn ";
                    if ((Status & wclModemStatus.msRlsdOn) != 0)
                        Str += "msRlsdOn ";
                    if (Str != "")
                        lbEvents.Items.Add("Modem status: " + Str);
                }
            }
        }
    };
}
