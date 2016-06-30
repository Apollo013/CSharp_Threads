using CSharpThreads.ThreadExamples.MutexExtra;
using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    /// <summary>
    /// Mutex stands for Mutual Exclusion and can be used for inter-process synchronization. 
    /// Mutex works similarly to lock except that it’s an operating system level lock and hence can be used to lock across processes. 
    /// On the contrary lock only works across threads in an AppDpmain of a process
    /// </summary>
    public class K_Mutex
    {
        private static readonly Mutex mutex = new Mutex();
        private static Thread thread1 = new Thread(DoWork);
        private static Thread thread2 = new Thread(DoWork);

        public static void Run()
        {
            PrintUtility.PrintTitle("MUTEX - MUTUALLY EXLCUSIVE");

            // Rnu one at a time only
            //RunExample1();
            //RunExample2();
            RunExample3();
        }

        #region EXAMPLE 1
        private static void RunExample1()
        {
            PrintUtility.PrintSubTitle("Example 1");
            thread1.Name = "Thread1";
            thread1.Start();
            thread2.Name = "Thread2";
            thread2.Start();
        }

        private static void DoWork()
        {
            mutex.WaitOne(); // Activate mutex
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} has entered");
                Thread.Sleep(2000);
                Console.WriteLine($"{Thread.CurrentThread.Name} has exited");
            }
            finally
            {
                mutex.ReleaseMutex(); // RELEASE THE MUTEX !!!
            }
                
        }
        #endregion

        #region EXAMPLE 2 - MutexExample Class

        private static void RunExample2()
        {
            PrintUtility.PrintSubTitle("Example 2");
            MutexExample.Run();
        }

        #endregion

        #region EXAMPLE 3 - MutexExample2 Class

        private static void RunExample3()
        {
            PrintUtility.PrintSubTitle("Example 3");
            MutexExample2 ex = new MutexExample2();
            ex.Run();
        }

        #endregion

        // DESTRUCTOR !!!!
        ~K_Mutex()
        {
            mutex.Dispose();
        }
    }
}
