using System;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class DataReceiverFactory
    {
        private Hokuyo hokuyo;
        private Roboteq roboteQ;

        public DataReceiverFactory(Roboteq roboteQ, Hokuyo hokuyo)
        {
            this.roboteQ = roboteQ;
            this.hokuyo = hokuyo;
        }

        public IDataReceiver GetDataReceiver(DataReceiver dataReceiver)
        {
            switch (dataReceiver)
            {
                case DataReceiver.Battery:
                    {
                        return new BatteryDataReceiver(roboteQ);
                    }
                case DataReceiver.Gps:
                    {
                        return new GpsDataReceiver();
                    }
                case DataReceiver.Hokuyo:
                    {
                        return new HokuyoSensorDataReceiver(hokuyo);
                    }
                case DataReceiver.Imu:
                    {
                        return new ImuOrientationModuleDataReceiver();
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
                        return new EncoderDataReceiver(roboteQ);
                    }
                case DataReceiver.Temperature:
                    {
                        return new TemperatureDataReceiver(roboteQ);
                    }
                default:
                    {
                        throw new ArgumentException("Wrong DataReceiver type");
                    }
            }
        }
    }
}