using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TRobotWCFServiceLibrary;

namespace WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service1));

            host.Open();

            Console.WriteLine("Service is up and running ...");
            Console.WriteLine();
            Console.WriteLine("----PRESS ANY KEY TO BREAK----");

            Console.ReadKey();

            host.Close();
        }
    }
}
