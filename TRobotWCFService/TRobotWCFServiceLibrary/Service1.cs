using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.DataReceivers;
using TRobotWCFServiceLibrary.DataProvider;

namespace TRobotWCFServiceLibrary
{
    public class Service1 : IService1
    {
        public bool SendData(Data data)
        {
            IDataProvider dataProvider = new DriversDataProvider(data);

            bool response = dataProvider.ProvideData();

            return response;
        }

        public Data LoadData(Data request)
        {
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();

            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(request.DataReceiverType);

            Data response = dataReceiver.ReceiveData();

            return response;
        }
    }
}
