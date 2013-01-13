using System;
using TRobotWCFServiceLibrary.Utils;
using TRobotWCFServiceLibrary.DataProvider;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Factory of IDataReceivers.
    /// </summary>
    internal class DataReceiverFactory
    {
        private DevicesManager devicesManager;

        /// <summary>
        /// Constructs a Service1 instance.
        /// </summary>
        public DataReceiverFactory(DevicesManager devicesManager)
        {
            this.devicesManager = devicesManager;
        }

        /// <summary>
        /// Factory method which returns IDataReceiver for selected device.
        /// </summary>
        /// <param name="dataReceiver">Selected device.</param>
        /// <returns>IDataReceiver for selected device.</returns>
        public IDataReceiver GetDataReceiver(SelectedDevice dataReceiver)
        {
            switch (dataReceiver)
            {
                case SelectedDevice.Battery:
                {
                    return new BatteryDataReceiver(devicesManager.RoboteQ);
                }
                case SelectedDevice.Hokuyo:
                {
                    return new HokuyoSensorDataReceiver(devicesManager.Hokuyo);
                }
                case SelectedDevice.Sharp:
                {
                    return new SharpSensorsDataReceiver(devicesManager.Arduino);
                }
                case SelectedDevice.Mobot:
                {
                    return new MobotSensorDataReceiver(devicesManager.Arduino);
                }
                case SelectedDevice.Encoder:
                {
                    return new EncoderDataReceiver(devicesManager.RoboteQ);
                }
                case SelectedDevice.Temperature:
                {
                    return new TemperatureDataReceiver(devicesManager.RoboteQ);
                }
                default:
                {
                    Logger.Log(new ArgumentException("Wrong DataReceiver type"));
                    return new NullDataReceiver();
                }
            }
        }
    }
}