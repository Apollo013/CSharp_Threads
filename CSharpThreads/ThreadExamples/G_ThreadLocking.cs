using CSharpThreads.Models;
using CSharpThreads.Utilities;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    /// <summary>
    /// Thread Locking ensures that only one thread can enter at a time in a code block
    /// </summary>
    public class G_ThreadLocking
    {
        public static void Run()
        {
            PrintUtility.PrintTitle("THREAD LOCKING");

            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);

            for (int i = 0; i < 10; i++)
            {
                Thread T = new Thread(new ThreadStart(acc.DoTransactions));
                T.Name = $"Thread{i}";
                threads[i] = T;
            }

            for(int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
        }

    }

}
