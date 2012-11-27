using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Message;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    interface IDataReceiver
    {
        Data ReceiveData();
    }
}
