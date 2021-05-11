using System;

namespace Server
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            ServerModel serverModel = new ServerModel();
            serverModel.Run();
            new ServersData().Data();

            Console.ReadKey(true);
        }
    }
}
