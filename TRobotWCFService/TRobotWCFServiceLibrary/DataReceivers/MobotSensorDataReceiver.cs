using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;
using System;

namespace TRobotWCFServiceLibrary.DataReceivers
{
    internal class MobotSensorDataReceiver : IDataReceiver
    {
        private const int arduinoBaudRate = 9600;
        private const string arduinoComPort = "COM11";
        private Arduino arduino;
        private const string key = "distance";

        public MobotSensorDataReceiver()
        {
            arduino = new Arduino(arduinoComPort, arduinoBaudRate);
        }

        /// <summary>
        ///     This is mock method. This method always returns 200cm.
        ///     Range for this sensor is (5 - 350 cm).
        ///     The key for measured distance is 'distance'.
        /// </summary>
        public Data ReceiveData()
        {
            Data data = new Data();
            data.DataReceiverType = DataReceiver.Mobot;
            try
            {
                arduino.Connect();

                data.Dictionary.Add(key, 200);
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            finally
            {
                arduino.Disconnect();
            }
            return data;
        }
    }
}
