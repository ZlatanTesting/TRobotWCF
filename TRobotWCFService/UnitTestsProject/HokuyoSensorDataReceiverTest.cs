using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    /// <summary>
    ///This is a test class for HokuyoSensorDataReceiverTest and is intended
    ///to contain all HokuyoSensorDataReceiverTest Unit Tests
    ///</summary>
    [TestClass]
    public class HokuyoSensorDataReceiverTest
    {
        private const int hokuyoBaudRate = 19200;
        private const string hokuyoComPort = "COM8";
        private static Hokuyo hokuyo;
        private const string key = "distance0";

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
            hokuyo.Connect();
        }
        
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            hokuyo.Disconnect();
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
            HokuyoSensorDataReceiver target = new HokuyoSensorDataReceiver(hokuyo);
            Data actual = target.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }
    }
}
