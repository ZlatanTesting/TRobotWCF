using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class TemperatureDataReceiver : IDataReceiver
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;
        private const string key = "temperature";

        public TemperatureDataReceiver()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
        }

        /// <summary>
        ///     This method returns temperature of chipset in degrees C.
        ///     The key for temperature value is 'temperature'.
        /// </summary>
        public Data ReceiveData()
        {
            roboteQ.Connect();
            String[] response = roboteQ.GetTemperature();

            int degreesC = int.Parse(response.First());

            Data data = new Data();
            data.DataReceiverType = DataReceiver.Temperature;

            data.Dictionary.Add(key, degreesC);

            roboteQ.Disconnect();
            return data;
        }
    }
}