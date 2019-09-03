namespace Tello_Drone
{
    public interface IDroneCommands
    {
        bool Forward();
        bool Reverse();
        bool Up();
        bool Down();
    }
}