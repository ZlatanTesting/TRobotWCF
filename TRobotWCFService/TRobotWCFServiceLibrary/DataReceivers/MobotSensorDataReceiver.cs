using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class MobotSensorDataReceiver : IDataReceiver
    {
        private const string key = "distance";

        /// <summary>
        ///     This is mock method. This method always returns 200cm.
        ///     Range for this sensor is (5 - 350 cm).
        ///     The key for measured distance is 'distance'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add(key, 200);

            return data;
        }
    }
}