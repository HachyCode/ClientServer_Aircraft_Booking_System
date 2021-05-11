using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Storage
    {
        private static int maxSeat = 150;

        private string[] storage = new string[Hashing.arraySize];
        private SeatStates[,] PlaceStatesStorage = new SeatStates[Hashing.arraySize, maxSeat];
        private SeatTypes[,] PlaceTypessStorage = new SeatTypes[Hashing.arraySize, maxSeat];

        public Storage() { }

        public void AddingStorage(int a_key, SeatStates[] s_state, SeatTypes[] s_type,Planes plane, Cities des, Cities ori, int seatAmount, DateTime DepTime, DateTime ArivTime,decimal cost, int flighBarcode)
        {
            storage[a_key] = $"Plane: {plane}\nDestination: {des}\nOrigin: {ori}\nSeat Amount: {seatAmount}\nDeparture Time: {DepTime}\nArrival Time: {ArivTime}\nCost: £{cost}\nFlightBarcode: {flighBarcode}";

            //Normaly, should use foreach loop, but it was giving a folty data
            for (int i = 0; i < s_state.Length; i++)
            {
                PlaceStatesStorage[a_key, i] = s_state[i];
            }
            for (int i = 0; i < s_type.Length; i++)
            {
                PlaceTypessStorage[a_key, i] = s_type[i];
            }
        }
        public void UpdatingStorage(int a_key, Planes type)
        {
            storage[a_key] = $"type: {type}\n";
        }

        public void RemovingStorage(int r_key)
        {
            storage[r_key] = null;
        }

        public string FindingStorage(int f_key)
        {
            return storage[f_key];
        }
    }
}
