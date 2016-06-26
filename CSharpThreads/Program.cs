using CSharpThreads.ThreadExamples;
using System;

namespace CSharpThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            A_ThreadTypes.Run();
            B_ThreadCreation.Run();
            C_ThreadPool.Run();
            Console.WriteLine("MAIN THREAD EXITING");
            Console.ReadLine();
        }
    }
}
