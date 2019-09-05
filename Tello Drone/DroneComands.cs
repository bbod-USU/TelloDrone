

namespace Tello_Drone
{
    public class DroneComands : IDroneCommands 
    {
        private readonly IUdpClientWrapper _udpClient;

        public DroneComands(IConsoleLogger consoleLogger)
        {
            var udpClient = new UdpClientWrapper(consoleLogger);
            _udpClient = udpClient;
        }

        public void Forward(int x) =>SendCommand() ($"forward {x}");
        public void Reverse(int x) => SendCommand($"back {x}");
        public void Up(int z) => SendCommand($"up {z}");
        public void Down(int z) => SendCommand($"down {z}");
        public void Left(int y) => SendCommand($"left {y}");
        public void Right(int y) => SendCommand($"right {y}");
        public bool Command() => TrySendCommand("command");
        public bool InitialTakeOff() => TrySendCommand("takeoff");
        public void TakeOff() => SendCommand("takeoff");
        public void Land() => SendCommand("land");
        public void RotateClockWise(int r) => SendCommand($"cw {r}");
        
        
        
        
        

        private void SendCommand(string message)
        {
            var returnValue = _udpClient.TrySend(message, 0_500, 3);
            if (returnValue == false)
                SendCommand("land");
        }

        private bool TrySendCommand(string message)
        {
            return _udpClient.TrySend(message, 0_500, 3);

        }
    }
}




