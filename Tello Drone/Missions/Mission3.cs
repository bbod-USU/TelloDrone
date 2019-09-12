namespace Tello_Drone.Missions
{
    public class Mission3 : IMissions
    {
        public void Run(Drone drone)
        {
            drone.Up(20);
            drone.FrontFlip();
            drone.BackFlip();
            drone.Left(20);
            drone.Right(20);
            drone.Reverse(30);
        }
    }
}