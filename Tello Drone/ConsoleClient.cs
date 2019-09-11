using System;

namespace Tello_Drone
{
    public class ConsoleClient
    {
        
        private readonly IMissionList _missionList;
        private readonly IConsoleLogger _consoleLogger;
        private readonly IMissionCommander _missionCommander;

        public ConsoleClient(IMissionList missionList, IConsoleLogger consoleLogger, IMissionCommander missionCommander)
        {
            _missionCommander = missionCommander;
            _missionList = missionList;
            _consoleLogger = consoleLogger;
        }

        public void Run()
        {
            while (true)
            {
                _consoleLogger.Log("Choose a mission to run.");
                for (int x = 0; x < _missionList.GetMissionList().Count; x++)
                {
                    var currentMission = _missionList.GetMissionList()[x];
                    _consoleLogger.Log($"{x+1}: {currentMission.Item1}");
                }


                var userInput = Convert.ToInt16(Console.ReadLine());
                _missionCommander.RunMission(_missionList.GetMissionList()[userInput-1].Item2);
                

            }
        }


    }
}
