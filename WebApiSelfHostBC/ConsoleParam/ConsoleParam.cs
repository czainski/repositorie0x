using System;
using System.Text.RegularExpressions;

namespace WebApiSelfHostBC.ConsoleRead
{
    public static class ConsoleParam
    {
        static int[] RegisteredPorts = new int[] { 1024, 49151 };

        static int _defaultPort = 8020;
        static string _address        = null;
        static string _authorization = null;

        static  ConsoleParam() 
        {
            Console.Write("\n\tLogin (\"BC\"): ");
            var login = LoginPassPortTest.ReadLoginOrPassOrPort();

            Console.Write("\n\tPassward  (\"12345\") : ");
            var pass = LoginPassPortTest.ReadLoginOrPassOrPort(true);
                        
            var port = "null";
            while (port == "null")
            {
                Console.Write("\n\tPort (default: 8020) : ");
                port = LoginPassPortTest.ReadLoginOrPassOrPort(false, true);
            }
             if (Regex.IsMatch(port, @"^\d+$"))
             {
                    int pt=Int16.Parse(port);
                    if (pt >= RegisteredPorts[0] && pt <= RegisteredPorts[1])
                                        _address = ":" + pt + "/";
             }
            else
                _address = ":" + _defaultPort + "/";

            _authorization = login+":"+ pass;
        }
        public static (string, string) Param(string address= "http://localhost")
        {
            return (address+_address, _authorization);
        }
    }
}
