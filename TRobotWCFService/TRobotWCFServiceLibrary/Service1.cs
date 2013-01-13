using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.DataReceivers;
using TRobotWCFServiceLibrary.DataProvider;
using System.ServiceModel;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary
{
    /// <summary>
    /// Service exposed to the world.
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private DataReceiverFactory dataReceiverFactory;
        private DevicesManager devicesManager;

        /// <summary>
        /// Constructs a Service1 instance.
        /// </summary>
        public Service1()
        {
            devicesManager = new DevicesManager();
            devicesManager.ConnectAllDevices();
            dataReceiverFactory = new DataReceiverFactory(devicesManager);
        }

        /// <summary>
        /// Sends data to selected device.
        /// </summary>
        /// <param name="data">Data with selected device type and values to send to selected device.</param>
        public void SendData(Data data)
        {
            IDataProvider dataProvider = new EncoderDataProvider(data, devicesManager.RoboteQ);
            dataProvider.ProvideData();
        }

        /// <summary>
        /// Loads data for selected device.
        /// </summary>
        /// <param name="request">Request with selected device type.</param>
        /// <returns>Data with received values for selected device type.</returns>
        public Data LoadData(Data request)
        {
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(request.SelectedDeviceType);

            Data response = dataReceiver.ReceiveData();

            return response;
        }
    }
}
