using System.Runtime.CompilerServices;

namespace Tello_Drone
{
    public class Missions : IMissions
    {
        private readonly IConsoleLogger _consoleLogger;
        private Drone _drone;
        
        public Missions( IDroneFactory droneFactory, IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
            _drone = droneFactory.CreateDrone;
        }

        public void RunMission1()
        {

        }

        private void MissionSetup()
        {
        }

    }
}