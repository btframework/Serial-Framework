using System;

using wclCommon;

namespace ErrorInfo
{
    internal class Program
    {
        private const String XmlFile = "https://www.btframework.com/errors8.xml";

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("The default errors definition file: " + XmlFile);
            Console.WriteLine("To use local file change path in the application source code");

            while (true)
            {
                Console.Write("Error code. Start with $ or 0x for hexadecimal value (EXIT to exit): ");
                String Val = Console.ReadLine();
                if (Val == "EXIT")
                    break;

                if (Val == "")
                {
                    Console.WriteLine("Enter error code.");
                    continue;
                }

                Int32 Base;
                if (Val.StartsWith("0x") || Val.StartsWith("$"))
                    Base = 16;
                else
                    Base = 10;
                Int32 Err = Convert.ToInt32(Val, Base);

                wclErrorInformation Info = new wclErrorInformation();
                if (!Info.Open(XmlFile))
                {
                    Console.WriteLine("Open errors definition file failed");
                    continue;
                }

                try
                {
                    wclErrorDetails Details = new wclErrorDetails();
                    if (!Info.GetDetails(Err, ref Details))
                    {
                        Console.WriteLine("Unable to get error details");
                        continue;
                    }

                    Console.WriteLine("\tError code: 0x" + Details.Error.ToString("X8"));
                    Console.WriteLine("\tFramework: " + Details.Framework);
                    Console.WriteLine("\tCategory: " + Details.Category);
                    Console.WriteLine("\tConstant name: " + Details.Constant);
                    Console.WriteLine("\t" + Details.Description);
                }
                finally
                {
                    Info.Close();
                }
            }
        }
    }
}
