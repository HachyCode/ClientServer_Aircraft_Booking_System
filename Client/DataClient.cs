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
        //variables
        IPHostEntry ipHostDetails;
        IPAddress ipAddressDetail;
        IPEndPoint localEndPoint;

        Socket sender;

        DataItem request;
        DataItem dataItem;

        string serialisedItem;

        //sent
        byte[] messageToSend;
        int byteSent;

        //received
        byte[] messageReceived;
        int byteRequest;

        //response
        string response;

        public void Run(string data)
        {
            try
            {
                ipHostDetails = Dns.GetHostEntry(Dns.GetHostName());
                ipAddressDetail = ipHostDetails.AddressList[0];
                localEndPoint = new IPEndPoint(ipAddressDetail, 4747);

                sender = new Socket(ipAddressDetail.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    request = new DataItem(data);
                    serialisedItem = DataItemSerialisation.GetSerialisedDataItem(request);
                    sender.Connect(localEndPoint);
                    //Console.WriteLine($"Socket connected to: {sender.RemoteEndPoint}");

                    //send data request to server
                    messageToSend = Encoding.Unicode.GetBytes(serialisedItem + "<EOF>");
                    byteSent = sender.Send(messageToSend);

                    //Data buffer
                    messageReceived = new byte[4096];

                    //Recieve answer from server
                    byteRequest = sender.Receive(messageReceived);
                    response = Encoding.Unicode.GetString(messageReceived, 0, byteRequest);

                    dataItem = DataItemSerialisation.GetDataItem(response);
                    //Console.WriteLine($"Received from Server: {dataItem.Id}");
                    Console.WriteLine(DataManagment.DataLayout(dataItem.Id));
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
