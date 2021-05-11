using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class ServerModel
    {
        //Properties
        public static bool end = false;

        //Plane properties
        public static Planes AircraftType { get; set; }
        public static Cities Destination { get; set; }
        public static Cities Origin { get; set; }
        public static int SeatAmount { get; set; }

        //Flight properties
        public static DateTime DepartureTime { get; set; }
        public static DateTime ArrivalTime { get; set; }
        public static decimal Cost { get; set; }
        public static SeatStates[] PlaceStates { get; set; }
        public static SeatTypes[] PlaceTypes { get; set; }
        public static int FlightBarcode { get; set; }

        //Instantiating
        static Hashing hash;
        public static Storage store;
        IFlight[] planes;
        static IFlight currentFlight;
        public static StartMenu stMenu = new StartMenu();

        public ServerModel()
        {
            hash = new Hashing();
            store = new Storage();
            planes = new IFlight[Hashing.arraySize];
        }

        //Methods
        public void Run()
        {
            StoreInput();
        }

        private static IFlight GetPlane(SeatStates[] s_state, SeatTypes[] s_type, Planes plane, Cities des, Cities ori, int seatAmount, DateTime DepTime, DateTime ArivTime, decimal cost, int flighBarcode)
        {
            IFlight createdFlight = null;
            switch (plane)
            {
                case Planes.Earth2K:
                    createdFlight = new Earth2K();
                    break;
                //case PlaneType.MarsBr:
                //    createdDwelling = new MarsBr();
                //    break;
                //case PlaneType.NeptuneAqua:
                //    createdDwelling = new NeptuneAqua();
                //    break;
                //case PlaneType.UrainusLamba:
                //    createdDwelling = new UrainusLamba();
                //    break;
                //case PlaneType.SaturnRhea:
                //    createdDwelling = new SaturnRhea();
                //    break;
            }
            createdFlight.Cost = cost;
            createdFlight.ArrivalTime = ArivTime;
            createdFlight.DepartureTime = DepTime;
            return createdFlight;
        }

        public int GetLookup(int flightBarcode)
        {
            int hashValue = (flightBarcode).GetHashCode();
            return hashValue % Hashing.arraySize;
        }

        public static void UserInput()
        {
            DepartureTime = new DateTime(2021, 07, 07, 06, 30, 00);
            ArrivalTime = new DateTime(2021, 07, 07, 14, 20, 00);
            Cost = 20.00m;
        }

        public static void StoreInput()
        {
            UserInput();
            currentFlight = GetPlane(PlaceStates, PlaceTypes, AircraftType, Destination, Origin, SeatAmount, DepartureTime, ArrivalTime, Cost, FlightBarcode);
            hash.Value = currentFlight.GetValue(currentFlight.FlightBarcode);
            store.AddingStorage(
                hash.AddingHash(hash.HashKey(hash.Value)),
                currentFlight.PlaceStates,
                currentFlight.PlaceTypes,
                currentFlight.AircraftType,
                currentFlight.Destination,
                currentFlight.Origin,
                currentFlight.SeatAmount,
                currentFlight.DepartureTime,
                currentFlight.ArrivalTime,
                currentFlight.Cost,
                currentFlight.FlightBarcode
                );
        }

        public static void Edit()
        {

        }
        public static string FindInput(int flighNumber)
        {
            return store.FindingStorage(flighNumber);
        }
    }
}
