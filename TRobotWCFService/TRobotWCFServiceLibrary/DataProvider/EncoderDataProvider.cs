using System;
using TRobotWCFServiceLibrary.Messages;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Utils;

namespace TRobotWCFServiceLibrary.DataProvider
{
    /// <summary>
    /// Data Provider for the TRobot's encoders.
    /// </summary>
    class EncoderDataProvider:IDataProvider
    {
        private Roboteq roboteQ;
        private Data driversData;

        /// <summary>
        /// Constructs a EncoderDataProvider instance.
        /// </summary>
        /// <param name="driversData">Data object with information about left and right wheel power. It must be in the Dictionary wiht keys: "leftWheelPower" and "rightWheelPower".</param>
        public EncoderDataProvider(Data driversData, Roboteq roboteQ) 
        {
            this.driversData = driversData;
            this.roboteQ = roboteQ;
        }

        /// <summary>
        /// Provides speed data to the TRobot's encoders.
        /// </summary>
        public void ProvideData()
        {
            try
            {
                //roboteQ.SetDriverSpeed((int)driversData.Dictionary["leftWheelPower"], (int)driversData.Dictionary["rightWheelPower"]);
                roboteQ.SetPower(driversData.Dictionary["leftWheelPower"], driversData.Dictionary["rightWheelPower"]);
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
        }
    }
}
