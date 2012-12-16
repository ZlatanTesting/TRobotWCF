using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class GpsDataReceiver : IDataReceiver
    {
        private const string latitudeKey = "latitude";
        private const string longitudeKey = "longitude"; 

        /// <summary>
        ///     This is mock method. This method always returns latitude = 50.2849835 and longitude = 18.6717034.
        ///     The key for latitude is 'latitude' and for longitude is 'longitude'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();

            data.Dictionary.Add(latitudeKey, 50.2849835);
            data.Dictionary.Add(longitudeKey, 18.6717034);

            return data;
        }
    }
}