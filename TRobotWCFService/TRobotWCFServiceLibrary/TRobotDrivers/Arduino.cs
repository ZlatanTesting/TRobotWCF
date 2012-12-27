using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    internal class Arduino
    {
        private SerialPort serialPort;
        private string comPortName;
        private int baudRate;

        public Arduino(String comPortName, int baudRate)
        {
            this.baudRate = baudRate;
            this.comPortName = comPortName;
        }

        public void Connect()
        {
            if (serialPort != null)
            {
                Disconnect();
            }

            serialPort = new SerialPort(comPortName, baudRate);
            serialPort.NewLine = "$";

            bool connected = false;
            while (!connected)
            {
                try
                {
                    serialPort.Open();
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
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        /// <summary>
        /// Returns volts from three Sharps in string table.
        /// </summary>
        /// <returns>String[] with volts</returns>
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

        private void ClearSerialPortBuffer()
        {
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
        }
    }
}
