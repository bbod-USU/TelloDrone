namespace Tello_Drone.Missions
{
    public class Mission2: IMissions
    {
        public void Run(Drone drone)
        {
            drone.Forward(45);
            drone.BackFlip();
            drone.Reverse(45);
        }
    }
    
}