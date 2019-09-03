using System.Dynamic;

namespace Tello_Drone
{
    public interface IDroneFactory
    {
        Drone CreateDrone { get; }
        
    }
}