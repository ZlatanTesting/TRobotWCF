using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class BatteryDataReceiver : IDataReceiver
    {
        private Roboteq roboteQ;
        private const string key = "charge";

        public BatteryDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary>
        ///     This method returns charge of battery in percents.
        ///     The key for charge value is 'charge'.
        /// </summary>
        public Data ReceiveData()
        {
            String[] response = roboteQ.GetBatteryVoltage();

            int chargeInPercets = (int) (Double.Parse(response.First())*62.5 - 425);

            Data data = new Data();

            data.Dictionary.Add(key, chargeInPercets);

            return data;
        }
    }
}