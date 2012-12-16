using System;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class EncoderDataReceiver : IDataReceiver
    {
        private const double wheelCircuitInKm = 0.00038;
        private const int hoursInMinute = 1/60;
        private Roboteq roboteQ;
        private const string key = "speed";

        public EncoderDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary>
        ///     This method returns drivers velocity.
        ///     Range for encoder is (0 - 3 km/h).
        ///     The key for measured speed is 'speed'.
        /// </summary>
        public Data ReceiveData()
        {
            String[] response = roboteQ.GetSpeed();

            double velocity = ((double.Parse(response[0]) + Double.Parse(response[1]))/2)*(wheelCircuitInKm/hoursInMinute);

            Data data = new Data();

            data.Dictionary.Add(key, velocity);

            return data;
        }
    }
}