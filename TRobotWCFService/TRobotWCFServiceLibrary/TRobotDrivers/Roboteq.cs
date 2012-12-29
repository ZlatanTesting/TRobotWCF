using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace TRobotWCFServiceLibrary.TRobotDrivers
{
    /// <summary>
    /// Supports the RoboteQ.
    /// </summary>
    internal class Roboteq
    {
        private SerialPort serialPort;
        private string comPortName;
        private int baudRate;
        private const int _encoderCpr = 3600;
        private const int _acceleration = 30; 
	    private const int _deceleration = 100;

        /// <summary>
        /// Constructs a Roboteq instance.
        /// </summary>
        /// <param name="comPortName">Com port name for the RoboteQ</param>
        /// <param name="baudRate">BaudRate for the com port</param>
        public Roboteq(String comPortName, int baudRate)
        {
            this.baudRate = baudRate;
            this.comPortName = comPortName;
        }

        /// <summary>
        /// Connects to the RoboteQ.
        /// </summary>
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
            serialPort.ReadTimeout = 50;
            serialPort.WriteTimeout = 50;

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
            DriveInit();
        }

        /// <summary>
        /// Disconnects from the RoboteQ.
        /// </summary>
        public void Disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        /// <summary>
        /// Sets motors power.
        /// </summary>
        /// <param name="leftWheel">Left wheel power in percents.</param>
        /// <param name="rightWheel">Right wheel power in percents.</param>
        public void SetPower(double leftWheel, double rightWheel)
        {
            WriteOperation(WriteOperationType.RuntimeCommand, "M", (int)(leftWheel * 10), (int)(rightWheel * 10));
        }

        /// <summary>
        /// Sets motors power.
        /// </summary>
        /// <param name="leftWheel">Left wheel power in percents.</param>
        /// <param name="rightWheel">Right wheel power in percents.</param>
        public void SetDriverSpeed(int leftWheel, int rightWheel)
        {
            //WriteOperation(WriteOperationType.SetConfig, "MVEL", 1, (int)(speed*115));
            //WriteOperation(WriteOperationType.SetConfig, "MVEL", 2, (int)(speed*115));
            
            WriteOperation(WriteOperationType.SetConfig, "MMOD", 1, 1);
            WriteOperation(WriteOperationType.SetConfig, "MMOD", 2, 1);

            WriteOperation(WriteOperationType.RuntimeCommand, "G", 1, leftWheel * 10);
            WriteOperation(WriteOperationType.RuntimeCommand, "G", 2, rightWheel * 10);
        }

        /// <summary>
        /// Gets velocity from encoders.
        /// </summary>
        /// <returns>Velocity for left and right wheels in RPM.</returns>
        public String[] GetSpeed()
        {
            return WriteOperation(WriteOperationType.RuntimeQuery, "S", 0);
        }

        /// <summary>
        /// Gets data from the batteries.
        /// </summary>
        /// <returns>Volts * 10 from batteries.</returns>
        public String GetBatteryVoltage()
        {
            List<int> channelNumber = new List<int>();
            channelNumber.Add(2);
            return WriteOperation(WriteOperationType.RuntimeQuery, "V", channelNumber).First();
        }

        /// <summary>
        /// Gets chipset's temperature from the thermometer.
        /// </summary>
        /// <returns>Temperature of chipset in degrees C.</returns>
        public String GetTemperature()
        {
            List<int> channelNumber = new List<int>();
            channelNumber.Add(2);
            return WriteOperation(WriteOperationType.RuntimeQuery, "T", channelNumber).First();
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
            serialPort.DiscardInBuffer();
            serialPort.WriteLine(command);

            if ((opType == WriteOperationType.RuntimeQuery) || (opType == WriteOperationType.GetConfig))
            {
                string response = "";
                while (response.Length == 0)
                {
                    System.Threading.Thread.Sleep(10);
                    response = serialPort.ReadLine();

                    if (response.Contains("+"))
                    {
                        response = "";
                    }
                    else if (response.Contains("-"))
                    {
                        response = "";
                    }
                }
                int pos = response.IndexOf("=");
                string reply = response.Substring(pos + 1);
                return reply.Split(':');
            }
            return null;
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

        private void DriveInit()
        {
            // All motors in open-loop speed - default
            WriteOperation(WriteOperationType.SetConfig, "MMOD", 1, 0);
            WriteOperation(WriteOperationType.SetConfig, "MMOD", 2, 0);
        	
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
            WriteOperation(WriteOperationType.RuntimeCommand, "AC", 1, _acceleration);
            WriteOperation(WriteOperationType.RuntimeCommand, "AC", 2, _acceleration);
            WriteOperation(WriteOperationType.RuntimeCommand, "DC", 1, _deceleration);
            WriteOperation(WriteOperationType.RuntimeCommand, "DC", 2, _deceleration);

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