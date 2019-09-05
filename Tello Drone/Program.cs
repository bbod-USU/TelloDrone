namespace Tello_Drone
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = BootStrapper.BootstrapSystem(new CoreModule());
            var missions = bootstrapper.Resolve<IMissions>();
            var consoleLogger = bootstrapper.Resolve<IConsoleLogger>();
            var consoleClient = new ConsoleClient(missions, consoleLogger);
            consoleClient.Run();
        }
    }
}
