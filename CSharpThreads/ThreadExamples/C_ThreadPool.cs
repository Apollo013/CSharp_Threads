using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    /// <summary>
    /// Demonstrates Thread Pooling
    /// (A) QueueUserWorkItem
    /// (B) Asynchronous Delegates
    /// </summary>
    public class C_ThreadPool
    {

        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD POOLS");
            PrintUtility.PrintSubTitle("POOLED THREADS ARE ALWAYS BACKGROUND THREADS");
            QueueUserWorkItemMethod("Hello");
            AsynchronousDelegatesMethod();

        }

        /// <summary>
        /// (A) QueueUserWorkItem
        /// There is no easy way to get return value from callback method when using QueueUserWorkItem
        /// </summary>
        /// <param name="msg"></param>
        private static void QueueUserWorkItemMethod(string msg)
        {           
            ThreadPool.QueueUserWorkItem(DoWork, msg + " 1");
            ThreadPool.QueueUserWorkItem(DoWork, msg);
        }

        /// <summary>
        /// (B) Asynchronous Delegates
        /// Asynchronous delegates allow us to get return value from callback method
        /// </summary>
        private static void AsynchronousDelegatesMethod()
        {            
            Func<string, int> MethodName = GetStringLength;
            IAsyncResult result = MethodName.BeginInvoke("Testing Asynchronous Delegate", null, null);
            QueueUserWorkItemMethod("Second Hello");
            int stringLength = MethodName.EndInvoke(result);
            Console.WriteLine($"String Length is : {stringLength}");
        }

        static void DoWork(object data)
        {
            Console.WriteLine($"I am a pooled thread using QueueUserWorkItem. My value: {data}");
        }

        static int GetStringLength(string inputString)
        {
            Console.WriteLine($"I am a pooled thread using AsynchronousDelegates. My value: {inputString}");
            return inputString.Length;
        }
    }
}
