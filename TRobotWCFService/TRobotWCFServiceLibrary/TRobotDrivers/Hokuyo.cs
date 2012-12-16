using System.Linq;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    internal class Hokuyo
    {
        private UrgCtrl.UrgCtrl hokuyo;
        private int baudRate;
        private int comPort;
        private const int maxBufferSize = 682;


        public Hokuyo(string comPort, int baudRate)
        {
            this.baudRate = baudRate;
            this.comPort = int.Parse(comPort.Substring(comPort.Count()-1,1));
        }

        public bool Connect()
        {
            if (hokuyo != null)
            {
                Disconnect();
            }

            hokuyo = new UrgCtrl.UrgCtrl();
            return hokuyo.Connect(comPort, baudRate);
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
