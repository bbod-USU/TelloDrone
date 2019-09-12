using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Tello_Drone;

namespace TelloDroneUnitTests
{
    public class MissionCommanderTests
    {
        private Mock<IDroneFactory> _mockDroneFactory;
        private Mock<IMissions> _mockMission;
        private Mock<Drone> _mockDrone;
        private Mock<IDroneCommands> _mockDroneCommands;

        [SetUp]
        public void SetUp()
        {
            _mockDroneFactory = new Mock<IDroneFactory>();
            _mockMission = new Mock<IMissions>();
            _mockDroneCommands = new Mock<IDroneCommands>();
            _mockDrone = new Mock<Drone>(_mockDroneCommands.Object);
        }

        [Test]
        public void RunMissionTest()
        {
            _mockDroneCommands.Setup(x => x.Command()).Returns(true);
            _mockDroneFactory.SetupGet(x => x.CreateDrone).Returns(_mockDrone.Object);
            var missionCommander = new MissionCommander(_mockDroneFactory.Object);
            missionCommander.RunMission(_mockMission.Object);
            _mockMission.Verify(x => x.Run(It.IsAny<Drone>()), Times.Once);
        }

        [Test]
        public void RunMissionSetupFailed()
        {
            _mockDroneCommands.Setup(x => x.Command()).Returns(false);
            _mockDroneFactory.SetupGet(x => x.CreateDrone).Returns(_mockDrone.Object);
            var missionCommander = new MissionCommander(_mockDroneFactory.Object);
            missionCommander.RunMission(_mockMission.Object);
            _mockMission.Verify(x => x.Run(It.IsAny<Drone>()), Times.Never);
        }
    }
}