using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

using wclCommon;
using wclCommunication;
using wclSerialFramework;

namespace SerialClient
{
    internal class Program
    {
        private static Boolean FDisconnectedByUser;
        private static wclSerialMonitor FMonitor;
        private static wclSerialClient FClient;

        private static String SelectDevice()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select device:");

                List<wclSerialDevice> Devices;
                Int32 Res = FMonitor.EnumSerialDevices(out Devices);
                if (Res == wclErrors.WCL_E_SUCCESS && Devices != null && Devices.Count > 0)
                {
                    for (Int32 i = 0; i < Devices.Count; i++)
                        Console.WriteLine(i.ToString() + " - " + Devices[i].DeviceName);
                }
                Console.WriteLine("---------------------------");
                Console.WriteLine("r - refresh");
                Console.WriteLine("e - exit");

                String c = Console.ReadLine();
                if (c == "e")
                    return "";
                if (c == "r")
                    continue;

                Int32 Ndx;
                try { Ndx = Convert.ToInt32(c); } catch { Ndx = -1; }
                if (Ndx < 0 || Ndx >= Devices.Count)
                    continue;
                return Devices[Ndx].DeviceName;
            }
        }

        static void Main(string[] args)
        {
            FDisconnectedByUser = false;

            FMonitor = new wclSerialMonitor();

            FClient = new wclSerialClient();
            FClient.OnConnect += ClientConnect;
            FClient.OnDisconnect += ClientDisconnect;
            FClient.OnData += ClientData;

            String DeviceName = SelectDevice();
            if (DeviceName == "")
                return;

            Console.WriteLine("Connecting...");
            Int32 Res = FClient.Connect(DeviceName, wclMessageProcessingMethod.mpAsync);
            if (Res != wclErrors.WCL_E_SUCCESS)
            {
                Console.WriteLine("Connect failed: 0x" + Res.ToString("X8"));
                return;
            }

            while (FClient.State != wclClientState.csConnected && FClient.State != wclClientState.csDisconnected)
                Thread.Sleep(1);
            if (FClient.State != wclClientState.csConnected)
                return;

            while (true)
            {
                String s = Console.ReadLine();
                if (s == "EXIT")
                {
                    FDisconnectedByUser = true;
                    FClient.Disconnect();
                    while (FClient.State != wclClientState.csDisconnected)
                        Thread.Sleep(1);
                    break;
                }
                if (s == "CHAR")
                {
                     Res = FClient.TransmitCommChar(65);
                    if (Res != wclErrors.WCL_E_SUCCESS)
                        Console.WriteLine("Transmit char failed: 0x" + Res.ToString("X8"));
                    else
                        Console.WriteLine("COMPLETED");
                    continue;
                }
                if (s == "SET_BRK")
                {
                    Res = FClient.SetCommBreak();
                    if (Res != wclErrors.WCL_E_SUCCESS)
                        Console.WriteLine("Set COMM break failed: 0x" + Res.ToString("X8"));
                    else
                        Console.WriteLine("COMPLETED");
                    continue;
                }
                if (s == "CLR_BRK")
                {
                    Res = FClient.ClearCommBreak();
                    if (Res != wclErrors.WCL_E_SUCCESS)
                        Console.WriteLine("Clear COMM break failed: 0x" + Res.ToString("X8"));
                    else
                        Console.WriteLine("COMPLETED");
                    continue;
                }
                if (s == "PURGE")
                {
                    Res = FClient.PurgeComm(wclSerialPurgeFlag.purgeRxAbort | wclSerialPurgeFlag.purgeRxClear |
                        wclSerialPurgeFlag.purgeTxAbort | wclSerialPurgeFlag.purgeTxClear);
                    if (Res != wclErrors.WCL_E_SUCCESS)
                        Console.WriteLine("Purge failed: 0x" + Res.ToString("X8"));
                    else
                        Console.WriteLine("COMPLETED");
                    continue;
                }
                if (s == "FLUSH")
                {
                    Res = FClient.FlushBuffers();
                    if (Res != wclErrors.WCL_E_SUCCESS)
                        Console.WriteLine("Flush failed: 0x" + Res.ToString("X8"));
                    else
                        Console.WriteLine("COMPLETED");
                    continue;
                }
                if (s.StartsWith("FUNC"))
                {
                    wclSerialEscapeFunction Func;
                    if (s == "FUNC_CLR_BRK")
                        Func = wclSerialEscapeFunction.escClrBreak;
                    else if (s == "FUNC_CLR_DTR")
                        Func = wclSerialEscapeFunction.escClrDtr;
                    else if (s == "FUNC_CLR_RTS")
                        Func = wclSerialEscapeFunction.escClrRts;
                    else if (s == "FUNC_SET_BRK")
                        Func = wclSerialEscapeFunction.escSetBreak;
                    else if (s == "FUNC_SET_DTR")
                        Func = wclSerialEscapeFunction.escSetDtr;
                    else if (s == "FUNC_SET_RTS")
                        Func = wclSerialEscapeFunction.escSetRts;
                    else if (s == "FUNC_SET_XOFF")
                        Func = wclSerialEscapeFunction.escSetXoff;
                    else
                        Func = wclSerialEscapeFunction.escSetXon;

                    Res = FClient.EscapeCommFunction(Func);
                    if (Res != wclErrors.WCL_E_SUCCESS)
                        Console.WriteLine("Func failed: 0x" + Res.ToString("X8"));
                    else
                        Console.WriteLine("COMPLETED");
                    continue;
                }

                s += "\r\n";
                Byte[] Ansi = Encoding.ASCII.GetBytes(s);
                UInt32 Sent = 0;
                Res = FClient.Write(Ansi, out Sent);
                if (Res != wclErrors.WCL_E_SUCCESS)
                    Console.WriteLine("Write error: 0x" + Res.ToString("X8"));
            }
        }

        private static void ClientData(Object Sender, Byte[] Data)
        {
            if (Data != null && Data.Length > 0)
            {
                String Str = Encoding.ASCII.GetString(Data);
                Console.WriteLine("Received: " + Str);
            }
        }

        private static void ClientDisconnect(Object Sender, Int32 Reason)
        {
            Console.WriteLine("Client disconnected: 0x" + Reason.ToString("X8"));
            if (!FDisconnectedByUser)
                Console.WriteLine("Type EXIT to exit the application.");
        }

        private static void ClientConnect(Object Sender, Int32 Error)
        {
            if (Error == wclErrors.WCL_E_SUCCESS)
            {
                Console.WriteLine("Client connected");
                wclSerialConfig Config;
                if (FClient.GetConfig(out Config) == wclErrors.WCL_E_SUCCESS)
                {
                    Config.BaudRate = 115200;
                    FClient.SetConfig(Config);
                }
            }
            else
                Console.WriteLine("Connect failed: 0x" + Error.ToString("X8"));
        }
    }
}
