using CSharpThreads.ThreadExamples;
using CSharpThreads.Utilities;
using System;

namespace CSharpThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run each one independently
            /*
            A_ThreadTypes.Run();
            B_ThreadCreation.Run();
            C_ThreadPool.Run();
            FibonacciRun.Run();
            D_ExceptionHandling.Run();
            E_ThreadPriority.Run();            
            F_ThreadSynchronizationAndBlocking.Run();            
            G_ThreadLocking.Run();
            H_ThreadMonitoring.Run();
            I_PausingAndResuming.Run();
            J_Deadlock.Run();
            K_Mutex.Run();
            */

            L_SynchronizationContext.Run();

            PrintUtility.PrintSubTitle("MAIN THREAD EXITING \nBackground Threads still running after main thread has finished because a Foreground Thread is still alive");
            Console.ReadLine();
        }
    }
}
