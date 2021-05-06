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
            Console.Write("2 * 2 = ");
            string answer = Console.ReadLine();

            Console.WriteLine($"Your answer: {answer}\n");
            return answer;
        }
    }
}
