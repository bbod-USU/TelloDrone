using System;
using System.Runtime.CompilerServices;

namespace Tello_Drone
{
    public class ConsoleClient
    {
        
        private readonly IMissions _missions;
        private readonly IConsoleLogger _consoleLogger;

        public ConsoleClient(IMissions missions, IConsoleLogger consoleLogger)
        {
            _missions = missions;
            _consoleLogger = consoleLogger;
        }

        public void Run()
        {
            _consoleLogger.Log("Choose a mission to run.");
            _consoleLogger.Log("1: Mission 1");
            _consoleLogger.Log("2: Mission 2");
            _consoleLogger.Log("3: Mission 3");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    _missions.RunMission1();
                    break;
                default:
                    _consoleLogger.Log("Not A Valid Entry...Try Again");
                    Run();
                    break;
            }

        }


    }
}
