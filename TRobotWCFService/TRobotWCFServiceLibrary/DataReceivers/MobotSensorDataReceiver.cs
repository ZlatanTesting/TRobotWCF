using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;
using System;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Data Receiver from the TRobot's Mobot sensor.
    /// </summary>
    internal class MobotSensorDataReceiver : IDataReceiver
    {
        private Arduino arduino;
        private const string key = "distance";

        /// <summary>
        /// Constructs a HokuyoSensorDataReceiver instance.
        /// </summary>
        public MobotSensorDataReceiver(Arduino arduino)
        {
            this.arduino = arduino;
        }

        /// <summary>
        /// Receives data from the TRobot's Mobot sensor. Range for Mobot sensor is (50 - 3500 mm).
        /// </summary>
        /// <returns>Distance in mm from the TRobot's Mobot sensors. The key for measured distance is "distance"</returns>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.SelectedDeviceType = SelectedDevice.Mobot;
            try
            {
                String distance = arduino.GetMobotData();

                data.Dictionary.Add(key, double.Parse(distance));
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            return data;
        }
    }
}
