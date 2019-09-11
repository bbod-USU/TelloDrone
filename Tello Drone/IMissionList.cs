using System.Collections.Generic;

namespace Tello_Drone
{
    public interface IMissionList
    {
        List<(string, IMissions)> GetMissionList();
    }
}