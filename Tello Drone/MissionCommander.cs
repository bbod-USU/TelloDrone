using System;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;

namespace Tello_Drone
{
    public class MissionCommander : IMissionCommander
    {
        private readonly Drone _drone;

        public MissionCommander(IDroneFactory droneFactory)
        {
            _drone = droneFactory.CreateDrone;
        }

        public void RunMission(IMissions mission)
        {
            SetUpDrone(3);
            mission.Run(_drone);
            TearDownDrone();
        }

        private void SetUpDrone(int retryCount)
        {
            var inCommandMode = false;
            while (inCommandMode != true && retryCount > 0)
            {
                inCommandMode = _drone.Command();
                retryCount--;
            }
            _drone.TakeOff();
        }

        private void TearDownDrone()
        {
            _drone.Land();
        }

    }
}