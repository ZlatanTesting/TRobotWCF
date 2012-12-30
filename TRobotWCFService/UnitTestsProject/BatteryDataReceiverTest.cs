using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsProject
{
    /// <summary>
    /// This is a test class for BatteryDataReceiver and is intended to contain all BatteryDataReceiver Unit Tests.
    /// </summary>
    [TestClass]
    public class BatteryDataReceiverTest
    {
        /// <summary>
        /// A test which tests if received value is not null.
        /// </summary>
        [TestMethod]
        public void BatteryReceiveDataIsNotNullTest()
        {
            //  Given
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver();
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
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver();
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
            BatteryDataReceiver batteryDataReceiver = new BatteryDataReceiver();
            DataReceiver expectedDataReceiver = DataReceiver.Battery;

            //  When
            DataReceiver actualDataReceiver = batteryDataReceiver.ReceiveData().DataReceiverType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
