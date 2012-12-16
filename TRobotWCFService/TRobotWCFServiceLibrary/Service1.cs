using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.DataReceivers;
using TRobotWCFServiceLibrary.DataProvider;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary
{
    public class Service1 : IService1
    {
        private DataReceiverFactory dataReceiverFactory;
        private Roboteq roboteQ;
        private Hokuyo hokuyo;

        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private const int hokuyoBaudRate = 19200;
        private const string hokuyoComPort = "COM8";


        public Service1()
        {
            ConnectAllDevices();

            dataReceiverFactory = new DataReceiverFactory(roboteQ, hokuyo);
        }

        public bool SendData(Data data)
        {
            IDataProvider dataProvider = new EncoderDataProvider(data, roboteQ);

            bool response = dataProvider.ProvideData();

            DisconnectAllDevices();

            return response;
        }

        public Data LoadData(Data request)
        {
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(request.DataReceiverType);

            Data response = dataReceiver.ReceiveData();

            DisconnectAllDevices();

            return response;
        }

        private void ConnectAllDevices()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
            roboteQ.Connect();
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
            hokuyo.Connect();
        }

        private void DisconnectAllDevices()
        {
            roboteQ.Disconnect();
            hokuyo.Disconnect();
        }
    }
}
