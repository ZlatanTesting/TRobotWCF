using System.ServiceModel;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool SendData(Data data);

        [OperationContract]
        Data LoadData(Data request);
    }
}
