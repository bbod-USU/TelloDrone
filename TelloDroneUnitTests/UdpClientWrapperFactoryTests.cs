using System.Threading;
using Moq;
using NUnit.Framework;
using Tello_Drone;

namespace TelloDroneUnitTests
{
    public class UdpClientWrapperFactoryTests
    {
        private Mock<IConsoleLogger> _mockConsoleLogger;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleLogger = new Mock<IConsoleLogger>();
        }

        [Test]
        public void CreateTest()
        {
           Assert.IsInstanceOf(typeof(UdpClientWrapper), new UdpClientWrapperFactory(_mockConsoleLogger.Object).Create());
        }
    }
}