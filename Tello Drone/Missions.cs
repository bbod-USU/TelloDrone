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

        public void SetUpDrone()
        {  
            var inCommandMode = false;
            while (inCommandMode != true && _setupRetry < 3)
            {
                inCommandMode = _drone.Command();
                _setupRetry++;
            }
        }
        public void RunMission1()
        {
            MissionSetup();
            _drone.Up(20);
            _drone.Down(20);
            MissionTeardown();
        }

        public void RunMission2()
        {
            MissionSetup();
            _drone.BackFlip();
            _drone.FrontFlip();
            _drone.Reverse(55);
            _drone.Forward(66);
            MissionTeardown();            
        }

        private void MissionSetup()
        {
          
            
            if (!_drone.InitialTakeOff())
                _drone.InitialTakeOff();
        }

        private void MissionTeardown()
        {
            _drone.Land();
        }

    }
}