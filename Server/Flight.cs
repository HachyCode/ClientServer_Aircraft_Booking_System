using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Flight : IFlight
    { 
        //Plane properties
        public virtual Planes AircraftType { get { return Planes.Earth2K; } }
        public virtual Cities Destination { get { return Cities.London; } }
        public virtual Cities Origin { get { return Cities.London; } }
        public virtual int SeatAmount { get { return 100; } }

        //Flight properties
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Cost { get; set; }
        public SeatStates[] PlaceStates { get; set; }
        public SeatTypes[] PlaceTypes { get; set; }
        public int FlightBarcode { get; }

        protected Flight()
        {
            //Flight Barcode
            var random = new Random();
            FlightBarcode = random.Next(12345678, 99999999);

            //Seat state
            PlaceStates = new SeatStates[SeatAmount];

            for (int i = 0; i < PlaceStates.Length; i++)
            {
                PlaceStates[i] = SeatStates.Available;
            }
            //Seat type
            PlaceTypes = new SeatTypes[SeatAmount];

            for (int i = 0; i < PlaceTypes.Length; i++)
            {
                PlaceTypes[i] = SeatTypes.Economy;
            }

        }

        public string GetValue(int flightBarcode)
        {
            return $"{flightBarcode}";
        }
    }
}
