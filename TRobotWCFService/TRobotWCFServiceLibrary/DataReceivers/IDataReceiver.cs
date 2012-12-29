using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Interface for Data Receivers.
    /// </summary>
    internal interface IDataReceiver
    {
        /// <summary>
        /// Receives data from the TRobot.
        /// </summary>
        /// <returns>Data from DataReceiver.</returns>
        Data ReceiveData();
    }
}