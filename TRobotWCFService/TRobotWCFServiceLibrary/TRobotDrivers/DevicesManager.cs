using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    /// <summary>
    /// Manage devices.
    /// </summary>
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

        /// <summary>
        /// Constructs a DevicesManager instance.
        /// </summary>
        public DevicesManager()
        {
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
            arduino = new Arduino(arduinoComPort, arduinoBaudRate);
        }

        /// <summary>
        /// Connects to all devices.
        /// </summary>
        public void ConnectAllDevices()
        {
            hokuyo.Connect();
            roboteQ.Connect();
            arduino.Connect();
        }

        /// <summary>
        /// Gets Arduino supporter.
        /// </summary>
        public Arduino Arduino
        {
            get
            {
                return arduino;
            }
        }

        /// <summary>
        /// Gets RoboteQ supporter.
        /// </summary>
        public Roboteq RoboteQ
        {
            get
            {
                return roboteQ;
            }
        }

        /// <summary>
        /// Gets Hokuyo supporter.
        /// </summary>
        public Hokuyo Hokuyo
        {
            get
            {
                return hokuyo;
            }
        }
    }
}
