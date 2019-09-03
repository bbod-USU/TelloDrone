namespace Tello_Drone
{
    public class DroneFactory : IDroneFactory
    {
        private readonly IDroneCommands _droneCommands;
        private Drone _createDrone;

        public DroneFactory(IDroneCommands droneCommands)
        {
            _droneCommands = droneCommands;
        }

        public Drone CreateDrone => new Drone(_droneCommands);
    }
}