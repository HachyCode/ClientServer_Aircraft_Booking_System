using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    interface IFlight
    {
        //Plane properties
        Planes AircraftType { get; }
        Cities Destination { get; }
        Cities Origin { get; }
        int SeatAmount { get; }

        //Flight properties
        DateTime DepartureTime { get; set; }
        DateTime ArrivalTime { get; set; }
        decimal Cost { get; set; }
        SeatStates[] PlaceStates { get; set; }
        SeatTypes[] PlaceTypes { get; set; }
        int FlightBarcode { get; }

        //Method
        string GetValue(int flightBarcode);
    }
}
