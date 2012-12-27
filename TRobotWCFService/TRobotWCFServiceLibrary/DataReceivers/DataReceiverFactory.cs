using System;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class DataReceiverFactory
    {
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
                        return new SharpSensorDataReceiver();
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