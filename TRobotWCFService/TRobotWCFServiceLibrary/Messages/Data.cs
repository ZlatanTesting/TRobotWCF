using System.Collections.Generic;
using System.Runtime.Serialization;
using TRobotWCFServiceLibrary.DataReceivers;

namespace TRobotWCFServiceLibrary.Messages
{
    [DataContract]
    public class Data
    {
        public Data()
        {
            Dictionary = new Dictionary<string, double>();
        }

        [DataMember]
        public Dictionary<string, double> Dictionary{ get; set; }

        [DataMember]
        public DataReceiver DataReceiverType { get; set; }
    }
}
