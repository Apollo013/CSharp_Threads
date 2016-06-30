using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpThreads.Utilities;
using System.Collections.Concurrent;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class M_ConcurrentDictionary
    {
        static ConcurrentDictionary<int, string> cd = new ConcurrentDictionary<int, string>();

        public static void Run()
        {
            PrintUtility.PrintTitle("CONCURRENT DICTIONARY");
            ThreadTest();

            cd.Clear();

            TryMethods();
            AddOrUpdate();
        }

        private static void ThreadTest()
        {
            PrintUtility.PrintTitle("THREAD TEST");
            Thread thread1 = new Thread(new ThreadStart(TryAddMany));
            Thread thread2 = new Thread(new ThreadStart(TryAddMany));

            thread1.Name = "Thread1";
            thread2.Name = "Thread2";

            thread1.Start();
            thread1.Join();

            thread2.Start();
        }

        private static void TryAddMany()
        {
            PrintUtility.PrintSubTitle($"THREAD ID: {Thread.CurrentThread.Name}");

            for (int i = 1; i <= 1000; i++)
            {
                cd.TryAdd(i, i.ToString());
            }

            Console.WriteLine("Average: {0}", cd.Keys.Average());
        }

        private static void TryMethods()
        {
            PrintUtility.PrintSubTitle("TRY METHODS");

            int numFailures = 0;

            /****************************************************************************************/
            // TRY ADD
            /****************************************************************************************/
            // This should work
            if (cd.TryAdd(1, "one"))
            {
                Console.WriteLine("CD.TryAdd() 'one' succeeded");
            }
            else
            {
                Console.WriteLine("CD.TryAdd() 'one' failed");
                numFailures++;
            }

            // This shouldn't work -- key 1 is already in use
            if (cd.TryAdd(1, "uno"))
            {
                Console.WriteLine("CD.TryAdd() succeeded when it should have failed");
                numFailures++;
            }
            else
            {
                Console.WriteLine("CD.TryAdd() failed (this is suppose to happen)");
            }

            /****************************************************************************************/
            // TRY UPDATE
            /****************************************************************************************/
            // Now change the value for key 1 from "one" to "uno" -- should work
            if (!cd.TryUpdate(1, "uno", "one"))
            {
                Console.WriteLine("CD.TryUpdate() failed when it should have succeeded");
                numFailures++;
            }
            else
            {
                Console.WriteLine("CD.TryUpdate() succeeded : Changed 'one' to 'uno'");
            }

            // Try to change the value for key 1 from "eine" to "one" 
            //    -- this shouldn't work, because the current value isn't "eine"
            if (cd.TryUpdate(1, "one", "eine"))
            {
                Console.WriteLine("CD.TryUpdate() succeeded when it should have failed");
                numFailures++;
            }
            else
            {
                Console.WriteLine("CD.TryUpdate() failed (this is suppose to happen)");
            }

            /****************************************************************************************/
            // TRY REMOVE
            /****************************************************************************************/
            // Remove key/value for key 1.  Should work.
            string value1;
            if (!cd.TryRemove(1, out value1))
            {
                Console.WriteLine("CD.TryRemove() failed when it should have succeeded");
                numFailures++;
            }
            else
            {
                Console.WriteLine($"Removed value: {value1}");
            }

            // Remove key/value for key 1.  Shouldn't work, because I already removed it
            string value2;
            if (cd.TryRemove(1, out value2))
            {
                Console.WriteLine("CD.TryRemove() succeeded when it should have failed");
                numFailures++;
            }

            // If nothing went wrong, say so
            if (numFailures == 0)
            {
                Console.WriteLine("OK!");
            }

        }

        private static void AddOrUpdate()
        {
            /****************************************************************************************/
            // TRY ADD
            /****************************************************************************************/
            // Add a new key/value, This should work
            if (cd.TryAdd(1, "one"))
            {
                Console.WriteLine("CD.TryAdd() 'one' succeeded");
            }

            /****************************************************************************************/
            // ADD OR UPDATE
            /****************************************************************************************/
            // Now change the value for key 1 from "one" to "eon" -- should work
            string oldValue = "one";
            string newValue = "eon";
            cd.AddOrUpdate(1, oldValue, (k, v) => newValue);

            /****************************************************************************************/
            // TRY GET
            /****************************************************************************************/
            // Now get the value for key 1
            var val = "";
            var first = cd.TryGetValue(1, out val);
            Console.WriteLine(val);

        }

    }
}
