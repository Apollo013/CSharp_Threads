using System;
using System.Threading;

namespace CSharpThreads.ThreadExamples.MonitorExtra
{
    public class TickTock
    {
        public void Tick(bool running)
        {
            String threadName = Thread.CurrentThread.Name;
            //Console.WriteLine($"Thread Name: {threadName} - {running}");

            lock (this)
            {
                if (!running)
                {
                    //Console.WriteLine($"{threadName} 'Tick' Not Running - About To Pulse");
                    Monitor.Pulse(this); // Notify other threads
                    return;
                }
                Console.Write("Tick ");
                Monitor.Pulse(this);    // Let Tock Run
                Monitor.Wait(this);     // Wait For Tock To Complete
            }
        }

        public void Tock(bool running)
        {
            String threadName = Thread.CurrentThread.Name;
            //Console.WriteLine($"Thread Name: {threadName} - {running}");

            lock (this)
            {
                if (!running)
                {
                   // Console.WriteLine($"{threadName} 'Tock' Not Running - About To Pulse");
                    Monitor.Pulse(this); // Notify other threads
                    return;
                }
                Console.WriteLine("Tock");
                Monitor.Pulse(this);    // Let Tick Run
                Monitor.Wait(this);     // Wait For Tick To Complete
            }
        }
    }
}
