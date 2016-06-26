using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class A_ThreadTypes
    {
        public static void Run()
        {
            PrintUtility.PrintTitle("FOREGROUND & BACKGROUND THREADS");
            PrintUtility.PrintSubTitle("Background Thread will still run after main thread has finished because a Foreground Thread is still alive");
            RunForegroundThread();
            RunBackgroundThread();
        }

        private static void RunForegroundThread()
        {
            Thread t1 = new Thread(PrintThread1);
            t1.Name = "Foreground";
            t1.Start();
        }

        private static void RunBackgroundThread()
        {
            Thread t2 = new Thread(PrintThread2);
            t2.Name = "Background";
            t2.IsBackground = true;     // BACKGROUND
            t2.Start();
        }

        private static void PrintThread1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.Name} running - {i}");
                Thread.Sleep(1000);
            }
        }

        private static void PrintThread2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.Name} running - {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
