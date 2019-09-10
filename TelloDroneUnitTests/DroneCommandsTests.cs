
using System;
using System.Net.Sockets;
using ImTools;
using Moq;
using NUnit.Framework;
using Tello_Drone;

namespace Tests
{
    public class DroneCommandsTests
    {
        private Mock<IUdpClientWrapperFactory> _mockUdpClientFactory;
        private Mock<IUdpClientWrapper> _mockUdpClientWrapper;

        [SetUp]
        public void Setup()
        {
            _mockUdpClientFactory = new Mock<IUdpClientWrapperFactory>();
            _mockUdpClientWrapper = new Mock<IUdpClientWrapper>();
        }

        [Test]
        public void DownCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Down(10);
            _mockUdpClientWrapper.Verify(x => x.TrySend("down 10", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void UpCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Up(10);
            _mockUdpClientWrapper.Verify(x => x.TrySend("up 10", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ForwardCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Forward(10);
            _mockUdpClientWrapper.Verify(x => x.TrySend("forward 10", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ReverseCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Reverse(10);
            _mockUdpClientWrapper.Verify(x => x.TrySend("back 10", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void CommandStateTest()
        {
            _mockUdpClientWrapper.Setup(x => x.TrySend(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Command();
            _mockUdpClientWrapper.Verify(x => x.TrySend("command", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void LeftCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Left(10);
            _mockUdpClientWrapper.Verify(x => x.TrySend("left 10", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void RightCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Right(10);
            _mockUdpClientWrapper.Verify(x => x.TrySend("right 10", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void LeftFlipCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.LeftFlip();
            _mockUdpClientWrapper.Verify(x => x.TrySend("flip l", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void RightFlipCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.RightFlip();
            _mockUdpClientWrapper.Verify(x => x.TrySend("flip r", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void FrontFlipCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.FrontFlip();
            _mockUdpClientWrapper.Verify(x => x.TrySend("flip f", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void BackFlipCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.BackFlip();
            _mockUdpClientWrapper.Verify(x => x.TrySend("flip b", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void InitialTakeOffCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.InitialTakeOff();
            _mockUdpClientWrapper.Verify(x => x.TrySend("takeoff", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void TakeOffCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.TakeOff();
            _mockUdpClientWrapper.Verify(x => x.TrySend("takeoff", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void LandCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.Land();
            _mockUdpClientWrapper.Verify(x => x.TrySend("land", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void RotateClockwiseCommandTest()
        {
            _mockUdpClientFactory.Setup(f => f.Create()).Returns(_mockUdpClientWrapper.Object);
            var droneCommands = new DroneComands(_mockUdpClientFactory.Object);
            droneCommands.RotateClockWise(180);
            _mockUdpClientWrapper.Verify(x => x.TrySend("cw 180", It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}