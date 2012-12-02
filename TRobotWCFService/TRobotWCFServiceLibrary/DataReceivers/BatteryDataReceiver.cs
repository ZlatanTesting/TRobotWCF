using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class BatteryDataReceiver:IDataReceiver
    {
        private Roboteq roboteQ;

        public BatteryDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary> 
        /// This method always returns charge of battery in percents.
        /// The key for charge value is 'charge'.
        /// </summary>
        public Data ReceiveData()
        {
            String[] response = roboteQ.GetBatteryVoltage();

            int chargeInPercets = (int)(Double.Parse(response.First()) * 62.5 - 425);

            Data data = new Data();

            data.Dictionary.Add("charge", chargeInPercets);
            
            return data;
        }
    }
}
