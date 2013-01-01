using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.DataReceivers;
using TRobotWCFServiceLibrary.DataProvider;

namespace TRobotWCFServiceLibrary
{
    /// <summary>
    /// Service exposed to the world.
    /// </summary>
    public class Service1 : IService1
    {
        private DataReceiverFactory dataReceiverFactory;

        /// <summary>
        /// Constructs a Service1 instance.
        /// </summary>
        public Service1()
        {
            dataReceiverFactory = new DataReceiverFactory();
        }

        /// <summary>
        /// Sends data to selected device.
        /// </summary>
        /// <param name="data">Data with selected device type and values to send to selected device.</param>
        public void SendData(Data data)
        {
            switch (data.SelectedDeviceType)
            {
                case SelectedDevice.Drive:
                {
                    IDataProvider dataProvider = new EncoderDataProvider(data);
                    dataProvider.ProvideData();
                    break;
                }
                case SelectedDevice.DriveInit:
                {
                    IDataProvider dataProvider = new DriveInitializeDataProvider();
                    dataProvider.ProvideData();
                    break;
                }
            } 
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
