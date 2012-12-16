using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class TemperatureDataReceiver : IDataReceiver
    {
        private const string key = "temperature";
        private Roboteq roboteQ;

        public TemperatureDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary>
        ///     This method returns temperature of chipset in degrees C.
        ///     The key for temperature value is 'temperature'.
        /// </summary>
        public Data ReceiveData()
        {
            String[] response = roboteQ.GetTemperature();

            int degreesC = int.Parse(response.First());

            Data data = new Data();

            data.Dictionary.Add(key, degreesC);

            return data;
        }
    }
}