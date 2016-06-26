using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
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

        private static void ParameterisedThreadStart()
        {
            Thread t3 = new Thread(new ParameterizedThreadStart(PrintMeWithParam));
            t3.Start("Parameterized Thread Start Delegate");
        }

        private static void AnonymousDelegateThreadStart()
        {
            Thread t4 = new Thread(delegate () { PrintMeWithParam("Anonymous Delegate Thread Start"); });
            t4.Start();
        }

        private static void LambdaExpressionThreadStart()
        {
            Thread t5 = new Thread(() => PrintMeWithParam("Lambda Expression"));
            t5.Start();
        }

        private static void ThreadJoin()
        {
            PrintUtility.PrintSubTitle("THREAD JOIN");
            Thread t6 = new Thread(PrintThread);
            t6.Name = "Thread 6";
            t6.Start();
            t6.Join();

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
