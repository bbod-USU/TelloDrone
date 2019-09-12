using NUnit.Framework;
using Tello_Drone;

namespace TelloDroneUnitTests
{
    public class ConsoleLoggerTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LogTest()
        {
            var correctMessageSent = false;
            var console = new ConsoleLogger();
            var test = "Test";
            console.LogReceived += delegate(string s) { correctMessageSent |= s == test; };
            console.Log(test);
            Assert.AreEqual(correctMessageSent, true);
        }
    }
}