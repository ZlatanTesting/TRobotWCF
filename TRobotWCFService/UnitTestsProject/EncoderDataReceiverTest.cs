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

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            roboteQ = new Roboteq(roboteQComPort, roboteQBaudRate);
            roboteQ.Connect();
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            roboteQ.Disconnect();
        }

        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}

        /// <summary>
        ///A test for ReceiveData - isNotNull
        ///</summary>
        [TestMethod]
        public void ReceiveDataTest()
        {
            EncoderDataReceiver ecoderDataReceiver = new EncoderDataReceiver(roboteQ);
            Data actual = ecoderDataReceiver.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }
    }
}
