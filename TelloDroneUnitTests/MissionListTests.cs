using System;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Moq;
using NUnit.Framework;
using Tello_Drone;

namespace TelloDroneUnitTests
{
    public class MissionListTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void MissionListTest()
        {
            var missionList = new MissionList();
            for (int i = 0; i < missionList.GetMissionList().Count; i++)
            {
                Assert.AreEqual(typeof(string), missionList.GetMissionList()[i].Item1.GetType());
                Assert.IsInstanceOf(typeof(IMissions), missionList.GetMissionList()[i].Item2);
            }
        }
    }
}