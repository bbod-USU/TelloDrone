using System.Dynamic;

namespace Tello_Drone
{
    public interface IUdpClientWrapperFactory
    {
        IUdpClientWrapper Create();
    }
}