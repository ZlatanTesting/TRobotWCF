using System;
using TRobotWCFServiceLibrary.TRobotDrivers;

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
        public IDataReceiver GetDataReceiver(DataReceiver dataReceiver)
        {
            switch (dataReceiver)
            {
                case DataReceiver.Battery:
                {
                    return new BatteryDataReceiver();
                }
                case DataReceiver.Hokuyo:
                {
                    return new HokuyoSensorDataReceiver();
                }
                case DataReceiver.Sharp:
                {
                    return new SharpSensorsDataReceiver();
                }
                case DataReceiver.Mobot:
                {
                    return new MobotSensorDataReceiver();
                }
                case DataReceiver.Encoder:
                {
                    return new EncoderDataReceiver();
                }
                case DataReceiver.Temperature:
                {
                    return new TemperatureDataReceiver();
                }
                default:
                {
                    throw new ArgumentException("Wrong DataReceiver type");
                }
            }
        }
    }
}