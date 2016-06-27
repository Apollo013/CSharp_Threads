using System;
using System.Threading;

namespace CSharpThreads.Models
{
    /// <summary>
    /// Class used to demonstrate Locking
    /// </summary>
    public class Account
    {
        private object thisLock = new object();
        int balance;
        Random r = new Random();


        public Account(int initialBalance)
        {
            this.balance = initialBalance;
        }

        private int Withdraw(int amount)
        {
            // This condition never is true unless the lock statement
            // is commented out.
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }


            // Ensure that one thread does not enter a critical section of code while another thread is in the critical section. 
            // If another thread tries to enter a locked code, it will wait, block, until the object is released.
            lock (thisLock)
            {
                if(balance >= amount)
                {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine($"Executing Thread: {Thread.CurrentThread.Name}");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine($"Balance before Withdrawal :  {balance}");
                    Console.WriteLine($"Amount to Withdraw        : -{amount}");
                    balance -= amount;
                    Console.WriteLine($"Balance after Withdrawal  :  {balance}");
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }
}
