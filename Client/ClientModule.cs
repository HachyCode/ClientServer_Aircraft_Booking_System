using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class ClientModule
    {
        public DataHandeling dataHandeling = new DataHandeling();
        public DataClient dataClient = new DataClient();

        public void Run()
        {
            dataClient.Run(dataHandeling.SendData());
            ClientView.ChouseFlight();
            ClientView.ChouseSeat();
            int flightChousen = ClientControl.ChouseFlight();
            int seatChousen = ClientControl.ChouseSeat();
            dataClient.Run(dataHandeling.FlightChousen($"{flightChousen}¶{seatChousen}");
            Console.ReadKey(true);
        }
    }
}
