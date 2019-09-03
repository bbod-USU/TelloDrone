using DryIoc;

namespace Tello_Drone
{
    public class CoreModule : IModule
    {
        public void Register(IContainer container)
        {
            container.Register<IDroneFactory, DroneFactory>(Reuse.Singleton);
            container.Register<IDroneCommands, DroneComands>(Reuse.Singleton);
            container.Register<IDrone, Drone>(Reuse.Singleton);
            container.Register<IMissions, Missions>(Reuse.Singleton);
            container.Register<IConsoleLogger, ConsoleLogger>(Reuse.Singleton);
        }

        public void Resolve(IContainer container)
        {
        }
    }
    
}