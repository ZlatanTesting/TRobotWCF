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
        private const int arduinoBaudRate = 9600;
        private const string arduinoComPort = "COM11";
        private Arduino arduino;
        private const string key = "distance";

        /// <summary>
        /// Constructs a HokuyoSensorDataReceiver instance.
        /// </summary>
        public MobotSensorDataReceiver()
        {
            arduino = new Arduino(arduinoComPort, arduinoBaudRate);
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
                arduino.Connect();
                String distance = arduino.GetMobotData();

                data.Dictionary.Add(key, double.Parse(distance));
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            finally
            {
                arduino.Disconnect();
            }
            return data;
        }
    }
}
