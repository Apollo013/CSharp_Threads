using System;

namespace CSharp_Threads_Revisited
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceConditions.Run();

            Console.ReadKey();
        }
    }
}
