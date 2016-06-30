using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class O_ManualResetEvent
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);

        public static void Run()
        {
            PrintUtility.PrintTitle("MANUAL RESET EVENT EXAMPLE");

            PrintUtility.PrintSubTitle("Start 3 named threads that block on a ManualResetEvent");

            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = $"Thread{i}";
                t.Start();
            }

            Thread.Sleep(500);

            PrintUtility.PrintSubTitle("When all three threads have started, press Enter to call Set() to release all threads.");
            Console.ReadLine();
            mre.Set();

            Thread.Sleep(500);

            PrintUtility.PrintSubTitle("When a ManualResetEvent is signaled, threads that call WaitOne() do not block. Press Enter to show this.");
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = $"Thread{i}";
                t.Start();
            }

            Thread.Sleep(500);

            PrintUtility.PrintSubTitle("Press Enter to call Reset(), so that threads once again block when they call WaitOne()");
            Console.ReadLine();
            mre.Reset();

            // Start a thread that waits on the ManualResetEvent.
            Thread t5 = new Thread(ThreadProc);
            t5.Name = "Thread5";
            t5.Start();

            Thread.Sleep(500);
            PrintUtility.PrintSubTitle("Press Enter to call Set() and conclude the demo");
            Console.ReadLine();

            mre.Set();

        }

        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine($"{name} starts and calls mre.WaitOne()");
            mre.WaitOne();
            Console.WriteLine($"{name} ends.");
        }
    }
}
