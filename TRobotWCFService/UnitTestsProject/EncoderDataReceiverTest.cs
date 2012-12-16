using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    /// <summary>
    ///This is a test class for EncoderDataReceiverTest and is intended
    ///to contain all EncoderDataReceiverTest Unit Tests
    ///</summary>
    [TestClass]
    public class EncoderDataReceiverTest
    {
        private const int roboteQBaudRate = 115200;
        private const string roboteQComPort = "COM9";
        private const string key = "speed";
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
        public void EncoderReceiveDataTest()
        {
            EncoderDataReceiver ecoderDataReceiver = new EncoderDataReceiver(roboteQ);
            Data actual = ecoderDataReceiver.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }
    }
}
