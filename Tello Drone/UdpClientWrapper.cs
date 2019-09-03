using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tello_Drone
{
    internal class UdpClientWrapper : IUdpClientWrapper 
    {
        private readonly UdpClient _client;
        private const string LocalHost = "127.0.0.1";
        private readonly int _port = 8889;
        private IPEndPoint _ipEndPoint;
        private int retryCount = 0;
        

        public UdpClientWrapper(long ipAddress, int port)
        {
            _ipEndPoint = new IPEndPoint(ipAddress, port);
            _client = new UdpClient(LocalHost, _port);

        } 
        public bool TrySend(string message, int timeOut)
        { 
            if(retryCount < 3 )
            {
                _client.Send(Encoding.UTF8.GetBytes(message), 1, _ipEndPoint.Address.ToString(), _ipEndPoint.Port);
                var timer = new Stopwatch();
                timer.Start();
                while (timer.ElapsedMilliseconds <= timeOut)
                {
                    var bytes = _client.Receive(ref _ipEndPoint);
                    var returnMessage = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    if (returnMessage == "Ok") return true;
                }
            }
            return false;
        }
        
       public void Dispose()
       {
           _client?.Dispose();
       }
        

    }
}