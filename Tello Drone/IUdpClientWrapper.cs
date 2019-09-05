using System;

namespace Tello_Drone
{
    public interface IUdpClientWrapper : IDisposable
    {
        bool TrySend(string message, int timeOut, int maxRetries);
    }
}