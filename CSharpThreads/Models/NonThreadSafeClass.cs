using System;
using System.Collections.Generic;
using System.Threading;

namespace CSharpThreads.Models
{
    public class NonThreadSafeClass
    {
        List<string> nameList = new List<string>();
        public void SetItem(string name)
        {
            nameList.Add(name);
        }
        public void PrintItems(object threadName)
        {
            Console.WriteLine($"Thread {threadName.ToString()} started executing PrintItems");
            Thread.Sleep(500);
            foreach (string str in nameList)
            {
                Console.WriteLine(str);
            }
                
            Console.WriteLine($"Thread {threadName.ToString()} finished executing PrintItems");
        }
    }
}
