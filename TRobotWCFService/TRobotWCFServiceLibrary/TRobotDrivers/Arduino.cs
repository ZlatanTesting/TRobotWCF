using System;
using System.Linq;
using System.IO.Ports;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    /// <summary>
    /// Supports the Arduino.
    /// </summary>
    internal class Arduino
    {
        private SerialPort serialPort;
        private string comPortName;
        private int baudRate;

        /// <summary>
        /// Constructs a Arduino instance.
        /// </summary>
        /// <param name="comPortName">Com port name for the Arduino</param>
        /// <param name="baudRate">BaudRate for the com port</param>
        public Arduino(String comPortName, int baudRate)
        {
            this.baudRate = baudRate;
            this.comPortName = comPortName;
        }

        /// <summary>
        /// Connects to the Arduino.
        /// </summary>
        public void Connect()
        {
            if (serialPort != null)
            {
                Disconnect();
            }

            serialPort = new SerialPort(comPortName, baudRate);
            serialPort.NewLine = "$";

            try
            {
                serialPort.Open();
            }
             catch (Exception e)
            {
                Logger.Log(e);
            }
        }

        /// <summary>
        /// Disconnects from the Arduino.
        /// </summary>
        public void Disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        /// <summary>
        /// Gets data from the Sharp sensors.
        /// </summary>
        /// <returns>Volts from three Sharp sensors.</returns>
        public String[] GetSharpsData()
        {
            string returnMessage = "";

            while(returnMessage.Length != 36 || !TryToParse(returnMessage))
            {
                returnMessage = serialPort.ReadLine();
                if(returnMessage.Contains('#'))
                {
                    int length = returnMessage.Length - 1;
                    returnMessage = returnMessage.Substring(1, length);
                }
            }

            String[] sharps = new String[3];
            sharps[0] = returnMessage.Substring(0, 4);
            sharps[1] = returnMessage.Substring(4, 4);
            sharps[2] = returnMessage.Substring(8, 4);

            return sharps;
        }

        /// <summary>
        /// Gets data from the Mobot sensor.
        /// </summary>
        /// <returns>Distance form Mobot sensor in mm.</returns>
        public String GetMobotData()
        {
            string returnMessage = "";

            while (returnMessage.Length != 36 || !TryToParse(returnMessage))
            {
                returnMessage = serialPort.ReadLine();
                if (returnMessage.Contains('#'))
                {
                    int length = returnMessage.Length - 1;
                    returnMessage = returnMessage.Substring(1, length);
                }
            }
            return returnMessage.Substring(24, 4);
        }

        private bool TryToParse(String str)
        {
            try
            {
                for (int i = 0; i < str.Length; i = i + 4)
                {
                    Convert.ToInt16(str.Substring(i, 4), 16);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
