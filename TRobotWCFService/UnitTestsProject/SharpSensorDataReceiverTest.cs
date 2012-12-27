using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    
    
    /// <summary>
    ///This is a test class for SharpSensorDataReceiverTest and is intended
    ///to contain all SharpSensorDataReceiverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SharpSensorDataReceiverTest
    {
        private const string key = "distance";

        /// <summary>
        ///A test for ReceiveData - data from first Sharp is not null
        ///</summary>
        [TestMethod()]
        public void ReceiveDataFromFirstSharpTest()
        {
            SharpSensorDataReceiver target = new SharpSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key+1]);
        }

        /// <summary>
        ///A test for ReceiveData - data from first Sharp is not null
        ///</summary>
        [TestMethod()]
        public void ReceiveDataFromSecondSharpTest()
        {
            SharpSensorDataReceiver target = new SharpSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key + 2]);
        }

        /// <summary>
        ///A test for ReceiveData - data from first Sharp is not null
        ///</summary>
        [TestMethod()]
        public void ReceiveDataFromThirdSharpTest()
        {
            SharpSensorDataReceiver target = new SharpSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key + 3]);
        }

        /// <summary>
        ///A test for ReceiveData - value from first sharp is between 200 and 1500
        ///</summary>
        [TestMethod()]
        public void ReceiveDataFromFirstSharpIsBetween200And1500Or0Test()
        {
            SharpSensorDataReceiver target = new SharpSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.IsTrue((actual.Dictionary[key + 1] >= 200 && actual.Dictionary[key + 1] <= 1500) || actual.Dictionary[key + 1] == 0);
        }

        /// <summary>
        ///A test for ReceiveData - value from second sharp is between 200 and 1500
        ///</summary>
        [TestMethod()]
        public void ReceiveDataFromSecondSharpIsBetween200And1500Or0Test()
        {
            SharpSensorDataReceiver target = new SharpSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.IsTrue((actual.Dictionary[key + 2] >= 200 && actual.Dictionary[key + 2] <= 1500) || actual.Dictionary[key + 2] == 0);
        }

        /// <summary>
        ///A test for ReceiveData - value from third sharp is between 200 and 1500
        ///</summary>
        [TestMethod()]
        public void ReceiveDataFromThirdSharpIsBetween200And1500Or0Test()
        {
            SharpSensorDataReceiver target = new SharpSensorDataReceiver();
            Data actual = target.ReceiveData();

            Assert.IsTrue((actual.Dictionary[key + 3] >= 200 && actual.Dictionary[key + 3] <= 1500) || actual.Dictionary[key + 3] == 0);
        }
    }
}
