using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    /// <summary>
    ///This is a test class for TemperatureDataReceiverTest and is intended
    ///to contain all TemperatureDataReceiverTest Unit Tests
    ///</summary>
    [TestClass]
    public class TemperatureDataReceiverTest
    {
        private const string key = "temperature";

        /// <summary>
        ///A test for ReceiveData - isNotNull
        ///</summary>
        [TestMethod]
        public void TemperatureReceiveDataIsNotNullTest()
        {
            TemperatureDataReceiver temperatureDataReceiver = new TemperatureDataReceiver();
            Data actual = temperatureDataReceiver.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }
    }
}
