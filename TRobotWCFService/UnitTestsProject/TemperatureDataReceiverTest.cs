using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            SelectedDevice expectedDataReceiver = SelectedDevice.Temperature;

            //  When
            SelectedDevice actualDataReceiver = temperatureDataReceiver.ReceiveData().SelectedDeviceType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
