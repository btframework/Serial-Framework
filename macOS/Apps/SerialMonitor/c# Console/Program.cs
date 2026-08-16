using System;
using System.Collections.Generic;

using wclCommon;
using wclSerialFramework;

namespace SerialMonitor
{
    internal class Program
    {
        private static wclSerialMonitor FMonitor;

        private static void EnumUsbDevices()
        {
            Console.WriteLine("\tEnumerating USB devices");

            List<wclUsbDevice> Devices;
            Int32 Res = FMonitor.EnumUsbDevices(out Devices);
            if (Res != wclErrors.WCL_E_SUCCESS)
            {
                Console.WriteLine("\t\tEnumerate USB devices failed: 0x" + Res.ToString("X8"));
                return;
            }

            if (Devices == null || Devices.Count == 0)
            {
                Console.WriteLine("\t\tNo USB devices found");
                return;
            }

            Console.WriteLine("\t\tFound " + Devices.Count.ToString() + " USD devices");
            UInt32 Ndx = 1;
            foreach (wclUsbDevice Device in Devices)
            {
                Console.WriteLine("\t\tDevice " + Ndx.ToString());

                Console.WriteLine("\t\t\tInstance: " + Device.Instance);
                Console.WriteLine("\t\t\tFriendly name: " + Device.FriendlyName);
                Console.WriteLine("\t\t\tVID: " + Device.VendorId.ToString("X4"));
                Console.WriteLine("\t\t\tPID: " + Device.ProductId.ToString("X4"));
                Console.WriteLine("\t\t\tClass: " + Device.ClassGuid.ToString());
                Console.WriteLine("\t\t\tManufacturer: " + Device.Manufacturer);
                Console.WriteLine("\t\t\tEnabled: " + Device.Enabled.ToString());

                Ndx++;
            }
        }

        private static void EnumSerialDevices()
        {
            Console.WriteLine("\tEnumerating Serial devices");

            List<wclSerialDevice> Devices;
            Int32 Res = FMonitor.EnumSerialDevices(out Devices);
            if (Res != wclErrors.WCL_E_SUCCESS)
            {
                Console.WriteLine("\t\tEnumerate Serial devices failed: 0x" + Res.ToString("X8"));
                return;
            }

            if (Devices == null || Devices.Count == 0)
            {
                Console.WriteLine("\t\tNo Serial devices found");
                return;
            }

            Console.WriteLine("\t\tFound " + Devices.Count.ToString() + " Serial devices");
            UInt32 Ndx = 1;
            foreach (wclSerialDevice Device in Devices)
            {
                Console.WriteLine("\t\tDevice " + Ndx.ToString());

                Console.WriteLine("\t\t\tDevice name: " + Device.DeviceName);
                Console.WriteLine("\t\t\tFriendly name: " + Device.FriendlyName);
                Console.WriteLine("\t\t\tModem: " + Device.IsModem.ToString());

                Ndx++;
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();

            FMonitor = new wclSerialMonitor();
            FMonitor.OnStarted += MonitorStarted;
            FMonitor.OnStopped += MonitorStopped;
            FMonitor.OnSerialDeviceAdded += MonitorSerialDeviceAdded;
            FMonitor.OnSerialDeviceRemoved += MonitorSerialDeviceRemoved;
            FMonitor.OnUsbDeviceAdded += MonitorUsbDeviceAdded;
            FMonitor.OnUsbDeviceRemoved += MonitorUsbDeviceRemoved;

            EnumUsbDevices();
            EnumSerialDevices();

            Console.WriteLine("Starting devices monitoring");
            Int32 Res = FMonitor.Start(wclMessageProcessingMethod.mpAsync);
            if (Res != wclErrors.WCL_E_SUCCESS)
                Console.WriteLine("Start monitoring failed: 0x" + Res.ToString("X8"));
            else
            {
                Console.WriteLine("Press ENTER to stop");
                Console.ReadLine();

                Console.WriteLine("Stopping devices monitoring");
                Res = FMonitor.Stop();
                if (Res != wclErrors.WCL_E_SUCCESS)
                    Console.WriteLine("Stop monitoring failed: 0x" + Res.ToString("X8"));
            }

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        private static void MonitorUsbDeviceRemoved(Object Sender, String Instance)
        {
            Console.WriteLine("USB device removed: " + Instance);
            EnumUsbDevices();
        }

        private static void MonitorUsbDeviceAdded(Object Sender, String Instance)
        {
            Console.WriteLine("USB device added: " + Instance);
            EnumUsbDevices();
        }

        private static void MonitorSerialDeviceRemoved(Object Sender, String DeviceName)
        {
            Console.WriteLine("Serial device removed: " + DeviceName);
            EnumSerialDevices();
        }

        private static void MonitorSerialDeviceAdded(Object Sender, String DeviceName)
        {
            Console.WriteLine("Serial device added: " + DeviceName);
            EnumSerialDevices();
        }

        private static void MonitorStopped(Object sender, EventArgs e)
        {
            Console.WriteLine("Monitoring stopped");
        }

        private static void MonitorStarted(Object sender, EventArgs e)
        {
            Console.WriteLine("Monitoring started");
        }
    }
}
