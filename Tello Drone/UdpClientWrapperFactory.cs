namespace Tello_Drone
{
    public class UdpClientWrapperFactory : IUdpClientWrapperFactory
    {
        private readonly IConsoleLogger _consoleLogger;

        public UdpClientWrapperFactory(IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
        }
        public IUdpClientWrapper Create()
        {
            return new UdpClientWrapper(_consoleLogger);
        }
    }
}