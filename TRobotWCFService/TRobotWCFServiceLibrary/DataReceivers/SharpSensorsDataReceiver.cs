using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using System;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Data Receiver from the TRobot's Sharp sensors.
    /// </summary>
    internal class SharpSensorsDataReceiver : IDataReceiver
    {
        private Arduino arduino;
        private const string key = "distance";

        /// <summary>
        /// Constructs a SharpSensorsDataReceiver instance.
        /// </summary>
        /// /// <param name="arduino">Singleton istance of Arduino supporter.</param>
        public SharpSensorsDataReceiver(Arduino arduino)
        {
            this.arduino = arduino;
        }

        /// <summary>
        /// Receives data from the TRobot's Sharp sensors. Range for Sharp sensor is (200 - 1500 mm).
        /// </summary>
        /// <returns>Distance in mm from the TRobot's Sharp sensors. The key for measured distance is "distance1", "distance2", "distance3" for three Sharp sensors.</returns>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.SelectedDeviceType = SelectedDevice.Sharp;
            try
            {
                String[] distances = arduino.GetSharpsData();
                
                for (int i = 1; i <= distances.Length; i++)
                {
                    Int16 hexToDecimal = Convert.ToInt16(distances[i - 1], 16);
                    double distance = (60.495 * Math.Pow(hexToDecimal * 0.0049, -1.1904) * 10);

                    if (distance >= 200 && distance <= 1500)
                    {
                        data.Dictionary.Add(key + i, distance);
                    }
                    else
                    {
                        data.Dictionary.Add(key + i, 0);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            return data;
        }
    }
}