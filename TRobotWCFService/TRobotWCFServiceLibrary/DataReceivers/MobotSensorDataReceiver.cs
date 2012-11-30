using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class MobotSensorDataReceiver:IDataReceiver
    {
        /// <summary> 
        /// This is mock method. This method always returns 200cm.
        /// Range for this sensor is (5 - 350 cm).
        /// The key for measured distance is 'distance'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add("distance", 200);

            return data;
        }
    }
}
