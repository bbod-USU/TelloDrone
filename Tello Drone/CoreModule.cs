using DryIoc;

namespace Tello_Drone
{
    public class CoreModule : IModule
    {
        public void Register(IContainer container)
        {
            container.Register<IDroneFactory, DroneFactory>(Reuse.Singleton);
            container.Register<IDroneCommands, DroneComands>(Reuse.Singleton);
            //container.Register<IMissions, Missions>(Reuse.Singleton);
            container.Register<IMissionCommander, MissionCommander>(Reuse.Singleton);
            container.Register<IUdpClientWrapperFactory, UdpClientWrapperFactory>(Reuse.Singleton);
            container.Register<IConsoleLogger, ConsoleLogger>(Reuse.Singleton);
            container.Register<IMissionList, MissionList>(Reuse.Singleton);
        }

        public void Resolve(IContainer container)
        {
        }
    }
    
}