using System;
using System.Dynamic;
using System.Security.Cryptography;

namespace Tello_Drone
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestNameAttributes : Attribute
    {
        public TestNameAttributes(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}