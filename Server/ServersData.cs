using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Sockets;
using LShared;

namespace Server
{
    class ServersData
    {
        DataItem response;
        public void Data()
        {
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostEntry.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 4747);

            Socket socketLisener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socketLisener.Bind(ipEndPoint);
                socketLisener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting for data input ...");

                    Socket clientSocket = socketLisener.Accept();

                    //Data buffer
                    byte[] bytes = new Byte[4096];
                    string data = null;

                    //Geting data from server
                    while (true)
                    {
                        int amountOfBytesReseved = clientSocket.Receive(bytes);
                        data += Encoding.Unicode.GetString(bytes, 0, amountOfBytesReseved);
                        if (data.IndexOf("<EOF>", StringComparison.Ordinal) > -1) break;
                    }

                    string serialisedXml = data.Substring(0, data.Length - 5);
                    DataItem dataItem = DataItemSerialisation.GetDataItem(serialisedXml);
                    Console.WriteLine($"\nData received: {dataItem.Id}\n");

                    string sheakData = DataManagmentServer.DataLayout(dataItem.Id);
                    response = new DataItem(sheakData);
                    Console.WriteLine($"Data send: \n{sheakData}\n");

                    string serialisedItem = DataItemSerialisation.GetSerialisedDataItem(response);
                    byte[] message = Encoding.Unicode.GetBytes(serialisedItem);

                    clientSocket.Send(message);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
