using CSharpThreads.Models;
using CSharpThreads.Utilities;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    /// <summary>
    /// Class level locking mechanism
    /// </summary>
    public class L_SynchronizationContext
    {

        public static void Run()
        {
            PrintUtility.PrintTitle("SYNCHRONIZATION CONTEXT");
            //TestNonThreadSafeClass();
            TestThreadSafeClass();
        }

        private static void TestNonThreadSafeClass()
        {
            PrintUtility.PrintSubTitle("Non Thread Safe Class");
            NonThreadSafeClass ntsClass = new NonThreadSafeClass();

            ntsClass.SetItem("Mary");
            ntsClass.SetItem("John");

            Thread thread1 = new Thread(new ParameterizedThreadStart(ntsClass.PrintItems));
            thread1.Start("thread1");
            Thread thread2 = new Thread(new ParameterizedThreadStart(ntsClass.PrintItems));
            thread2.Start("thread2");
            Thread thread3 = new Thread(new ParameterizedThreadStart(ntsClass.PrintItems));
            thread3.Start("thread3");
        }

        private static void TestThreadSafeClass()
        {
            PrintUtility.PrintSubTitle("Thread Safe Class");

            ThreadSafeClass tsClass = new ThreadSafeClass();

            tsClass.SetItem("Mary");
            tsClass.SetItem("John");

            Thread thread1 = new Thread(new ParameterizedThreadStart(tsClass.PrintItems));
            thread1.Start("thread1");
            Thread thread2 = new Thread(new ParameterizedThreadStart(tsClass.PrintItems));
            thread2.Start("thread2");
            Thread thread3 = new Thread(new ParameterizedThreadStart(tsClass.PrintItems));
            thread3.Start("thread3");
        }
    }

}
