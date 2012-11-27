using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using TRobotWCFServiceLibrary.Message;

namespace TRobotWCFServiceLibrary
{
    public class Service1 : IService1
    {
        public Data SendData(Data data)
        {
            Data response = new Data();

            return response;
        }

        public Data LoadData(Data request)
        {
            Data response = new Data();

            return response;
        }
    }
}
