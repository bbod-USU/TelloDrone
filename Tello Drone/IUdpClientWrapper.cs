using System;
using System.Net.Sockets;

namespace Tello_Drone
{
    public interface IUdpClientWrapper : IDisposable
    {
        bool TrySend(string message, int timeOut);
    }
}