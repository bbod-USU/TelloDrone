using System;

namespace Tello_Drone
{
    public interface IConsoleLogger
    {
        event Action<string> LogReceived;

        void Log(string message);

    }
}