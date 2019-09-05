namespace Tello_Drone
{
    public class Drone
    {
        private readonly IDroneCommands _droneCommands;

        public Drone(IDroneCommands droneCommands)
        {
            _droneCommands = droneCommands;
        }

        public void Forward(int x) => _droneCommands.Forward(x);
        public void Reverse(int x) => _droneCommands.Reverse(x);
        public void Up(int z) => _droneCommands.Up(z);
        public void Down(int z) => _droneCommands.Down(z);
        public void Left(int y)  => _droneCommands.Left(y);
        public void Right(int y) => _droneCommands.Right(y);
        public bool Command() => _droneCommands.Command();
        public bool InitialTakeOff() => _droneCommands.InitialTakeOff();
        public void TakeOff() => _droneCommands.TakeOff();
        public void Land() => _droneCommands.Land();
        public void RotateClockWise(int r) => _droneCommands.RotateClockWise(r);


    }
}