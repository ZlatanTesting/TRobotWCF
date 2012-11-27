using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TRobotWCFServiceLibrary.Message
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
    }
}
