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
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary
{
    public class Service1 : IService1
    {
        private DataReceiverFactory dataReceiverFactory;
        private Roboteq roboteQ;
        private Hokuyo hokuyo;

        private int roboteQBaudRate = 115200;
        private string roboteQComPort = "COM9";
        private int hokuyoBaudRate = 19200;
        private string hokuyoComPort = "COM8";


        public Service1()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
            roboteQ.Connect();
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
            hokuyo.Connect();

            dataReceiverFactory = new DataReceiverFactory(roboteQ, hokuyo);
        }

        public bool SendData(Data data)
        {
            IDataProvider dataProvider = new EncoderDataProvider(data, roboteQ);

            bool response = dataProvider.ProvideData();

            return response;
        }

        public Data LoadData(Data request)
        {
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(request.DataReceiverType);

            Data response = dataReceiver.ReceiveData();

            return response;
        }
    }
}
