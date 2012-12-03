using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.IO.Ports;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    public class Roboteq
    {
        private SerialPort serialPort;
        private string comPortName;
        private int baudRate;
	    private int _encoderCpr = 48 * 75;
	    private int _acceleration = 30; 
	    private int _deceleration = 100;

        public Roboteq(String comPortName, int baudRate)
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

            serialPort = new SerialPort(comPortName, baudRate, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.None;
            serialPort.Encoding = Encoding.ASCII;
            serialPort.NewLine = "\r";
            serialPort.ReadTimeout = 1100;

            try
            {
                serialPort.Open();

                driveInit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
            }

        }

        public void Disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public bool IsSerialPortOpen()
        {
            return serialPort.IsOpen;
        }

        public void SetPower(double leftWheel, double rightWheel)
        {
            List<int> wheelPowers = new List<int>();
            wheelPowers.Add((int)(leftWheel * 1000));
            wheelPowers.Add((int)(rightWheel * 1000));

            WriteOperation(WriteOperationType.RuntimeCommand, "M", wheelPowers);
        }

        /// <summary>
        /// Sets power of motors.
        /// </summary>
        /// <param name="leftWheel">Left wheel power in percents.</param>
        /// <param name="rightWheel">Right wheel power in percents.</param>
        public void SetDriverSpeed(int leftWheel, int rightWheel)
        {
            //WriteOperation(WriteOperationType.SetConfig, "MVEL", 1, (int)(speed*115));
            //WriteOperation(WriteOperationType.SetConfig, "MVEL", 2, (int)(speed*115));
            
            
            //WriteOperation(WriteOperationType.SetConfig, "MMOD", 1, 1);
            //WriteOperation(WriteOperationType.SetConfig, "MMOD", 2, 1);

            WriteOperation(WriteOperationType.RuntimeCommand, "G", 0, (int)(leftWheel * 10));
            WriteOperation(WriteOperationType.RuntimeCommand, "G", 2, (int)(rightWheel * 10));
        }

        /// <summary>
        /// Returns speed in RPM.
        /// </summary>
        /// <returns>Speed in RPM.</returns>
        public String[] GetSpeed()
        {
            return WriteOperation(WriteOperationType.RuntimeQuery, "S", 0);
        }

        /// <summary>
        /// Returns volts * 10.
        /// </summary>
        /// <returns>Volts * 10</returns>
        public String[] GetBatteryVoltage()
        {
            List<int> channelNumber = new List<int>();
            channelNumber.Add(2);

            return WriteOperation(WriteOperationType.RuntimeQuery, "V", channelNumber);
        }

        /// <summary>
        /// Send specified command to Roboteq device. 
        /// Refer to Roboteq datasheet for a full list of available commands and their arguments.
        /// </summary>
        /// <param name="opType">Operation type. Possible: RuntimeCommand, Runtime Query, SetConfig, GetConfig</param>
        /// <param name="commandName">Command name.</param>
        /// <param name="arguments">List of arguments. Commands accept from 0 to 2 args</param>
        /// <returns>Response form motor controller in form of string array, or null if there was no reply.</returns>
        private string[] WriteOperation(WriteOperationType opType, string commandName, List<int> arguments)
        {
            if (!serialPort.IsOpen)
            { 
                Connect();
            }

            string prefix = "";

            switch (opType)
            {
                case WriteOperationType.RuntimeCommand:
                    prefix = "!";
                    break;
                case WriteOperationType.RuntimeQuery:
                    prefix = "?";
                    break;
                case WriteOperationType.GetConfig:
                    prefix = "~";
                    break;
                case WriteOperationType.SetConfig:
                    prefix = "^";
                    break;
            }

            string command = prefix + commandName;

            foreach (int argument in arguments)
            {
                string temp = Convert.ToString(argument);
                command += (" " + temp);
            }

            ClearSerialPortBuffer();

            serialPort.WriteLine(command);

            if ((opType == WriteOperationType.RuntimeQuery) || (opType == WriteOperationType.GetConfig))
            {
                string response = "";

                while (response.Length == 0)
                {
                    System.Threading.Thread.Sleep(10);
                    response = serialPort.ReadLine();
                }

                ClearSerialPortBuffer();

                int pos = response.IndexOf("=");
                string reply = response.Substring(pos + 1);
                return reply.Split(':');
            }
            else
            {
                ClearSerialPortBuffer();
                return null;
            }
        }

        /// <summary>
        /// Send specified command to Roboteq device. 
        /// Refer to Roboteq datasheet for a full list of available commands and their arguments.
        /// </summary>
        /// <param name="opType">Operation type. Possible: RuntimeCommand, Runtime Query, SetConfig, GetConfig</param>
        /// <param name="commandName">Command name.</param>
        /// <param name="arg1">Command argument</param>
        /// <returns>Response form motor controller in form of string array, or null if there was no reply.</returns>
        private string[] WriteOperation(WriteOperationType opType, string commandName, int arg1)
        {
            List<int> args = new List<int>();
            args.Add(arg1);
            return WriteOperation(opType, commandName, args);
        }

        /// <summary>
        /// Send specified command to Roboteq device. 
        /// Refer to Roboteq datasheet for a full list of available commands and their arguments.
        /// </summary>
        /// <param name="opType">Operation type. Possible: RuntimeCommand, Runtime Query, SetConfig, GetConfig</param>
        /// <param name="commandName">Command name.</param>
        /// <param name="arg1">First command argument</param>
        /// <param name="arg2">Second command argument</param>
        /// <returns>Response form motor controller in form of string array, or null if there was no reply.</returns>
        private string[] WriteOperation(WriteOperationType opType, string commandName, int arg1, int arg2)
        {
            List<int> args = new List<int>();
            args.Add(arg1);
            args.Add(arg2);
            return WriteOperation(opType, commandName, args);
        }

        /// <summary>
        /// Send specified command to Roboteq device. 
        /// Refer to Roboteq datasheet for a full list of available commands and their arguments.
        /// </summary>
        /// <param name="opType">Operation type. Possible: RuntimeCommand, Runtime Query, SetConfig, GetConfig</param>
        /// <param name="commandName">Command name. </param>
        /// <returns>Response form motor controller in form of string array, or null if there was no reply.</returns>
        private string[] WriteOperation(WriteOperationType opType, string commandName)
        {
            List<int> args = new List<int>();
            return WriteOperation(opType, commandName, args);
        }

        private void ClearSerialPortBuffer()
        {
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            //serialPort.Write("# C");
        }

        private void driveInit()
        {
            // All motors in open-loop speed - default
            WriteOperation(WriteOperationType.SetConfig, "MMOD", 1, 1);
            WriteOperation(WriteOperationType.SetConfig, "MMOD", 2, 1);  
        	
            // turn off command echo
            WriteOperation(WriteOperationType.SetConfig, "ECHOF", 1);

            // encoders configured as feedbacks
            WriteOperation(WriteOperationType.SetConfig, "EMOD", 1, 18);
            WriteOperation(WriteOperationType.SetConfig, "EMOD", 2, 34);


            // set encoder PPR
            WriteOperation(WriteOperationType.SetConfig, "EPPR", 1, _encoderCpr / 4);
            WriteOperation(WriteOperationType.SetConfig, "EPPR", 2, _encoderCpr / 4);

            // disable watchdog
            WriteOperation(WriteOperationType.SetConfig, "RWD", 1000, 1000);

            //set acceleration and deceleration
            //WriteOperation(WriteOperationType.RuntimeCommand, "AC", 1, _acceleration);
            //WriteOperation(WriteOperationType.RuntimeCommand, "AC", 2, _acceleration);
            //WriteOperation(WriteOperationType.RuntimeCommand, "DC", 1, _deceleration);
            //WriteOperation(WriteOperationType.RuntimeCommand, "DC", 2, _deceleration);

            // disable integral tracking error
            WriteOperation(WriteOperationType.SetConfig, "CLERD", 1, 0);
            WriteOperation(WriteOperationType.SetConfig, "CLERD", 2, 0);
        }

        private enum WriteOperationType
        {
            RuntimeCommand,
            RuntimeQuery,
            SetConfig,
            GetConfig,
        };
    }
}