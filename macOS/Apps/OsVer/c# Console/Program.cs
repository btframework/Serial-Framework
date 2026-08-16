using System;

using wclCommon;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("OS Version test application");
        Console.Write(wclOsVersion.OsType.ToString()); Console.Write("  ");
        Console.Write(wclOsVersion.Major.ToString()); Console.Write(".");
        Console.Write(wclOsVersion.Minor.ToString()); Console.Write(".");
        Console.WriteLine(wclOsVersion.Build.ToString());
    }
}