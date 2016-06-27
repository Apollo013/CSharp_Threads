using CSharpThreads.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpThreads.ThreadExamples
{
    public class F_ThreadSynchronizationAndBlocking
    {
        static Thread thread1 = null;
        static Thread thread2 = null;


        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD SYNCHRONIZATION AND BLOCKING");
            TestSleep();
            TestJoin();
            TestTaskWait();
        }

        private static void TestSleep()
        {
            PrintUtility.PrintSubTitle("THREAD SLEEP");
            Console.WriteLine($"Thread Sleep started time: {DateTime.Now}");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread Sleep ended time: {DateTime.Now}");            
        }  

        private static void TestJoin()
        {
            PrintUtility.PrintSubTitle("THREAD JOIN");
            thread1 = new Thread(DoWork1);
            thread2 = new Thread(DoWork2);
            thread1.Start();
            thread1.Join();
            thread2.Start();
        }


        private static void TestTaskWait()
        {
            PrintUtility.PrintSubTitle("TASK WAIT");
            Console.WriteLine($"Task started time: {DateTime.Now}");
            var task = Task.Factory.StartNew(DoWork3);
            task.Wait();
            Console.WriteLine($"Task ended time: {DateTime.Now}, Result: {task.Result}");
        }


        private static void DoWork1()
        {
            Console.WriteLine($"Inside DoWork1, Thread 1 state: {thread1.ThreadState}");
            Console.WriteLine($"Inside DoWork1, Thread 2 state: {thread2.ThreadState}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("DoWork1: " + i);
            }
        }

        private static void DoWork2()
        {
            Console.WriteLine($"Inside DoWork2, Thread 1 state: {thread1.ThreadState}");
            Console.WriteLine($"Inside DoWork2, Thread 2 state: {thread2.ThreadState}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("DoWork2: " + i);
            }
        }

        private static int DoWork3()
        {
            ////In real word, some expensive operation will be there.  
            ////Putting sleep to simulate load.  
            Thread.Sleep(1000);
            return 5;
        }

    }
}
