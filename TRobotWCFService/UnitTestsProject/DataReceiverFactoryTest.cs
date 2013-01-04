using TRobotWCFServiceLibrary.DataReceivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsProject
{
    /// <summary>
    /// This is a test class for DataReceiverFactory and is intended to contain all DataReceiverFactory Unit Tests.
    /// </summary>
    [TestClass()]
    public class DataReceiverFactoryTest
    {
        /// <summary>
        /// A test which tests if got DataReceiver is BatteryDataReceiver.
        /// </summary>
        [TestMethod()]
        public void GetBatteryDataReceiverTest()
        {
            //  Given
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();
            SelectedDevice dataReceiverType = SelectedDevice.Battery;

            //  When
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(dataReceiverType);

            //  Then
            Assert.IsTrue(dataReceiver is BatteryDataReceiver);
        }

        /// <summary>
        /// A test which tests if got DataReceiver is EncoderDataReceiver.
        /// </summary>
        [TestMethod()]
        public void GetEncoderDataReceiverTest()
        {
            //  Given
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();
            SelectedDevice dataReceiverType = SelectedDevice.Encoder;

            //  When
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(dataReceiverType);

            //  Then
            Assert.IsTrue(dataReceiver is EncoderDataReceiver);
        }

        /// <summary>
        /// A test which tests if got DataReceiver is HokuyoSensorDataReceiver.
        /// </summary>
        [TestMethod()]
        public void GetHokuyoSensorDataReceiverTest()
        {
            //  Given
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();
            SelectedDevice dataReceiverType = SelectedDevice.Hokuyo;

            //  When
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(dataReceiverType);

            //  Then
            Assert.IsTrue(dataReceiver is HokuyoSensorDataReceiver);
        }

        /// <summary>
        /// A test which tests if got DataReceiver is SharpSensorsDataReceiver.
        /// </summary>
        [TestMethod()]
        public void GetSharpSensorsDataReceiverTest()
        {
            //  Given
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();
            SelectedDevice dataReceiverType = SelectedDevice.Sharp;

            //  When
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(dataReceiverType);

            //  Then
            Assert.IsTrue(dataReceiver is SharpSensorsDataReceiver);
        }

        /// <summary>
        /// A test which tests if got DataReceiver is TemperatureDataReceiver.
        /// </summary>
        [TestMethod()]
        public void GetTemperatureDataReceiverTest()
        {
            //  Given
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();
            SelectedDevice dataReceiverType = SelectedDevice.Temperature;

            //  When
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(dataReceiverType);

            //  Then
            Assert.IsTrue(dataReceiver is TemperatureDataReceiver);
        }

        /// <summary>
        /// A test which tests if got DataReceiver is MobotSensorDataReceiver.
        /// </summary>
        [TestMethod()]
        public void GetMobotSensorDataReceiverTest()
        {
            //  Given
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();
            SelectedDevice dataReceiverType = SelectedDevice.Mobot;

            //  When
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(dataReceiverType);

            //  Then
            Assert.IsTrue(dataReceiver is MobotSensorDataReceiver);
        }

        /// <summary>
        /// A test which tests if got DataReceiver is NullDataReceiver.
        /// </summary>
        [TestMethod()]
        public void GetNullDataReceiverTest()
        {
            //  Given
            DataReceiverFactory dataReceiverFactory = new DataReceiverFactory();
            SelectedDevice dataReceiverType = SelectedDevice.Drive;

            //  When
            IDataReceiver dataReceiver = dataReceiverFactory.GetDataReceiver(dataReceiverType);

            //  Then
            Assert.IsTrue(dataReceiver is NullDataReceiver);
        }
    }
}
