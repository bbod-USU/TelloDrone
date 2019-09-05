using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Schema;

namespace Tello_Drone
{
    internal class UdpClientWrapper : IUdpClientWrapper
    {
        private readonly UdpClient _client;
        private int retryCount = 0;
        private IPEndPoint _ipEndPoint;
        private IDroneConstants _droneConstants;
        private IConsoleLogger _consoleLogger;


        public UdpClientWrapper(IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
           _droneConstants = new DroneConstants();
           consoleLogger.Log("Enter Drone IPAddress:");
            _droneConstants.DroneIPAddress = Console.ReadLine();
            consoleLogger.Log("Enter Drone Port Number:");
            _droneConstants.DronePortNumber = Convert.ToInt32(Console.ReadLine());
            _client = new UdpClient(_droneConstants.DroneIPAddress, _droneConstants.DronePortNumber);
            _ipEndPoint = new IPEndPoint(IPAddress.Parse(_droneConstants.DroneIPAddress), _droneConstants.DronePortNumber);
        } 
        public bool TrySend(string message, int timeOut)
        {
            bool successfullFlag = false;
            while(retryCount < 3 && successfullFlag == false)
            {
                _client.Client.ReceiveTimeout = 1_500;
                _client.Send(Encoding.UTF8.GetBytes(message), 1);

                try
                {
                    var bytes = _client.Receive(ref _ipEndPoint);
                    var returnMessage = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    if (returnMessage == "Ok")
                        successfullFlag = true;

                }
                catch
                {
                    _consoleLogger.Log("SHIT BROKE");
                }
                retryCount++;
            }
            return successfullFlag;
        }
        
       public void Dispose()
       {
           _client?.Dispose();
       }
        

    }
}