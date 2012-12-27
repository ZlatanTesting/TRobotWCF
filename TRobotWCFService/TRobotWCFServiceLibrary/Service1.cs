using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.DataReceivers;
using TRobotWCFServiceLibrary.DataProvider;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary
{
    public class Service1 : IService1
    {
        private DataReceiverFactory dataReceiverFactory;

        public Service1()
        {
            dataReceiverFactory = new DataReceiverFactory();
        }

        public void SendData(Data data)
        {
            IDataProvider dataProvider = new EncoderDataProvider(data);

            dataProvider.ProvideData();
        }

        public Data LoadData(Data request)
        {
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(request.DataReceiverType);

            Data response = dataReceiver.ReceiveData();

            return response;
        }
    }
}
