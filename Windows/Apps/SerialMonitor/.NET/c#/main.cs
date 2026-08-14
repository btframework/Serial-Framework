using System;
using System.Collections.Generic;
using System.Windows.Forms;

using wclCommon;
using wclSerialFramework;

namespace SerialMonitor
{
    public partial class fmMain : Form
    {
        private wclSerialMonitor FMonitor;

        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_FormClosed(Object sender, FormClosedEventArgs e)
        {
            FMonitor.Stop();
        }

        private void btClear_Click(Object sender, EventArgs e)
        {
            lbLog.Items.Clear();
        }

        private void btStart_Click(Object sender, EventArgs e)
        {
            Int32 Res = FMonitor.Start();
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbLog.Items.Add("Start failed: 0x" + Res.ToString("X8"));
        }

        private void btStop_Click(Object sender, EventArgs e)
        {
            Int32 Res = FMonitor.Stop();
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbLog.Items.Add("Stop failed: 0x" + Res.ToString("X8"));
        }

        private void btEnumSerial_Click(Object sender, EventArgs e)
        {
            lvDevices.Items.Clear();
            lvDevices.Columns.Clear();
            
            ColumnHeader Column = lvDevices.Columns.Add("Device name");
            Column.Width = 80;
            Column = lvDevices.Columns.Add("Friendly name");
            Column.Width = 350;
            Column = lvDevices.Columns.Add("IsModem");
            Column.Width = 70;

            List<wclSerialDevice> Devices;
            Int32 Res = FMonitor.EnumSerialDevices(out Devices);
            if (Res != wclErrors.WCL_E_SUCCESS)
            {
                lbLog.Items.Add("Enum serial devices failed: 0x" + Res.ToString("X8"));
                return;
            }

            if (Devices == null || Devices.Count == 0)
            {
                lbLog.Items.Add("No serial devices found");
                return;
            }
            
            lbLog.Items.Add("Found " + Devices.Count.ToString() + " serial devices");
            foreach (wclSerialDevice Device in Devices)
            {
                ListViewItem Item = lvDevices.Items.Add(Device.DeviceName);
                Item.SubItems.Add(Device.FriendlyName);
                Item.SubItems.Add(Device.IsModem.ToString());
            }
        }

        private void btEnumUsb_Click(Object sender, EventArgs e)
        {
            lvDevices.Items.Clear();
            lvDevices.Columns.Clear();

            ColumnHeader Column = lvDevices.Columns.Add("Instance");
            Column.Width = 250;
            Column = lvDevices.Columns.Add("Friendly name");
            Column.Width = 250;
            Column = lvDevices.Columns.Add("VID");
            Column.Width = 50;
            Column = lvDevices.Columns.Add("PID");
            Column.Width = 50;
            Column = lvDevices.Columns.Add("Class");
            Column.Width = 250;
            Column = lvDevices.Columns.Add("Manufacturer");
            Column.Width = 200;
            Column = lvDevices.Columns.Add("Enabled");
            Column.Width = 70;

            List<wclUsbDevice> Devices;
            Int32 Res = FMonitor.EnumUsbDevices(out Devices);
            if (Res != wclErrors.WCL_E_SUCCESS)
            {
                lbLog.Items.Add("Enum USB devices failed: 0x" + Res.ToString("X8"));
                return;
            }

            if (Devices == null || Devices.Count == 0)
            {
                lbLog.Items.Add("No USB devices found");
                return;
            }
            
            lbLog.Items.Add("Found " + Devices.Count.ToString() + " USB devices");
            foreach (wclUsbDevice Device in Devices)
            {
                ListViewItem Item = lvDevices.Items.Add(Device.Instance);
                Item.SubItems.Add(Device.FriendlyName);
                Item.SubItems.Add(Device.VendorId.ToString("X4"));
                Item.SubItems.Add(Device.ProductId.ToString("X4"));
                Item.SubItems.Add(Device.ClassGuid.ToString());
                Item.SubItems.Add(Device.Manufacturer);
                Item.SubItems.Add(Device.Enabled.ToString());
            }
        }

        private void btDisable_Click(Object sender, EventArgs e)
        {
            SwitchUsbDevice(false);
        }

        private void btEnable_Click(Object sender, EventArgs e)
        {
            SwitchUsbDevice(true);
        }

        private void SwitchUsbDevice(Boolean Enable)
        {
            if (lvDevices.Columns.Count < 7)
            {
                MessageBox.Show("Enumerate USB devices");
                return;
            }

            if (lvDevices.Items.Count == 0)
            {
                MessageBox.Show("No USB devices found");
                return;
            }

            if (lvDevices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select USB device");
                return;
            }

            String Instance = lvDevices.SelectedItems[0].Text;
            Int32 Res;
            if (Enable)
                Res = FMonitor.EnableUsbDevice(Instance);
            else
                Res = FMonitor.DisableUsbDevice(Instance);
            if (Res != wclErrors.WCL_E_SUCCESS)
            {
                if (Enable)
                {
                    MessageBox.Show("Error enabling USB: 0x" + Res.ToString("X8"));
                    return;
                }
                MessageBox.Show("Error disabling USB: 0x" + Res.ToString("X8"));
                return;
            }

            if (Enable)
            {
                MessageBox.Show("Device enabled");
                return;
            }
            MessageBox.Show("Device disabled");
        }

        private void fmMain_Load(Object sender, EventArgs e)
        {
            FMonitor = new wclSerialMonitor();
            FMonitor.OnStarted += MonitorStarted;
            FMonitor.OnStopped += MonitorStopped;
            FMonitor.OnSerialDeviceAdded += MonitorSerialDeviceAdded;
            FMonitor.OnSerialDeviceRemoved += MonitorSerialDeviceRemoved;
            FMonitor.OnUsbDeviceAdded += MonitorUsbDeviceAdded;
            FMonitor.OnUsbDeviceRemoved += MonitorUsbDeviceRemoved;
        }

        private void MonitorUsbDeviceRemoved(Object Sender, String Instance)
        {
            lbLog.Items.Add("Device removed: " + Instance);
        }

        private void MonitorUsbDeviceAdded(Object Sender, String Instance)
        {
            lbLog.Items.Add("Device added: " + Instance);
        }

        private void MonitorSerialDeviceRemoved(Object Sender, String DeviceName)
        {
            lbLog.Items.Add("Device removed: " + DeviceName);
        }

        private void MonitorSerialDeviceAdded(Object Sender, String DeviceName)
        {
            lbLog.Items.Add("Device added: " + DeviceName);
        }

        private void MonitorStopped(Object sender, EventArgs e)
        {
            lbLog.Items.Add("Monitor stopped");
        }

        private void MonitorStarted(Object sender, EventArgs e)
        {
            lbLog.Items.Add("Monitor started");
        }
    }
}
