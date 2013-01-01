using System.Collections.Generic;
using System.Runtime.Serialization;
using TRobotWCFServiceLibrary.DataReceivers;

namespace TRobotWCFServiceLibrary.Messages
{
    /// <summary>
    /// Encapsulates data to send between service and client. 
    /// </summary>
    [DataContract]
    public class Data
    {
        /// <summary>
        /// Constructs a Data instance.
        /// </summary>
        public Data()
        {
            Dictionary = new Dictionary<string, double>();
        }

        /// <summary>
        /// Property to encapsulate data in dictionary.
        /// </summary>
        [DataMember]
        public Dictionary<string, double> Dictionary{ get; set; }

        /// <summary>
        /// Property to get or set selected device type.
        /// </summary>
        [DataMember]
        public SelectedDevice SelectedDeviceType { get; set; }
    }
}
