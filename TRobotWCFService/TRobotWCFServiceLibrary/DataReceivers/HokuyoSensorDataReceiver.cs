using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class HokuyoSensorDataReceiver : IDataReceiver
    {
        private const int hokuyoBaudRate = 19200;
        private const int hokuyoComPort = 8;
        private Hokuyo hokuyo;
        private const String key = "distance";

        public HokuyoSensorDataReceiver()
        {
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
        }

        /// <summary>
        ///     This method returns distance values in mm.
        ///     Range for this sensor is (20 - 4000 mm).
        ///     Scan area is 240 degrees semicircle. Pitch angle is 0.36 degree and sensor outputs the distace measured at every point (683 steps).
        ///     The key for measured distance is 'distance0', 'distance1' ... 'distance682'.
        /// </summary>
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