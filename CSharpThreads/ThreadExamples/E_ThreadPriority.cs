using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    /// <summary>
    /// Demonstrates how to elevate priority of some threads
    /// </summary>
    public class E_ThreadPriority
    {
        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD PRIORITY");

            Thread t1 = new Thread(new ThreadStart(DoWork1));
            Thread t2 = new Thread(new ThreadStart(DoWork2));

            t1.Priority = ThreadPriority.Highest;   // HIGHEST 
            t2.Priority = ThreadPriority.Lowest;

            // Started in reverse order
            t2.Start();
            t1.Start();
            
        }


        private static void DoWork1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("DoWork1: " + i);
            }
        }

        private static void DoWork2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("DoWork2: " + i);
            }
        }
    }
}
