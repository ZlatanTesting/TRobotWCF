using System.Linq;
using System;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    /// <summary>
    /// Supports the Hokuyo sensor.
    /// </summary>
    internal class Hokuyo
    {
        private UrgCtrl.UrgCtrl hokuyo;
        private int baudRate;
        private int comPort;
        private const int maxBufferSize = 682;

        /// <summary>
        /// Constructs a Hokuyo instance.
        /// </summary>
        /// <param name="comPort">Com port number for the Hokuyo</param>
        /// <param name="baudRate">BaudRate for the com port</param>
        public Hokuyo(int comPort, int baudRate)
        {
            this.baudRate = baudRate;
            this.comPort = comPort;
        }

        /// <summary>
        /// Connects to the Hokuyo sensor.
        /// </summary>
        public void Connect()
        {
            if (hokuyo != null)
            {
                Disconnect();
            }
            hokuyo = new UrgCtrl.UrgCtrl();

            bool connected = false;
            while (!connected)
            {
                try
                {
                    hokuyo.Connect(comPort, baudRate);
                    connected = true;
                }
                catch (Exception)
                {
                    connected = false;
                }
            }
        }

        /// <summary>
        /// Disconnects from the Hokuyo sensor.
        /// </summary>
        public void Disconnect()
        {
            if (hokuyo.IsConnected())
            {
                hokuyo.Disconnect();
            }
        }

        /// <summary>
        /// Gets distance data from the Hokuyo sensor.
        /// </summary>
        /// <returns>Distance in 682 points in mm from the Hokuyo sensor.</returns>
        public int[] GetData()
        {
            int[] distanceValuesFromHokuyo = new int[maxBufferSize];
            return Capture(distanceValuesFromHokuyo);
        }

        private int[] Capture(int[] distanceValuesFromHokuyo)
        {
            if (!hokuyo.IsConnected())
            {
                Connect();
            }
            hokuyo.Capture(distanceValuesFromHokuyo);
            return distanceValuesFromHokuyo;
        }
    }
}
