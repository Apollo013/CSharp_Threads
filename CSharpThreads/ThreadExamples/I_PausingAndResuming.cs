using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class I_PausingAndResuming
    {
        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD PAUSING AND RESUMING");

            Thread thread = new Thread(SleepIndefinately);
            thread.Name = "Sleepy";
            thread.Start();

            Console.WriteLine("Main Thread Sleeping For 2 Seconds");
            Thread.Sleep(2000);
            thread.Interrupt();

            Console.WriteLine("Main Thread Sleeping For 1 Second");
            Thread.Sleep(1000);

            thread = new Thread(SleepIndefinately);
            thread.Name = "Dozy";
            thread.Start();

            Console.WriteLine("Main Thread Sleeping For 2 Seconds");
            Thread.Sleep(2000);
            thread.Abort();
        }

        private static void SleepIndefinately()
        {
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' about to sleep indefinitely.");
            try
            {
                // Calling Thread.Sleep with a value of Timeout.Infinite causes a thread to sleep until it is 
                // interrupted by another thread that calls the Thread.Interrupt method on the sleeping thread.
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' awoken.");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' aborted.");
            }
            finally
            {
                Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' executing finally block.");
            }

            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' finishing normal execution.");
            Console.WriteLine();
        }
    }
}
