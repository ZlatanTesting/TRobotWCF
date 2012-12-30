﻿using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsProject
{
    /// <summary>
    /// This is a test class for HokuyoSensorDataReceiver and is intended to contain all HokuyoSensorDataReceiver Unit Tests.
    /// </summary>
    [TestClass]
    public class HokuyoSensorDataReceiverTest
    {
        /// <summary>
        /// A test which tests if received value on zero index is not null.
        /// </summary>
        [TestMethod]
        public void HokuyoReceiveDataOnZeroIndexIsNotNullTest()
        {
            //  Given
            HokuyoSensorDataReceiver hokuyoSensorDataReceiver = new HokuyoSensorDataReceiver();
            string key = "distance0";

            //  When
            double distanceFromZeroIndex = hokuyoSensorDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(distanceFromZeroIndex);
        }

        /// <summary>
        /// A test which tests if received value on 341st index is not null.
        /// </summary>
        [TestMethod]
        public void HokuyoReceiveDataOn341stIndexIsNotNullTest()
        {
            //  Given
            HokuyoSensorDataReceiver hokuyoSensorDataReceiver = new HokuyoSensorDataReceiver();
            string key = "distance341";

            //  When
            double distanceFrom341stIndex = hokuyoSensorDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(distanceFrom341stIndex);
        }

        /// <summary>
        /// A test which tests if received value on 681st index is not null.
        /// </summary>
        [TestMethod]
        public void HokuyoReceiveDataOn681stIndexIsNotNullTest()
        {
            //  Given
            HokuyoSensorDataReceiver hokuyoSensorDataReceiver = new HokuyoSensorDataReceiver();
            string key = "distance681";

            //  When
            double distanceFrom681stIndex = hokuyoSensorDataReceiver.ReceiveData().Dictionary[key];

            //  Then
            Assert.IsNotNull(distanceFrom681stIndex);
        }

        /// <summary>
        /// A test which tests if received data capacity is valid.
        /// </summary>
        [TestMethod]
        public void HokuyoValidCapacityOfReceivedDataTest()
        {
            //  Given
            HokuyoSensorDataReceiver hokuyoSensorDataReceiver = new HokuyoSensorDataReceiver();
            int expectedCapacityOfReceivedData = 682;

            //  When
            int actualCapacityOfReceivedData = hokuyoSensorDataReceiver.ReceiveData().Dictionary.Count;

            //  Then
            Assert.AreEqual(expectedCapacityOfReceivedData, actualCapacityOfReceivedData);
        }

        /// <summary>
        /// A test which tests if received data has valid device type.
        /// </summary>
        [TestMethod]
        public void HokuyoSensorsReceiveDataHasValidDeviceTypeTest()
        {
            //  Given 
            HokuyoSensorDataReceiver hokuyoSensorDataReceiver = new HokuyoSensorDataReceiver();
            DataReceiver expectedDataReceiver = DataReceiver.Hokuyo;

            //  When
            DataReceiver actualDataReceiver = hokuyoSensorDataReceiver.ReceiveData().DataReceiverType;

            //  Then
            Assert.AreEqual(expectedDataReceiver, actualDataReceiver);
        }
    }
}
