using System.Linq;
using System;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    internal class Hokuyo
    {
        private UrgCtrl.UrgCtrl hokuyo;
        private int baudRate;
        private int comPort;
        private const int maxBufferSize = 682;


        public Hokuyo(int comPort, int baudRate)
        {
            this.baudRate = baudRate;
            this.comPort = comPort;
        }

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

        public void Disconnect()
        {
            if (hokuyo.IsConnected())
            {
                hokuyo.Disconnect();
            }
        }

        public int[] GetData()
        {
            int[] distanceValuesFromHokuyo = new int[maxBufferSize];

            return Capture(distanceValuesFromHokuyo);
        }

        public int[] GetData(int pointsNumber)
        {
            int[] distanceValuesFromHokuyo = new int[pointsNumber];

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
