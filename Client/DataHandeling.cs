using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class DataHandeling
    {
        public string SendData()
        {
            return "SHT";
        }

        public string FlightChousen(string data)
        {
            //CFC = Client Flight Chousen
            return$"CFC{data}";
        }
    }
}
