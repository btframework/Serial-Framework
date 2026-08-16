using System;

using wclCommon;

class Program
{
    private static void MonitorStarted(Object sender, EventArgs e)
    {
        Console.WriteLine("Monitor started");
    }

    private static void MonitorStopped(Object sender, EventArgs e)
    {
        Console.WriteLine("Monitor stopped");
    }

     private static void PowerStateChanged(Object Sender, wclPowerState State)
    {
        switch (State)
        {
            case wclPowerState.psPowerStatusChanged:
                Console.WriteLine("Power status changed");
                break;
            case wclPowerState.psResumeAutomatic:
                Console.WriteLine("Resumed");
                break;
            case wclPowerState.psResume:
                Console.WriteLine("Resumed by user");
                break;
            case wclPowerState.psSuspend:
                Console.WriteLine("Suspended");
                break;
            case wclPowerState.psUnknown:
                Console.WriteLine("Unknonw");
                break;
        }
    }

    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("OS Version: ");
        Console.Write(wclOsVersion.OsType.ToString()); Console.Write("  ");
        Console.Write(wclOsVersion.Major.ToString()); Console.Write(".");
        Console.Write(wclOsVersion.Minor.ToString()); Console.Write(".");
        Console.WriteLine(wclOsVersion.Build.ToString());

        wclPowerEventsMonitor Monitor = new wclPowerEventsMonitor();
        Monitor.OnStarted += MonitorStarted;
        Monitor.OnStopped += MonitorStopped;
        Monitor.OnPowerStateChanged += PowerStateChanged;

        Console.WriteLine("Read power status");
        wclPowerStatus Status;
        if (!Monitor.GetPowerStatus(out Status))
            Console.WriteLine("Get power status failed");
        else
        {
            switch (Status.ACLineStatus)
            {
                case wclACLineStatus.lsOffline:
                    Console.WriteLine("AC: Offline");
                    break;
                case wclACLineStatus.lsOnline:
                    Console.WriteLine("AC: Online");
                    break;
                case wclACLineStatus.lsBackup:
                    Console.WriteLine("AC: Backup");
                    break;
                case wclACLineStatus.lsUnknown:
                    Console.WriteLine("AC: Unknown");
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
            Console.WriteLine("Batt: " + Str);

            Console.WriteLine("Batt percent: " + Status.BatteryLifePercent.ToString());

            if (Status.BatterySavingState)
                Console.WriteLine("Battery saving");

            if (Status.BatteryLifeTime != UInt32.MaxValue)
                Console.WriteLine("Batt life: " + Status.BatteryLifeTime.ToString());

            if (Status.BatteryFullLifeTime != UInt32.MaxValue)
                Console.WriteLine("Batt full life: " + Status.BatteryFullLifeTime.ToString());
        }

        Console.WriteLine("Start monitoring");
        Int32 Res = Monitor.Start(wclMessageProcessingMethod.mpAsync);
        if (Res != wclErrors.WCL_E_SUCCESS)
            Console.WriteLine("Start monitoring failed: 0x" + Res.ToString("X8"));
        else
        {
            Console.WriteLine("Press ENTER to stop");
            Console.ReadLine();

            Res = Monitor.Stop();
            if (Res != wclErrors.WCL_E_SUCCESS)
                Console.WriteLine("Stop monitoring failed: 0x" + Res.ToString("X8"));
        }

        Console.WriteLine("Press ENTER to exit");
        Console.ReadLine();
    }
}