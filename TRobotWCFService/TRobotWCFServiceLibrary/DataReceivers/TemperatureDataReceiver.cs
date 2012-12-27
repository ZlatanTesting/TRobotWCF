using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

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
            Data data = new Data();
            data.DataReceiverType = DataReceiver.Temperature;
            try
            {
                roboteQ.Connect();
                String[] response = roboteQ.GetTemperature();
                int degreesC = int.Parse(response.First());

                data.Dictionary.Add(key, degreesC);
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            finally
            {
                roboteQ.Disconnect();
            }
            return data;
        }
    }
}