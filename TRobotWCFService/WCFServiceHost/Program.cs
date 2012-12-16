using System;
using System.ServiceModel;
using TRobotWCFServiceLibrary;

namespace WCFServiceHost
{
    class Program
    {
        private static ServiceHost host;

        static void Main(string[] args)
        {
            host = new ServiceHost(typeof(Service1));

            host.Open();

            Console.WriteLine("Service is up and running ...");
            Console.WriteLine();
            Console.WriteLine("----PRESS ANY KEY TO BREAK----");

            Console.ReadKey();

            host.Close();
        }
    }
}
