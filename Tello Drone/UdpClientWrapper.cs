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
        private IPEndPoint _sendIpEndPoint;
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
            _sendIpEndPoint = new IPEndPoint(IPAddress.Parse(_droneConstants.DroneIPAddress), _droneConstants.DronePortNumber);
        } 
        public bool TrySend(string message, int timeout)
        {
            bool successfullFlag = false;
            while(retryCount < 3 && successfullFlag == false)
            {
                _client.Client.ReceiveTimeout = timeout;
                _client.Send(Encoding.ASCII.GetBytes(message), message.Length);

                try
                {
                    var bytes = _client.Receive(ref _sendIpEndPoint);
                    var returnMessage = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    if (returnMessage == "ok")
                        successfullFlag = true;
                    _consoleLogger.Log($"successfull flag = {successfullFlag}");

                }
                catch
                {
                    _consoleLogger.Log("Did not get a response from the drone retrying.");
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