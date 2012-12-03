using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    class DataReceiverFactory
    {
        private Roboteq roboteQ;
        private Hokuyo hokuyo;

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
                case DataReceiver.GPS:
                    {
                        return new GPSDataReceiver();
                    }
                case DataReceiver.Hokuyo:
                    {
                        return new HokuyoSensorDataReceiver(hokuyo);
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
                        return new EncoderDataReceiver(roboteQ);
                    }
                default:
                    {
                        throw new ArgumentException("Wrong DataReceiver type");
                    }
            }
        }
    }
}
