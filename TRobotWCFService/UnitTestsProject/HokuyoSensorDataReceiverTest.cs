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
        private const int maxBufferSize = 682;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            hokuyo = new Hokuyo(hokuyoComPort, hokuyoBaudRate);
            hokuyo.Connect();
        }
        
        [TestCleanup()]
        public void MyTestCleanup()
        {
            hokuyo.Disconnect();
        }

        /// <summary>
        ///A test for ReceiveData - isNotNull
        ///</summary>
        [TestMethod]
        public void HokuyoReceiveDataTest()
        {
            HokuyoSensorDataReceiver target = new HokuyoSensorDataReceiver(hokuyo);
            Data actual = target.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }

        /// <summary>
        ///A test for ReceiveData - how many data point received
        ///</summary>
        [TestMethod]
        public void HokuyoNumberOfReceivedDataTest()
        {
            HokuyoSensorDataReceiver target = new HokuyoSensorDataReceiver(hokuyo);
            Data actual = target.ReceiveData();

            Assert.AreEqual(actual.Dictionary.Count, maxBufferSize);
        }
    }
}
