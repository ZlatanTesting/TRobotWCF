using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TRobotWCFServiceLibrary.Message;

namespace TRobotWCFServiceLibrary
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Data SendData(Data data);

        [OperationContract]
        Data LoadData(Data request);
    }
}
