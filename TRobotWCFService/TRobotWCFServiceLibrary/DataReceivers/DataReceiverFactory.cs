using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class DataReceiverFactory
    {
        public IDataReceiver GetDataReceiver(DataReceiver dataReceiver)
        {
            switch (dataReceiver)
            {
                case DataReceiver.Battery:
                    {
                        return new BatteryDataReceiver();
                    }
                case DataReceiver.GPS:
                    {
                        return new GPSDataReceiver();
                    }
                case DataReceiver.Hokuyo:
                    {
                        return new HokuyoSensorDataReceiver();
                    }
                case DataReceiver.IMU:
                    {
                        return new IMUOrientationModuleDataReceiver();
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
                default:
                    {
                        throw new ArgumentException("Wrong DataReceiver type");
                    }
            }
        }
    }
}
