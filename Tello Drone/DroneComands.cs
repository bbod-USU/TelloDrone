

namespace Tello_Drone
{
    public class DroneComands : IDroneCommands 
    {
        private readonly IUdpClientWrapper _udpClient;

        public DroneComands(IUdpClientWrapperFactory udpClientWrapperFactory)
        {
            _udpClient = udpClientWrapperFactory.Create();
        }

        public void Forward(int x) =>SendCommand($"forward {x}");
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
        public void FrontFlip() => SendCommand($"flip f");
        public void BackFlip() => SendCommand($"flip b");
        public void RightFlip() => SendCommand($"flip r");
        public void LeftFlip() => SendCommand($"flip l");


        
        
        
        

        private void SendCommand(string message)
        {
            _udpClient.TrySend(message, 5_000, 3);
        }

        private bool TrySendCommand(string message)
        {
            return _udpClient.TrySend(message, 20_000, 3);
        }
    }
}




