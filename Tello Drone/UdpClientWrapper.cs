using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tello_Drone
{
    internal class UdpClientWrapper : IUdpClientWrapper
    {
        private readonly UdpClient _client;
        private IPEndPoint _sendIpEndPoint;
        private IConsoleLogger _consoleLogger;


        public UdpClientWrapper(IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
           consoleLogger.Log("Enter Drone IPAddress:");
            var droneIpAddress = Console.ReadLine();
            consoleLogger.Log("Enter Drone Port Number:");
           var dronePortNumber = Convert.ToInt32(Console.ReadLine());
            if (droneIpAddress != null)
            {
                _client = new UdpClient(droneIpAddress ?? throw new NullReferenceException($"{nameof(droneIpAddress)} was null."), dronePortNumber);
                _sendIpEndPoint = new IPEndPoint(IPAddress.Parse(droneIpAddress),
                    dronePortNumber);
            }
        } 
        public bool TrySend(string message, int timeout, int maxRetries)
        {
            _consoleLogger.Log($"Sending command to drone: {message}");
            bool successfullFlag = false;
            while(maxRetries >= 0 && successfullFlag == false)
            {
                _client.Client.ReceiveTimeout = timeout;
                _client.Send(Encoding.ASCII.GetBytes(message), message.Length);

                try
                {
                    var bytes = _client.Receive(ref _sendIpEndPoint);
                    var returnMessage = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    _consoleLogger.Log($"Drone responded with: {returnMessage}");
                    if (returnMessage == "ok")
                        successfullFlag = true;
                }
                catch
                {
                    _consoleLogger.Log($"Did not get a response from the drone will attempt {maxRetries.ToString()} more times");
                }

                maxRetries--;
            }
            return successfullFlag;
        }


        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}