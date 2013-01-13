using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;

namespace UnitTestsProject
{
    /// <summary>
    /// This is a test class for EncoderDataReceiver and is intended to contain all EncoderDataReceiver Unit Tests.
    /// </summary>
    [TestClass]
    public class EncoderDataReceiverTest
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
        public void EncoderReceiveDataIsNotNullTest()
        {
            //  Given
            EncoderDataReceiver ecoderDataReceiver = new EncoderDataReceiver(roboteQ);
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
            EncoderDataReceiver ecoderDataReceiver = new EncoderDataReceiver(roboteQ);
            SelectedDevice expectedDataReceiver = SelectedDevice.Encoder;

            //  When
            SelectedDevice actualDataReceiver = ecoderDataReceiver.ReceiveData().SelectedDeviceType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
