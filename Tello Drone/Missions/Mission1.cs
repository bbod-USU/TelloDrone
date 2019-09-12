namespace Tello_Drone.Missions
{
    public class Mission1 : IMissions
    {

        public void Run(Drone drone)
        {
            drone.Up(20); 
            drone.Forward(20);
            drone.RotateClockWise(90);
            drone.BackFlip();
        }
    }
}