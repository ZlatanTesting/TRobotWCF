using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class BatteryDataReceiver:IDataReceiver
    {
        /// <summary> 
        /// This is mock method. This method always returns 70%.
        /// The key for charge value is 'charge'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add("charge", 70);
            
            return data;
        }
    }
}
