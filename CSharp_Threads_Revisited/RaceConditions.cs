using System;
using System.Threading;

namespace CSharp_Threads_Revisited
{
    /*
     * What we are trying to achieve here is to avoid a situation called Race Condition.
     * This occurs when multiple threads try to perform the same task at the same time, 
     * the effect is that the tasks are performed randomly and out of sync.
     * To demonstrate this, we want to synchronize output to the console by printing all numbers before printing letters.
     */

    public class RaceConditions
    {
        private static object locker = new object();
        private static int counter;

        public static void Run()
        {
            Thread[] threads = new Thread[4];

            threads[0] = new Thread(RunProblem);
            threads[1] = new Thread(RunSolutionUsingJoin);
            threads[2] = new Thread(RunSolutionUsingLock);
            threads[3] = new Thread(RunSolutionUsingMonitor);

            foreach (Thread t in threads)
            {
                t.Start();
                t.Join();
                Thread.Sleep(200);
            }
        }

        private static void RunProblem()
        {
            // Although this may process as expected, it is inconsistent.
            Print("The Problem");
            Thread t1 = new Thread(PrintNumbers);
            t1.Start();

            Thread t2 = new Thread(PrintLetters);
            t2.Start();
        }

        #region Join Solution
        /// <summary>
        /// Synchronize threads using join
        /// </summary>
        private static void RunSolutionUsingJoin()
        {
            Print("Join Solution");
            Thread t1 = new Thread(PrintNumbers);
            t1.Start();
            t1.Join();

            Thread t2 = new Thread(PrintLetters);
            t2.Start();
            t2.Join();
        }

        private static void PrintNumbers()
        {
            for (counter = 1; counter <= 5; counter++)
            {
                Console.WriteLine(counter);
            }
        }

        private static void PrintLetters()
        {
            for (counter = 65; counter <= 70; counter++)
            {
                char chr = (char)counter;
                Console.WriteLine(chr);
            }
        }
        #endregion

        #region Lock Solution
        private static void RunSolutionUsingLock()
        {
            Print("Lock Solution");
            new Thread(PrintNumbersWithLock).Start();
            new Thread(PrintLettersWithLock).Start();
        }

        private static void PrintNumbersWithLock()
        {
            lock (locker)
            {
                for (counter = 1; counter <= 5; counter++)
                {
                    Console.WriteLine(counter);
                }
            }
        }

        private static void PrintLettersWithLock()
        {
            lock (locker)
            {
                for (counter = 65; counter <= 70; counter++)
                {
                    char chr = (char)counter;
                    Console.WriteLine(chr);
                }
            }
        }
        #endregion

        #region Monitor Solution
        private static void RunSolutionUsingMonitor()
        {
            Print("Monitor Solution");
            new Thread(PrintNumbersWithMonitor).Start();
            new Thread(PrintLettersWithMonitor).Start();
        }

        private static void PrintNumbersWithMonitor()
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(locker, ref lockWasTaken);
                for (counter = 1; counter <= 5; counter++)
                {
                    Console.WriteLine(counter);
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Monitor.Exit(locker);
                }
            }
        }

        private static void PrintLettersWithMonitor()
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(locker, ref lockWasTaken);
                for (counter = 65; counter <= 70; counter++)
                {
                    char chr = (char)counter;
                    Console.WriteLine(chr);
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Monitor.Exit(locker);
                }
            }
        }
        #endregion

        #region Output
        private static void Print(string title)
        {
            string divider = new string('-', 100);
            Console.WriteLine();
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }
        #endregion
    }
}
