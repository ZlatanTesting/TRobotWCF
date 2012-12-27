using System;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class EncoderDataReceiver : IDataReceiver
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;
        private const double wheelCircuitInKm = 0.00038;
        private const double hoursInMinute = 1.0/60;
        private const string key = "speed";

        public EncoderDataReceiver()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
        }

        /// <summary>
        ///     This method returns drivers velocity.
        ///     Range for encoder is (0 - 3 km/h).
        ///     The key for measured speed is 'speed'.
        /// </summary>
        public Data ReceiveData()
        {
            roboteQ.Connect();
            String[] response = roboteQ.GetSpeed();

            double velocity = ((double.Parse(response[0]) + Double.Parse(response[1])) / 2)*(wheelCircuitInKm/hoursInMinute);

            Data data = new Data();
            data.DataReceiverType = DataReceiver.Encoder;

            data.Dictionary.Add(key, velocity);

            roboteQ.Disconnect();
            return data;
        }
    }
}