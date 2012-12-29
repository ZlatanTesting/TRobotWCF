using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    /// <summary>
    /// This is a test class for EncoderDataReceiver and is intended to contain all EncoderDataReceiver Unit Tests.
    /// </summary>
    [TestClass]
    public class EncoderDataReceiverTest
    {
        /// <summary>
        /// A test which tests if received value is not null.
        /// </summary>
        [TestMethod]
        public void EncoderReceiveDataIsNotNullTest()
        {
            //  Given
            EncoderDataReceiver ecoderDataReceiver = new EncoderDataReceiver();
            string key = "speed";

            //  When
            double velocity = ecoderDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(velocity);
        }

        /// <summary>
        /// A test which tests if received data has valid device type.
        /// </summary>
        [TestMethod]
        public void EncoderReceiveDataHasValidDeviceTypeTest()
        {
            //  Given 
            EncoderDataReceiver ecoderDataReceiver = new EncoderDataReceiver();
            DataReceiver expectedDataReceiver = DataReceiver.Encoder;

            //  When
            DataReceiver actualDataReceiver = ecoderDataReceiver.ReceiveData().DataReceiverType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
