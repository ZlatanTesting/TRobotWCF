using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class SharpSensorDataReceiver:IDataReceiver
    {
        /// <summary> 
        /// This is mock method. This method always returns 50cm.
        /// Range for this sensor is (20 - 150 cm).
        /// The key for measured distance is 'distance'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add("distance", 50);

            return data;
        }
    }
}
