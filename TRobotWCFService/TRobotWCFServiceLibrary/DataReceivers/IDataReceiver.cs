using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal interface IDataReceiver
    {
        Data ReceiveData();
    }
}