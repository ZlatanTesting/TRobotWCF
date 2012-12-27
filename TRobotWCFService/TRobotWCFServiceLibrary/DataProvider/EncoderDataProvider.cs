using System;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataProvider
{
    class EncoderDataProvider:IDataProvider
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;
        private Data driversData;

        public EncoderDataProvider(Data driversData) 
        {
            this.driversData = driversData;
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
        }

        public void ProvideData()
        {
            try
            {
                roboteQ.Connect();
                //roboteQ.SetDriverSpeed((int)driversData.Dictionary["leftWheelPower"], (int)driversData.Dictionary["rightWheelPower"]);
                roboteQ.SetPower(driversData.Dictionary["leftWheelPower"], driversData.Dictionary["rightWheelPower"]);
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            finally
            {
                roboteQ.Disconnect();
            }
        }
    }
}
