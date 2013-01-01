using System;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataProvider
{
    /// <summary>
    /// Data Provider for initializing the TRobot's encoders.
    /// </summary>
    class DriveInitializeDataProvider:IDataProvider
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;

        /// <summary>
        /// Constructs a DriveInitializeDataProvider instance.
        /// </summary>
        public DriveInitializeDataProvider() 
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
        }

        /// <summary>
        /// Initializes the TRobot's encoders.
        /// </summary>
        public void ProvideData()
        {
            try
            {
                roboteQ.Connect();
                roboteQ.DriveInit();
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
