using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class HokuyoSensorDataReceiver:IDataReceiver
    {
        /// <summary> 
        /// This is mock method. This method always returns distance value specyfied by equation: 'point'sNumber * 2'.
        /// Range for this sensor is (2 - 400 cm).
        /// Scan area is 240 degrees semicircle. Pitch angle is 0.36 degree and sensor outputs the distace measured at every point (683 steps).
        /// The key for measured distance is 'distance0', 'distance1' ... 'distance682'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            for (int i = 0; i < 683; i++)
            {
                String key = "distance" + i;
                data.Dictionary.Add("key", i*2);
            }

            return data;
        }
    }
}
