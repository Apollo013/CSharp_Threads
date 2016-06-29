using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples.MutexExtra
{
    public class MutexExample
    {
        // Create a new Mutex. The creating thread does not own the mutex.
        private static Mutex mut = new Mutex();
        private const int numIterations = 2;
        private const int numThreads = 3;

        public static void Run()
        {
            // Create the threads that will use the protected resource.
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = String.Format($"Thread{i + 1}");
                newThread.Start();
            }

            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static void UseResource()
        {
            // Wait until it is safe to enter.
            Console.WriteLine($"{Thread.CurrentThread.Name} is requesting the mutex");
            mut.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the protected area");

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the protected area");

            // Release the Mutex.
            mut.ReleaseMutex();
            Console.WriteLine($"{Thread.CurrentThread.Name} has released the mutex");
        }

        // Dispose
        ~MutexExample()
        {
            mut.Dispose();
        }
    }
}
