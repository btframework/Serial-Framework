using System;
using System.Windows.Forms;

using wclCommon;

namespace PowerEvents
{
    public partial class fmMain : Form
    {
        private wclPowerEventsMonitor FMonitor;

        private void PowerStateChanged(Object Sender, wclPowerState State)
        {
            switch (State)
            {
                case wclPowerState.psPowerStatusChanged:
                    lbLog.Items.Add("Power status changed");
                    break;
                case wclPowerState.psResumeAutomatic:
                    lbLog.Items.Add("Resumed");
                    break;
                case wclPowerState.psResume:
                    lbLog.Items.Add("Resumed by user");
                    break;
                case wclPowerState.psSuspend:
                    lbLog.Items.Add("Suspended");
                    break;
                case wclPowerState.psUnknown:
                    lbLog.Items.Add("Unknonw");
                    break;
            }
        }

        private void MonitorStarted(Object Sender, EventArgs e)
        {
            lbLog.Items.Add("Monitor started");
        }

        private void MonitorStopped(Object Sender, EventArgs e)
        {
            lbLog.Items.Add("Monitor stopped");
        }

        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            FMonitor = new wclPowerEventsMonitor();
            FMonitor.OnPowerStateChanged += PowerStateChanged;
            FMonitor.OnStarted += MonitorStarted;
            FMonitor.OnStopped += MonitorStopped;
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            FMonitor.Stop();
            FMonitor = null;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            Int32 Res = FMonitor.Start();
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbLog.Items.Add("Start failed: 0x" + Res.ToString("X8"));
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            Int32 Res = FMonitor.Stop();
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbLog.Items.Add("Stop failed: 0x" + Res.ToString("X8"));
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            wclPowerStatus Status;
            if (!FMonitor.GetPowerStatus(out Status))
                lbLog.Items.Add("Get status failed");
            else
            {
                switch (Status.ACLineStatus)
                {
                    case wclACLineStatus.lsOffline:
                        lbLog.Items.Add("AC: Offline");
                        break;
                    case wclACLineStatus.lsOnline:
                        lbLog.Items.Add("AC: Online");
                        break;
                    case wclACLineStatus.lsBackup:
                        lbLog.Items.Add("AC: Backup");
                        break;
                    case wclACLineStatus.lsUnknown:
                        lbLog.Items.Add("AC: Unknown");
                        break;
                }

                String Str = "[";
                if ((wclBatteryChargeStatus.csCapacityHigh & Status.BatteryChargeStatus) != 0)
                    Str += " csCapacityHigh";
                if ((wclBatteryChargeStatus.csCapacityLow & Status.BatteryChargeStatus) != 0)
                    Str += " csCapacityLow";
                if ((wclBatteryChargeStatus.csCapacityCritical & Status.BatteryChargeStatus) != 0)
                    Str += " csCapacityCritical";
                if ((wclBatteryChargeStatus.csCharging & Status.BatteryChargeStatus) != 0)
                    Str += " csCharging";
                if ((wclBatteryChargeStatus.csNoSystemBattery & Status.BatteryChargeStatus) != 0)
                    Str += " csNoSystemBattery";
                Str += " ]";
                lbLog.Items.Add("Batt: " + Str);

                lbLog.Items.Add("Batt percent: " + Status.BatteryLifePercent.ToString());

                if (Status.BatterySavingState)
                    lbLog.Items.Add("Battery saving");

                if (Status.BatteryLifeTime != UInt32.MaxValue)
                    lbLog.Items.Add("Batt life: " + Status.BatteryLifeTime.ToString());

                if (Status.BatteryFullLifeTime != UInt32.MaxValue)
                    lbLog.Items.Add("Batt full life: " + Status.BatteryFullLifeTime.ToString());
            }
        }
    }
}
