using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    /// <summary>
    ///This is a test class for BatteryDataReceiverTest and is intended
    ///to contain all BatteryDataReceiverTest Unit Tests
    ///</summary>
    [TestClass]
    public class BatteryDataReceiverTest
    {
        private const string key = "charge";

        /// <summary>
        ///A test for ReceiveData - isNotNull
        ///</summary>
        [TestMethod]
        public void BatteryReceiveDataIsNotNullTest()
        {
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver();
            Data actual = batteryDataReceiver.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }

        /// <summary>
        ///A test for ReceiveData - value is between 0 and 100%
        ///</summary>
        [TestMethod]
        public void BatteryReceiveDataBetween0And100Test()
        {
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver();
            Data actual = batteryDataReceiver.ReceiveData();

            Assert.IsTrue(actual.Dictionary[key] >= 0 && actual.Dictionary[key] <= 100);
        }
    }
}
