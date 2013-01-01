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
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;
        private const string key = "temperature";

        /// <summary>
        /// Constructs a TemperatureDataReceiver instance.
        /// </summary>
        public TemperatureDataReceiver()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
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
                roboteQ.Connect();
                int degreesC = int.Parse(roboteQ.GetTemperature());

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