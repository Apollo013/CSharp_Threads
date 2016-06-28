using CSharpThreads.ThreadExamples.MonitorExtra;
using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class H_ThreadMonitoring
    {
        // Important to only create a single lock object per critical section
        static object locker = new object();
        static object locker2 = new object();
        static object locker3 = new object();

        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD MONITORING");
            //EnterAndExitExample();
            //PoolExample();
            TickTockExample();
        }

        #region ENTER & EXIT EXAMPLE
        private static void EnterAndExitExample()
        {
            PrintUtility.PrintSubTitle("ENTER AND EXIT EXAMPLE");
            Thread t1 = new Thread(new ThreadStart(RandomDivision));
            Thread t2 = new Thread(new ThreadStart(RandomDivision));
            t1.Name = "t1";
            t2.Name = "t2";
            t1.Start();
            t1.Join();
            t2.Start();
        }

        private static void RandomDivision()
        {
            Thread.Sleep(1000);
            Random r = new Random();            
            int num1;
            int num2;
            bool isLocked = false;
            String threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"Thread Name: {threadName}");
            
            try
            {
                Monitor.Enter(locker, ref isLocked);

                for (int i = 0; i < 5; i++)
                {
                    num1 = r.Next(1, 5);
                    num2 = r.Next(1, 5);
                    Console.WriteLine($"Division of {num1} and {num2} is: {num1 / num2} : Thread Name: {threadName} ");
                    num1 = 0;
                    num2 = 0;
                }
            }
            finally
            {
                if (isLocked)
                {
                    Console.WriteLine($"Lock Released : Thread Name: {threadName}");
                    Monitor.Exit(locker);
                }
            }
        }
        #endregion

        #region POOL EXAMPLE
        private static void PoolExample()
        {
            PrintUtility.PrintSubTitle("POOL EXAMPLE");
            Thread[] threads = new Thread[3];

            // Create thread pool
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(DoPoolWork));
                threads[i].Name = $"t{i+1}";
                threads[i].IsBackground = true;
                threads[i].Start();
            }

            // Start each one
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Sleeping");
                Thread.Sleep(1000);
                Console.WriteLine("Awake");
                lock (locker2)
                {
                    Console.WriteLine(" Before Pulsing");
                    Monitor.Pulse(locker2);
                    Console.WriteLine("After Pulsing");
                }
            }
            
        }

        private static void DoPoolWork()
        {
            String threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"Thread Name: {threadName}");
            while (true)
            {
                lock (locker2)
                {
                    Console.WriteLine($"Thread Name: {threadName} - Before Waiting");
                    Monitor.Wait(locker2);
                    Console.WriteLine($"Thread Name: {threadName} - After Waiting");
                }
                Console.WriteLine($"{threadName} Working");
                Thread.Sleep(100);
            }
        }
        #endregion

        #region Tick Tock
        private static void TickTockExample()
        {
            TickTock tickTock = new TickTock();
            TickTockThread t1 = new TickTockThread("Tick", tickTock);
            TickTockThread t2 = new TickTockThread("Tock", tickTock);
            
            t1.thread.Join();
            t2.thread.Join();

            Console.WriteLine("Clock  Stopped");
        }
        #endregion

    }
}
