using System.ServiceModel;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary
{
    /// <summary>
    /// Interface for services exposed to the world.
    /// </summary>
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// Sends data to selected device.
        /// </summary>
        /// <param name="data">Data with selected device type and values to send to selected device.</param>
        [OperationContract]
        void SendData(Data data);

        /// <summary>
        /// Loads data for selected device.
        /// </summary>
        /// <param name="request">Request with selected device type.</param>
        /// <returns>Data with received values for selected device type.</returns>
        [OperationContract]
        Data LoadData(Data request);
    }
}
