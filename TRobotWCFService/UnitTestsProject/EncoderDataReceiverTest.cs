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
        private const string key = "speed";

        /// <summary>
        ///A test for ReceiveData - isNotNull
        ///</summary>
        [TestMethod]
        public void EncoderReceiveDataTest()
        {
            EncoderDataReceiver ecoderDataReceiver = new EncoderDataReceiver();
            Data actual = ecoderDataReceiver.ReceiveData();

            Assert.IsNotNull(actual.Dictionary[key]);
        }
    }
}
