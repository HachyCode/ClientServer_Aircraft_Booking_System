using System;


namespace Client
{
    class ClientProgram
    {
        static void Main(string[] args)
        {

            new DataClient().Run(Math());


            Console.ReadKey(true);
        }

        public static string Math()
        {
            string answer = "2";
            return answer;
        }
    }
}
