using System;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Data Receiver from the TRobot's thermometer.
    /// </summary>
    internal class TemperatureDataReceiver : IDataReceiver
    {
        private Roboteq roboteQ;
        private const string key = "temperature";

        /// <summary>
        /// Constructs a TemperatureDataReceiver instance.
        /// </summary>
        public TemperatureDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary>
        /// Receives chipset's temperature from the TRobot's thermometer.
        /// </summary>
        /// <returns>Temperature of chipset in degrees C. The key for temperature value is "temperature".</returns>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.SelectedDeviceType = SelectedDevice.Temperature;
            try
            {
                int degreesC = int.Parse(roboteQ.GetTemperature());

                data.Dictionary.Add(key, degreesC);
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            return data;
        }
    }
}