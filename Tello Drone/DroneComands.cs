using System;

namespace Tello_Drone
{
    public class DroneComands : IDroneCommands 
    {
        private readonly IUdpClientWrapper _udpClient;

        public DroneComands()
        {
            var udpClient = new UdpClientWrapper(127001, 8000);
            _udpClient = udpClient;
        }

        public bool Forward() => SendCommand("Forward");

        public bool Reverse() => SendCommand("Reverse");

        public bool Up() => SendCommand("Up");

        public bool Down() => SendCommand("Down");

        private bool SendCommand(string message)
        {
            return _udpClient.TrySend(message, 1_500);
        }
    }
}
