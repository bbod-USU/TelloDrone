using DryIoc;

namespace Tello_Drone
{
    public interface IDroneConstants
    {
        string DroneIPAddress { get; set; }
        int DronePortNumber { get; set; }
    }
}