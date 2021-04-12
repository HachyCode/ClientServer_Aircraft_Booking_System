using System;


namespace Client
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            new DataClient().Run();

            Console.ReadKey(true);
        }
    }
}
