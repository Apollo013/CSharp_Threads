using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class P_AutoResetEvent
    {

        private static AutoResetEvent event_1 = new AutoResetEvent(true);
        private static AutoResetEvent event_2 = new AutoResetEvent(false);

        public static void Run()
        {
            PrintUtility.PrintTitle("AUTO RESET EVENT EXAMPLE");

            PrintUtility.PrintSubTitle("Press Enter to Start 3 named threads and start them");
            Console.ReadLine();

            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = $"Thread{i}";
                t.Start();
            }
            Thread.Sleep(250);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Press Enter to release another thread.");
                Console.ReadLine();
                event_1.Set();
                Thread.Sleep(250);
            }


            PrintUtility.PrintSubTitle("All threads are now waiting on AutoResetEvent #2.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Press Enter to release a thread.");
                Console.ReadLine();
                event_2.Set();
                Thread.Sleep(250);
            }
        }

        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine($"{name} waits on AutoResetEvent #1.");
            event_1.WaitOne();
            Console.WriteLine($"{name} is released from AutoResetEvent #1.");

            Console.WriteLine($"{name} waits on AutoResetEvent #2.");
            event_2.WaitOne();
            Console.WriteLine($"{name} is released from AutoResetEvent #2.");

            Console.WriteLine($"{name} ends.");
        }
    }
}
