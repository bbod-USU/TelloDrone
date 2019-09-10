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
<<<<<<< Updated upstream
            _drone.Reverse(300);
            _drone.Forward(66);
            _drone.Up(20);
            MissionTeardown();            
=======
            _drone.Forward(30);
            _drone.Land();
>>>>>>> Stashed changes
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