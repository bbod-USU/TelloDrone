using System;
using System.Net;

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
