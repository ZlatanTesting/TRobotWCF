using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    class Hokuyo
    {
        private UrgCtrl.UrgCtrl hokuyo;

        private int baudRate;
        private int comPort;


        public Hokuyo(string comPort, int baudRate)
        {
            hokuyo = new UrgCtrl.UrgCtrl();
            this.baudRate = baudRate;
            this.comPort = int.Parse(comPort.Substring(comPort.Count()-1,1));
        }

        public bool Connect()
        {
            return hokuyo.Connect(comPort, baudRate);
        }

        public void Disconnect()
        {
            hokuyo.Disconnect();
        }

        public int[] GetData()
        {
            int[] distanceValuesFromHokuyo = new int[hokuyo.MaxBufferSize];

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

        public int GetTimestamp()
        {
            return hokuyo.GetTimestamp();
        }

        public string[] GetVersionInformation()
        {
            return hokuyo.GetVersionInformation();
        }
    }
}
