using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class EncoderDataReceiver:IDataReceiver
    {
        private Roboteq roboteQ;
        private double wheelCircuitInKm = 0.00038;
        private int hoursInMiute = 1/60;

        public EncoderDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary> 
        /// This method returns drivers velocity.
        /// Range for encoder is (0 - 3 km/h).
        /// The key for measured speed is 'speed'.
        /// </summary>
        public Data ReceiveData()
        {
            String[] response = roboteQ.GetSpeed();

            double velocity = ((double.Parse(response[0]) + Double.Parse(response[1])) / 2) * (wheelCircuitInKm / hoursInMiute);

            Data data = new Data();

            data.Dictionary.Add("speed", velocity);

            return data;
        }
    }
}
