using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    class DevicesManager
    {
        private const int arduinoBaudRate = 9600;
        private const string arduinoComPort = "COM11";
        private Arduino arduino;
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;
        private const int hokuyoBaudRate = 19200;
        private const int hokuyoComPort = 8;
        private Hokuyo hokuyo;

        public DevicesManager()
        {
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
            arduino = new Arduino(arduinoComPort, arduinoBaudRate);
        }

        public void ConnectAllDevices()
        {
            hokuyo.Connect();
            roboteQ.Connect();
            arduino.Connect();
        }

        public Arduino Arduino
        {
            get
            {
                return arduino;
            }
        }

        public Roboteq RoboteQ
        {
            get
            {
                return roboteQ;
            }
        }

        public Hokuyo Hokuyo
        {
            get
            {
                return hokuyo;
            }
        }
    }
}
