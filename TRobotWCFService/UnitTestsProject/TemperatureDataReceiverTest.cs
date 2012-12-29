using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    /// <summary>
    /// This is a test class for TemperatureDataReceiver and is intended to contain all TemperatureDataReceiver Unit Tests.
    /// </summary>
    [TestClass]
    public class TemperatureDataReceiverTest
    {
        /// <summary>
        /// A test which tests if received value is not null.
        /// </summary>
        [TestMethod]
        public void TemperatureReceiveDataIsNotNullTest()
        {
            //  Given
            TemperatureDataReceiver temperatureDataReceiver = new TemperatureDataReceiver();
            string key = "temperature";

            //  When
            double temperature = temperatureDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(temperature);
        }

        /// <summary>
        /// A test which tests if received data has valid device type.
        /// </summary>
        [TestMethod]
        public void TemperatureReceiveDataHasValidDeviceTypeTest()
        {
            //  Given 
            TemperatureDataReceiver temperatureDataReceiver = new TemperatureDataReceiver();
            DataReceiver expectedDataReceiver = DataReceiver.Temperature;

            //  When
            DataReceiver actualDataReceiver = temperatureDataReceiver.ReceiveData().DataReceiverType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
