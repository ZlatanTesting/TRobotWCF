using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class SharpSensorDataReceiver : IDataReceiver
    {
        private const string key = "distance";

        /// <summary>
        ///     This is mock method. This method always returns 50cm.
        ///     Range for this sensor is (20 - 150 cm).
        ///     The key for measured distance is 'distance'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add(key, 50);

            return data;
        }
    }
}