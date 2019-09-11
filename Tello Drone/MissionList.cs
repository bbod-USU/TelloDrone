using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using FastExpressionCompiler.LightExpression;
using ImTools;
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