using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Moq;
using NUnit.Framework;
using Tello_Drone;

namespace TelloDroneUnitTests
{
    public class DroneTests
    {
        private Mock<IDroneCommands> _mockDroneCommands;
        [SetUp]
        public void SetUp()
        {
            _mockDroneCommands = new Mock<IDroneCommands>();
        }

        [Test]
        public void ValidForwardTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.Forward(It.IsAny<int>());
            _mockDroneCommands.Verify(x => x.Forward(It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ValidReverseTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.Reverse(It.IsAny<int>());
            _mockDroneCommands.Verify(x => x.Reverse(It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ValidUpTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.Up(It.IsAny<int>());
            _mockDroneCommands.Verify(x => x.Up(It.IsAny<int>()), Times.Once);
        }
        
        
        [Test]
        public void ValidDownTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.Down(It.IsAny<int>());
            _mockDroneCommands.Verify(x => x.Down(It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ValidLeftTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.Left(It.IsAny<int>());
            _mockDroneCommands.Verify(x => x.Left(It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ValidRightTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.Right(It.IsAny<int>());
            _mockDroneCommands.Verify(x => x.Right(It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ValidFrontFlipTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.FrontFlip();
            _mockDroneCommands.Verify(x => x.FrontFlip(), Times.Once);
        }
        
        [Test]
        public void ValidBackFlipTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.BackFlip();
            _mockDroneCommands.Verify(x => x.BackFlip(), Times.Once);
        }
        
        [Test]
        public void ValidLeftFlipTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.LeftFlip();
            _mockDroneCommands.Verify(x => x.LeftFlip(), Times.Once);
        }
        
        [Test]
        public void ValidRightFlipTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.RightFlip();
            _mockDroneCommands.Verify(x => x.RightFlip(), Times.Once);
        }
        
        [Test]
        public void CommandTest()
        {
            _mockDroneCommands.Setup(x => x.Command()).Returns(true);
            var drone = new Drone(_mockDroneCommands.Object);
            Assert.AreEqual(true, drone.Command());
            _mockDroneCommands.Verify(x => x.Command(), Times.Once);
        }

        [Test]
        public void CommandReturnsFalse()
        {
            _mockDroneCommands.Setup(x => x.Command()).Returns(false);
            var drone = new Drone(_mockDroneCommands.Object);
            Assert.AreEqual(false, drone.Command());
            _mockDroneCommands.Verify(x => x.Command(), Times.Once);
        }
        
        [Test]
        public void LandTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.Land();
            _mockDroneCommands.Verify(x => x.Land(), Times.Once);
        }
        
        [Test]
        public void TakeOffTest()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.TakeOff();
            _mockDroneCommands.Verify(x => x.TakeOff(), Times.Once);
        }
        
        [Test]
        public void InitialTakeOffTest()
        {
            _mockDroneCommands.Setup(x => x.InitialTakeOff()).Returns(true);
            var drone = new Drone(_mockDroneCommands.Object);
            Assert.AreEqual(true, drone.InitialTakeOff());
            _mockDroneCommands.Verify(x => x.InitialTakeOff(), Times.Once);
        }
        
        [Test]
        public void RotateClockWise()
        {
            var drone = new Drone(_mockDroneCommands.Object);
            drone.RotateClockWise(It.IsAny<int>());
            _mockDroneCommands.Verify(x => x.RotateClockWise(It.IsAny<int>()), Times.Once);
        }
        
    }
}