using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples.MutexExtra
{
    /*
     * In the following example, each thread calls the WaitOne(Int32) method to acquire the mutex. 
     * If the time-out interval elapses, the method returns false, and the thread neither acquires 
     * the mutex nor gains access to the resource the mutex protects. The ReleaseMutex method is 
     * called only by the thread that acquires the mutex. 
     */
    public class MutexExample2
    {
        // Create a new Mutex. The creating thread does not own the mutex.
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;

        public void Run()
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
            // Wait until it is safe to enter, and do not enter if the request times out.
            Console.WriteLine($"{Thread.CurrentThread.Name} is requesting the mutex");
            if (mut.WaitOne(1000))
            {
                Console.WriteLine("{0} has entered the protected area",
                    Thread.CurrentThread.Name);

                // Place code to access non-reentrant resources here.

                // Simulate some work.
                Thread.Sleep(500); // Increase to over 1000 to prevent any threads from acquiring the mutex after the first thread

                Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the protected area");

                // Release the Mutex.
                mut.ReleaseMutex();
                Console.WriteLine($"{Thread.CurrentThread.Name} has released the mutex");
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} will not acquire the mutex");
            }

        }

        // Dispose
        ~MutexExample2()
        {
            mut.Dispose();
        }
    }
}
