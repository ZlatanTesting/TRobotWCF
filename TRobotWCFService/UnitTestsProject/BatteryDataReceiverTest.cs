using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace UnitTestsProject
{
    /// <summary>
    /// This is a test class for BatteryDataReceiver and is intended to contain all BatteryDataReceiver Unit Tests.
    /// </summary>
    [TestClass]
    public class BatteryDataReceiverTest
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private Roboteq roboteQ;

        [TestInitialize()]
        public void TestInitialize()
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
            roboteQ.Connect();
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            roboteQ.Disconnect();
        }

        /// <summary>
        /// A test which tests if received value is not null.
        /// </summary>
        [TestMethod]
        public void BatteryReceiveDataIsNotNullTest()
        {
            //  Given
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver(roboteQ);
            string key = "charge";

            //  When
            double batteryCharge = batteryDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(batteryCharge);
        }

        /// <summary>
        /// A test which tests if received value is between 0 and 100%.
        /// </summary>
        [TestMethod]
        public void BatteryReceiveDataBetween0And100Test()
        {
            //  Given 
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver(roboteQ);
            string key = "charge";
            int minValue = 0;
            int maxValue = 100;

            //  When
            double batteryCharge = batteryDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsTrue(batteryCharge >= minValue && batteryCharge <= maxValue);
        }

        /// <summary>
        /// A test which tests if received data has valid device type.
        /// </summary>
        [TestMethod]
        public void BatteryReceiveDataHasValidDeviceTypeTest()
        {
            //  Given 
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver(roboteQ);
            SelectedDevice expectedDataReceiver = SelectedDevice.Battery;

            //  When
            SelectedDevice actualDataReceiver = batteryDataReceiver.ReceiveData().SelectedDeviceType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
