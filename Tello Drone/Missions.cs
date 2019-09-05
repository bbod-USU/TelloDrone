using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DryIoc;

namespace Tello_Drone
{
    public class Missions : IMissions
    {
        private readonly IConsoleLogger _consoleLogger;
        private Drone _drone;
        private int setupRetry = 0;
        
        public Missions( IDroneFactory droneFactory, IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
            _drone = droneFactory.CreateDrone;
        }

        public void RunMission1()
        {
            MissionSetup();
            _drone.Down(3);
            _drone.Up(3);
        }

        private void MissionSetup()
        {
            var inCommandMode = false;
            while (inCommandMode != true && setupRetry < 3)
            {
                inCommandMode = _drone.Command();
                setupRetry++;
                _consoleLogger.Log(inCommandMode.ToString());
            }
        }

    }
}