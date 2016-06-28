using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class J_Deadlock
    {

        private static object lockObj1 = new object();
        private static object lockObj2 = new object();
        private static Thread t1 = new Thread(DoWork1);
        private static Thread t2 = new Thread(DoWork2);

        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD DEADLOCK");

            t1.Start();
            // t1.Join(); // This will Force t2 to wait for t1 to complete
            t2.Start();
        }

        private static void DoWork1()
        {
            lock (lockObj1)
            {
                Console.WriteLine("Inside DoWork1: lockObj1 grabbed");
                Thread.Sleep(1000);
                Console.WriteLine($"Inside DoWork1, t1 thread state: {t1.ThreadState}");
                Console.WriteLine($"Inside DoWork1, t2 thread state: {t2.ThreadState}");
                lock (lockObj2) //Deadlock, below code is not executed  
                {
                    Console.WriteLine("Inside DoWork1: lockObj2 grabbed"); // Will never happen
                }
                Console.WriteLine("Released lockObj2"); // Will never happen
            }
            Console.WriteLine("Released lockObj1"); // Will never happen
        }

        private static void DoWork2()
        {
            lock (lockObj2)
            {
                Console.WriteLine("Inside DoWork2: lockObj2 grabbed");
                Thread.Sleep(500);
                Console.WriteLine($"Inside DoWork2, t1 thread state: {t1.ThreadState}" );
                Console.WriteLine($"Inside DoWork2, t2 thread state: {t2.ThreadState}");
                lock (lockObj1) ////Deadlock, below code is not executed  
                {
                    Console.WriteLine("Inside DoWork2: lockObj1 grabbed"); // Will never happen
                }
                Console.WriteLine("Released lockObj1"); // Will never happen
            }
            Console.WriteLine("Released lockObj2"); // Will never happen
        }

    }
}
