using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server
{
    class Control
    {
        //Chacks if key are pressed executs a specific task then key is pressed
        public void KeyPresses() 
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("End");
                    ServerModel.end = true;
                }

                else if (keyPressed == ConsoleKey.D1 || keyPressed == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    ServerModel.StoreInput();
                    Console.ForegroundColor = ConsoleColor.White;
                    ServerModel.stMenu.OnlyMessage();
                }

                else if (keyPressed == ConsoleKey.D3 || keyPressed == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    ServerModel.FindInput();
                    Console.ForegroundColor = ConsoleColor.White;
                    ServerModel.stMenu.OnlyMessage();
                }

                else if (keyPressed == ConsoleKey.D4 || keyPressed == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Hashing.PrintHashTable();
                    Console.ForegroundColor = ConsoleColor.White;
                    ServerModel.stMenu.OnlyMessage();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("wrong key");
                }
            }
        }
    }
}
