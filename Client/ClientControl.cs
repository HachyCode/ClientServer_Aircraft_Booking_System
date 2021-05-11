using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class ClientControl
    {
        private static int KeyEntered { get; set; }
        public static int ChouseFlight()
        {
            KeyEntered = Int32.Parse(Console.ReadLine());
            return KeyEntered;
        }
        public static int ChouseSeat()
        {
            KeyEntered = Int32.Parse(Console.ReadLine());
            return KeyEntered;
        }
    }
}
