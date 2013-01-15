using System;
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
        private Roboteq roboteQ;
        private const string key = "charge";
        private const int uMin = 68;
        private const int uMax = 84;

        /// <summary>
        /// Constructs a BatteryDataReceiver instance.
        /// </summary>
        /// <param name="roboteQ">Singleton istance of RoboteQ supporter.</param>
        public BatteryDataReceiver(Roboteq roboteQ)
        {
            this.roboteQ = roboteQ;
        }

        /// <summary>
        /// Receives data from the TRobot's batteries.
        /// </summary>
        /// <returns>Charge of Trobot's batteries in percents. The key for charge value is "charge".</returns>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.SelectedDeviceType = SelectedDevice.Battery;
            try
            {
                String response = roboteQ.GetBatteryVoltage();

                int chargeInPercets = (int)(Double.Parse(response)-uMin)*100/(uMax-uMin);
                if (chargeInPercets < 0)
                {
                    data.Dictionary.Add(key, 0);
                }
                else if (chargeInPercets > 100)
                {
                    data.Dictionary.Add(key, 100);
                }
                else
                {
                    data.Dictionary.Add(key, chargeInPercets);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            return data;
        }
    }
}