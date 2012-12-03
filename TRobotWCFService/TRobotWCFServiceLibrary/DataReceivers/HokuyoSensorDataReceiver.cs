using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class HokuyoSensorDataReceiver:IDataReceiver
    {
        Hokuyo hokuyo;

        public HokuyoSensorDataReceiver(Hokuyo hokuyo)
        {
            this.hokuyo = hokuyo;
        }

        /// <summary> 
        /// This method returns distance values in mm.
        /// Range for this sensor is (20 - 4000 mm).
        /// Scan area is 240 degrees semicircle. Pitch angle is 0.36 degree and sensor outputs the distace measured at every point (683 steps).
        /// The key for measured distance is 'distance0', 'distance1' ... 'distance682'.
        /// </summary>
        public Data ReceiveData()
        {
            int[] distanceValuesFromHokuyo = hokuyo.GetData();

            Data data = new Data();

            int numberOfDistanceValues = distanceValuesFromHokuyo.Count();

            for (int i = 0; i < numberOfDistanceValues; i++)
            {
                String key = "distance" + i;
                data.Dictionary.Add("key", distanceValuesFromHokuyo[i]);
            }

            return data;
        }
    }
}
