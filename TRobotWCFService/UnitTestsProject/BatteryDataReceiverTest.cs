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
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private const string key = "charge";
        private static Roboteq roboteQ;

        [TestInitialize]
        public void MyTestInitialize()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
            roboteQ.Connect();
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            roboteQ.Disconnect();
        }

        /// <summary>
        ///A test for ReceiveData - isNotNull
        ///</summary>
        [TestMethod]
        public void ReceiveDataTest()
        {
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver(roboteQ);
            Data actual = batteryDataReceiver.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }
    }
}
