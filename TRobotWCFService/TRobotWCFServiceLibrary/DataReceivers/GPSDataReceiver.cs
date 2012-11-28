using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class GPSDataReceiver:IDataReceiver
    {
        /// <summary> 
        /// This is mock method. This method always returns latitude = 50.2849835 and longitude = 18.6717034.
        /// The key for latitude is 'latitude' and for longitude is 'longitude'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add("latitude", 50.2849835);
            data.Dictionary.Add("longitude", 18.6717034);

            return data;
        }
    }
}
