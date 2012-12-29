using System;
using System.Linq;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Data Receiver from the TRobot's batteries.
    /// </summary>
    internal class BatteryDataReceiver : IDataReceiver
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;
        private const string key = "charge";

        /// <summary>
        /// Constructs a BatteryDataReceiver instance.
        /// </summary>
        public BatteryDataReceiver()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
        }

        /// <summary>
        /// Receives data from the TRobot's batteries.
        /// </summary>
        /// <returns>Charge of Trobot's batteries in percents. The key for charge value is "charge".</returns>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.DataReceiverType = DataReceiver.Battery;
            try
            {
                roboteQ.Connect();
                String response = roboteQ.GetBatteryVoltage();

                int chargeInPercets = (int)(Double.Parse(response) * 6.25 - 425);
                data.Dictionary.Add(key, chargeInPercets);
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            finally
            {
                roboteQ.Disconnect();
            }
            return data;
        }
    }
}