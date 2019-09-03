using DryIoc;

namespace Tello_Drone
{
    public interface IModule
    {
        void Register(IContainer container);
        void Resolve(IContainer container);
    }
}