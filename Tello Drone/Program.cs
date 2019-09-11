namespace Tello_Drone
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = BootStrapper.BootstrapSystem(new CoreModule());
            var missionList = bootstrapper.Resolve<IMissionList>();
            var missionCommander = bootstrapper.Resolve<IMissionCommander>();
            var consoleLogger = bootstrapper.Resolve<IConsoleLogger>();
            var consoleClient = new ConsoleClient(missionList, consoleLogger, missionCommander);
            consoleClient.Run();
        }
    }
}
