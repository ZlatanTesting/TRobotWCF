using System;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Data Receiver from the TRobot's encoders.
    /// </summary>
    internal class EncoderDataReceiver : IDataReceiver
    {
        private Roboteq roboteQ;
        private const double wheelCircuitInKm = 0.00038;
        private const double hoursInMinute = 1.0/60;
        private const string key = "speed";

        /// <summary>
        /// Constructs a EncoderDataReceiver instance.
        /// </summary>
        /// <param name="roboteQ">Singleton istance of RoboteQ supporter.</param>
        public EncoderDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary>
        /// Receives data from the TRobot's encoders. Range for encoders is around (0 - 3.06 km/h).
        /// </summary>
        /// <returns>Velocity of Trobot in km/h. The key for measured velocity is "speed".</returns>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.SelectedDeviceType = SelectedDevice.Encoder;
            try
            {
                String[] response = roboteQ.GetSpeed();

                double velocity = ((double.Parse(response[0]) + Double.Parse(response[1])) / 2) * (wheelCircuitInKm / hoursInMinute);
                data.Dictionary.Add(key, velocity);
            }
            catch (Exception e)
            {
                //Logger.Log(e);
            }
            return data;
        }
    }
}