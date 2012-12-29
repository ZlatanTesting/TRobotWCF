using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Data Receiver from the TRobot's Hokuyo sensor.
    /// </summary>
    internal class HokuyoSensorDataReceiver : IDataReceiver
    {
        private const int hokuyoBaudRate = 19200;
        private const int hokuyoComPort = 8;
        private Hokuyo hokuyo;
        private const String key = "distance";

        /// <summary>
        /// Constructs a HokuyoSensorDataReceiver instance.
        /// </summary>
        public HokuyoSensorDataReceiver()
        {
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
        }

        /// <summary>
        /// Receives data from the TRobot's Hokuyo sensor. Range for Hokuyo sensor is around (20 - 4000 mm). 
        /// Scan area is 240 degrees semicircle. Sensor outputs the distace measured at 682 points.
        /// </summary>
        /// <returns>Distance in 682 points in mm from the TRobot's Hokuyo sensor. The key for measured distance is "distance0", "distance1", ..., "distance681".</returns>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.DataReceiverType = DataReceiver.Hokuyo;
            try
            {
                hokuyo.Connect();
                int[] distanceValuesFromHokuyo = hokuyo.GetData();
                int numberOfDistanceValues = distanceValuesFromHokuyo.Count();

                String currentKey;
                for (int i = 0; i < numberOfDistanceValues; i++)
                {
                    currentKey = key + i;
                    data.Dictionary.Add(currentKey, distanceValuesFromHokuyo[i]);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            finally
            {
                hokuyo.Disconnect();
            }
            return data;
        }
    }
}