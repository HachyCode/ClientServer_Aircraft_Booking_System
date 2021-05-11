using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Earth2K : Flight
    {
        public Earth2K() : base() { }
        public override Planes AircraftType { get { return Planes.Earth2K; } }
        public override Cities Destination { get { return Cities.London; } }
        public override Cities Origin { get { return Cities.NewYork; } }
        public override int SeatAmount { get { return 100; } }
    }
}
