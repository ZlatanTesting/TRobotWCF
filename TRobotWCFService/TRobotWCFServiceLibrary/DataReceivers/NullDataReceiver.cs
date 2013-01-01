using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class NullDataReceiver:IDataReceiver
    {
        public Data ReceiveData()
        {
            Data response = new Data();
            response.SelectedDeviceType = SelectedDevice.Null;

            return response;
        }
    }
}
