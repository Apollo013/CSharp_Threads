using CSharpThreads.Utilities;
using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples
{
    public class D_ExceptionHandling
    {
        public static void Run()
        {
            PrintUtility.PrintTitle("EXCEPTION HANDLING");
            Example2();
            Example3();
            //Example1(); Commented out because it throws an unhandled error, feel free to uncomment.

        }

        /// <summary>
        /// This will thorw an unhandled exception
        /// </summary>
        private static void Example1()
        {
            try
            {
                new Thread(DoWork).Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception Caught: {ex.Message}");
            }
        }

        /// <summary>
        /// This exception will be caught
        /// </summary>
        private static void Example2()
        {
            try
            {
                new Thread(DoWorkWhereExceptionWillGetCaught).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Caught: {ex.Message}");
            }
        }

        /// <summary>
        /// Exception will be caught
        /// </summary>
        private static void Example3()
        {
            try
            {
                Action MethodName = DoWork;
                IAsyncResult result = MethodName.BeginInvoke(null, null);
                MethodName.EndInvoke(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Caught By Calling Method: {ex.Message}");
            }
        }


        private static void DoWork()
        {
            throw new ArgumentNullException();
        }

        private static void DoWorkWhereExceptionWillGetCaught()
        {
            try
            {
                throw new ArgumentNullException();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception Caught By Target Method: {ex.Message}");
            }
        }


    }
}
