using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    /// <summary>
    ///This is a test class for HokuyoSensorDataReceiverTest and is intended
    ///to contain all HokuyoSensorDataReceiverTest Unit Tests
    ///</summary>
    [TestClass]
    public class HokuyoSensorDataReceiverTest
    {
        private const string key = "distance0";
        private const int maxBufferSize = 682;

        /// <summary>
        ///A test for ReceiveData - isNotNull
        ///</summary>
        [TestMethod]
        public void HokuyoReceiveDataTest()
        {
            HokuyoSensorDataReceiver target = new HokuyoSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }

        /// <summary>
        ///A test for ReceiveData - valid number of received data points
        ///</summary>
        [TestMethod]
        public void HokuyoValidNumberOfReceivedDataTest()
        {
            HokuyoSensorDataReceiver target = new HokuyoSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.AreEqual(maxBufferSize, actual.Dictionary.Count);
        }
    }
}
