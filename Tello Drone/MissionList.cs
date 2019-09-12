using System.Collections.Generic;
using Tello_Drone.Missions;

namespace Tello_Drone
{
    public class MissionList : IMissionList
    {
        public List<(string, IMissions)> GetMissionList( )
        {
            var list = new List<(string, IMissions)>();
            
            list.Add(("Mission 1", new Mission1()));
            list.Add(("Mission 2", new Mission2()));
            list.Add(("Mission 3", new Mission3()));

            return list;
        }

    }
}