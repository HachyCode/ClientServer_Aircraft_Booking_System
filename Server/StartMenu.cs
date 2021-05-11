using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class StartMenu
    {
        public void StartMessage()
        {
            Console.Clear();
            Console.WriteLine("1: Adding info \n2: Removing info \n3: Finding info \n4: Printing all");
        }

        public void OnlyMessage()
        {
            Console.WriteLine("\n1: Adding info \n2: Removing info \n3: Finding info \n4: Printing all");
        }
    }
}
