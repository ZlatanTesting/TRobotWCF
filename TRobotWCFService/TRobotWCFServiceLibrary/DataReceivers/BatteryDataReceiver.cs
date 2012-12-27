using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class BatteryDataReceiver : IDataReceiver
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;
        private const string key = "charge";

        public BatteryDataReceiver()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
        }

        /// <summary>
        ///     This method returns charge of battery in percents.
        ///     The key for charge value is 'charge'.
        /// </summary>
        public Data ReceiveData()
        {
            roboteQ.Connect();
            String[] response = roboteQ.GetBatteryVoltage();

            int chargeInPercets = (int) (Double.Parse(response.First())*6.25 - 425);

            Data data = new Data();
            data.DataReceiverType = DataReceiver.Battery;

            data.Dictionary.Add(key, chargeInPercets);

            roboteQ.Disconnect();
            return data;
        }
    }
}