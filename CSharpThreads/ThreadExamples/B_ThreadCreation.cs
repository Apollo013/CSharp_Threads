using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    /// <summary>
    /// Demonstration of the different ways in which to create a thread.
    /// </summary>
    public class B_ThreadCreation
    {

        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD CREATION");
            ThreadClassOnly();
            ThreadStartDelegate();
            ParameterisedThreadStart();
            AnonymousDelegateThreadStart();
            LambdaExpressionThreadStart();
            ThreadJoin();
        }

        private static void ThreadClassOnly()
        {
            Thread t1 = new Thread(PrintMe1);
            t1.Start();
        }

        private static void ThreadStartDelegate()
        {
            Thread t2 = new Thread(new ThreadStart(PrintMe2));
            t2.Start();
        }

        /// <summary>
        /// Allows us to pass an arguement to the target method
        /// </summary>
        private static void ParameterisedThreadStart()
        {
            Thread t3 = new Thread(new ParameterizedThreadStart(PrintMeWithParam));
            t3.Start("Parameterized Thread Start Delegate");
        }

        /// <summary>
        /// Anonymous delegate example that also allows us to pass an arguemnt to the target method
        /// </summary>
        private static void AnonymousDelegateThreadStart()
        {
            Thread t4 = new Thread(delegate () { PrintMeWithParam("Anonymous Delegate Thread Start"); });
            t4.Start();
        }

        /// <summary>
        /// Lambda Expression example that also allows us to pass an arguemnt to the target method
        /// </summary>
        private static void LambdaExpressionThreadStart()
        {
            Thread t5 = new Thread(() => PrintMeWithParam("Lambda Expression"));
            t5.Start();
        }

        /// <summary>
        /// The Join method causes a wait for a thread to finish. In a multi-threading scenario, 
        /// it can be used to provide blocking functionality by allowing waits for the specified thread
        /// </summary>
        private static void ThreadJoin()
        {
            PrintUtility.PrintSubTitle("THREAD JOIN");
            Thread t6 = new Thread(PrintThread);
            t6.Name = "Thread 6";
            t6.Start();
            t6.Join(); // Wait for this Thread to complete first before proceeding with next.

            Thread t7 = new Thread(PrintThread);
            t7.Name = "Thread 7";
            t7.Start();
        }

        private static void PrintMe1()
        {
            Console.WriteLine("Created using Thread Class");
        }

        private static void PrintMe2()
        {
            Console.WriteLine("Created using ThreadStart delegate");
        }

        private static void PrintMeWithParam(object param)
        {
            Console.WriteLine("Created using {0}", param);
        }

        private static void PrintThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.Name} running - {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
