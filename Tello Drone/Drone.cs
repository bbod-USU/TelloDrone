using System.Runtime.CompilerServices;

namespace Tello_Drone
{
    public class Drone : IDrone
    {
        private readonly IDroneCommands _droneCommands;

        public Drone(IDroneCommands droneCommands)
        {
            _droneCommands = droneCommands;
        }

        public bool Forward() => _droneCommands.Forward();
        public bool Reverse() => _droneCommands.Reverse();
        public bool Up() => _droneCommands.Up();
        public bool Down() => _droneCommands.Down();


    }
}