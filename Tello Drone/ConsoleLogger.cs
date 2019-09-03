using System;

namespace Tello_Drone
{
    public class ConsoleLogger : IConsoleLogger
    {
        public event Action<string> LogReceived;

        public void Log(string message)
        {
            LogReceived?.Invoke(message);
            Console.WriteLine(message);
        }
    }
}