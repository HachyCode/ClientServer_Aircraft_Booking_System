using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using LShared;

namespace Client
{
    class DataClient
    {
        public void Run()
        {
            try
            {
                IPHostEntry ipHostDetails = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddressDetail = ipHostDetails.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddressDetail, 4747);

                Socket sender = new Socket(ipAddressDetail.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    DataItem request = new DataItem("Client info");
                    string serialisedItem = DataItemSerialisation.GetSerialisedDataItem(request);
                    sender.Connect(localEndPoint);
                    Console.WriteLine($"Socket connected to: {sender.RemoteEndPoint}");

                    //send data request to server
                    byte[] messageToSend = Encoding.ASCII.GetBytes(serialisedItem + "<EOF>");
                    int byteSent = sender.Send(messageToSend);

                    //Data buffer
                    byte[] messageReceived = new byte[4096];

                    //Recieve answer from server
                    int byteRecv = sender.Receive(messageReceived);
                    string response = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);

                    DataItem dataItem = DataItemSerialisation.GetDataItem(response);
                    Console.WriteLine($"Received from Server: {dataItem.Id}");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.ToString());
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
