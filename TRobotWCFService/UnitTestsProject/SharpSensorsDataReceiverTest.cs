using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TRobotWCFServiceLibrary.TRobotDrivers;
using TRobotWCFServiceLibrary.Messages;

namespace UnitTestsProject
{
    
    
    /// <summary>
    /// This is a test class for SharpSensorDataReceiver and is intended to contain all SharpSensorDataReceiver Unit Tests.
    /// </summary>
    [TestClass()]
    public class SharpSensorsDataReceiverTest
    {
        /// <summary>
        /// A test which tests if received value from first Sharp is not null.
        /// </summary>
        [TestMethod()]
        public void ReceiveDataFromFirstSharpTest()
        {
            //  Given
            SharpSensorsDataReceiver sharpSensorsDataReceiver = new SharpSensorsDataReceiver();
            string key = "distance1";

            //  When
            double distanceFromFirstSharp = sharpSensorsDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(distanceFromFirstSharp);
        }

        /// <summary>
        /// A test which tests if received value from second Sharp is not null.
        /// </summary>
        [TestMethod()]
        public void ReceiveDataFromSecondSharpTest()
        {
            //  Given
            SharpSensorsDataReceiver sharpSensorsDataReceiver = new SharpSensorsDataReceiver();
            string key = "distance2";

            //  When
            double distanceFromSecondSharp = sharpSensorsDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(distanceFromSecondSharp);
        }

        /// <summary>
        /// A test which tests if received value from third Sharp is not null.
        /// </summary>
        [TestMethod()]
        public void ReceiveDataFromThirdSharpTest()
        {
            //  Given
            SharpSensorsDataReceiver sharpSensorsDataReceiver = new SharpSensorsDataReceiver();
            string key = "distance3";

            //  When
            double distanceFromThirdSharp = sharpSensorsDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(distanceFromThirdSharp);
        }

        /// <summary>
        /// A test which tests if received value from first Sharp is between 200 and 1500 mm or equals 0.
        /// </summary>
        [TestMethod()]
        public void ReceiveDataFromFirstSharpIsBetween200And1500Or0Test()
        {
            //  Given
            SharpSensorsDataReceiver sharpSensorsDataReceiver = new SharpSensorsDataReceiver();
            string key = "distance1";
            int minValue = 200;
            int maxValue = 1500;
            int undefinedValue = 0;

            //  When
            double distanceFromFirstSharp = sharpSensorsDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsTrue((distanceFromFirstSharp >= minValue && distanceFromFirstSharp <= maxValue) || distanceFromFirstSharp == undefinedValue);
        }

        /// <summary>
        /// A test which tests if received value from second Sharp is between 200 and 1500 mm or equals 0.
        /// </summary>
        [TestMethod()]
        public void ReceiveDataFromSecondSharpIsBetween200And1500Or0Test()
        {
            //  Given
            SharpSensorsDataReceiver sharpSensorsDataReceiver = new SharpSensorsDataReceiver();
            string key = "distance2";
            int minValue = 200;
            int maxValue = 1500;
            int undefinedValue = 0;

            //  When
            double distanceFromSecondSharp = sharpSensorsDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsTrue((distanceFromSecondSharp >= minValue && distanceFromSecondSharp <= maxValue) || distanceFromSecondSharp == undefinedValue);
        }

        /// <summary>
        /// A test which tests if received value from third Sharp is between 200 and 1500 mm or equals 0.
        /// </summary>
        [TestMethod()]
        public void ReceiveDataFromThirdSharpIsBetween200And1500Or0Test()
        {
            //  Given
            SharpSensorsDataReceiver sharpSensorsDataReceiver = new SharpSensorsDataReceiver();
            string key = "distance3";
            int minValue = 200;
            int maxValue = 1500;
            int undefinedValue = 0;

            //  When
            double distanceFromThirdSharp = sharpSensorsDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsTrue((distanceFromThirdSharp >= minValue && distanceFromThirdSharp <= maxValue) || distanceFromThirdSharp == undefinedValue);
        }

        /// <summary>
        /// A test which tests if received data has valid device type.
        /// </summary>
        [TestMethod]
        public void SharpSensorsReceiveDataHasValidDeviceTypeTest()
        {
            //  Given 
            SharpSensorsDataReceiver sharpSensorsDataReceiver = new SharpSensorsDataReceiver();
            DataReceiver expectedDataReceiver = DataReceiver.Sharp;

            //  When
            DataReceiver actualDataReceiver = sharpSensorsDataReceiver.ReceiveData().DataReceiverType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
