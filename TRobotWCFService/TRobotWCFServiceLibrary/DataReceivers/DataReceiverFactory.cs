using System;
using TRobotWCFServiceLibrary.Utils;
using TRobotWCFServiceLibrary.DataProvider;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    /// <summary>
    /// Factory of IDataReceivers.
    /// </summary>
    internal class DataReceiverFactory
    {
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
                    return new BatteryDataReceiver();
                }
                case SelectedDevice.Hokuyo:
                {
                    return new HokuyoSensorDataReceiver();
                }
                case SelectedDevice.Sharp:
                {
                    return new SharpSensorsDataReceiver();
                }
                case SelectedDevice.Mobot:
                {
                    return new MobotSensorDataReceiver();
                }
                case SelectedDevice.Encoder:
                {
                    return new EncoderDataReceiver();
                }
                case SelectedDevice.Temperature:
                {
                    return new TemperatureDataReceiver();
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