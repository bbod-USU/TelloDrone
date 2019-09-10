using Moq;
using NUnit.Framework;
using Tello_Drone;

namespace Tests
{
    public class DroneFactoryTests
    {
        private Mock<IDroneCommands> _mockDroneCommands;

        [SetUp]
        public void Setup()
        {
            _mockDroneCommands = new Mock<IDroneCommands>();
        }

        [Test]
        public void CreateDroneTests()
        {
            var droneFactory = new DroneFactory(_mockDroneCommands.Object);
            var drone = droneFactory.CreateDrone;
            Assert.AreEqual(typeof(Drone), drone.GetType());
        }
        
}
}