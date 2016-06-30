using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    /// <summary>
    /// Thread blocking using Join
    /// </summary>
    public class N_ThreadJoin
    {
        private static Thread thread1, thread2;

        public static void Run()
        {
            PrintUtility.PrintTitle("JOIN EXAMPLE");
            thread1 = new Thread(ThreadProc);
            thread1.Name = "Thread1";
            thread1.Start();

            thread2 = new Thread(ThreadProc);
            thread2.Name = "Thread2";
            thread2.Start();
        }

        private static void ThreadProc()
        {
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "Thread1" && thread2.ThreadState != ThreadState.Unstarted)
            {
                thread2.Join();
            }                

            Thread.Sleep(2000);
            Console.WriteLine("\nCurrent thread: {Thread.CurrentThread.Name}");
            Console.WriteLine($"Thread1: {thread1.ThreadState}");
            Console.WriteLine($"Thread2: {thread2.ThreadState}");
        }

    }
}
