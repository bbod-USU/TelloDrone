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
            if(!SetUpDrone(3))
                return;
            mission.Run(_drone);
            TearDownDrone();
        }

        private bool SetUpDrone(int retryCount)
        {
            var inCommandMode = false;
            while (inCommandMode != true && retryCount > 0)
            {
                inCommandMode = _drone.Command();
                retryCount--;
            }

            if (!inCommandMode)
                return false;
            _drone.TakeOff();
            return true;
        }

        private void TearDownDrone()
        {
            _drone.Land();
        }

    }
}