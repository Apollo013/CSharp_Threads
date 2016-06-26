using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class C_ThreadPool
    {

        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD POOLS");
            PrintUtility.PrintSubTitle("POOLED THREADS ARE ALWAYS BACKGROUND THREADS");
            QueueUserWorkItemMethod("Hello");
            AsynchronousDelegates();

        }

        private static void QueueUserWorkItemMethod(string msg)
        {
            // There is no easy way to get return value from callback method when using QueueUserWorkItem
            ThreadPool.QueueUserWorkItem(DoWork, msg + " 1");
            ThreadPool.QueueUserWorkItem(DoWork, msg);
        }

        private static void AsynchronousDelegates()
        {
            // Asynchronous delegates allow us to get return value from callback method
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
