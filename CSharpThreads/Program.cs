using CSharpThreads.ThreadExamples;
using CSharpThreads.Utilities;
using System;

namespace CSharpThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            A_ThreadTypes.Run();
            B_ThreadCreation.Run();
            C_ThreadPool.Run();
            FibonacciRun.Run();
            D_ExceptionHandling.Run();
            */

            E_ThreadPriority.Run();

            PrintUtility.PrintTitle("MAIN THREAD EXITING \nBackground Threads still running after main thread has finished because a Foreground Thread is still alive");

            Console.ReadLine();
        }
    }
}
