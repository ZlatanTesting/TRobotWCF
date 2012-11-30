using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class EncoderDataReceiver:IDataReceiver
    {
        /// <summary> 
        /// This is mock method. This method always returns 2 m/s.
        /// Range for encoder is (0 - 3 m/s).
        /// The key for measured speed is 'speed'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add("speed", 2);

            return data;
        }
    }
}
