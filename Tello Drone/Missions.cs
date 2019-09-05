namespace Tello_Drone
{
    public class Missions : IMissions
    {
        private Drone _drone;
        private int _setupRetry;
        
        public Missions( IDroneFactory droneFactory)
        {
            _drone = droneFactory.CreateDrone;
        }

        public void RunMission1()
        {
            MissionSetup();
            _drone.Up(20);
            _drone.Down(20);
            MissionTeardown();
        }

        private void MissionSetup()
        {
            var inCommandMode = false;
            while (inCommandMode != true && _setupRetry < 3)
            {
                inCommandMode = _drone.Command();
                _setupRetry++;
            }
            
            if (!_drone.InitialTakeOff())
                _drone.InitialTakeOff();
        }

        private void MissionTeardown()
        {
            _drone.Land();
        }

    }
}