using System.Threading;

namespace CSharpThreads.ThreadExamples.MonitorExtra
{
    public class TickTockThread
    {
        public Thread thread;
        private TickTock tickTock;

        public TickTockThread(string Name, TickTock tickTock)
        {
            thread = new Thread(this.Run);
            this.tickTock = tickTock;
            thread.Name = Name;
            thread.Start();
        }

        private void Run()
        {
            if(thread.Name == "Tick")
            {
                for(int i = 0; i < 5; i++)
                {
                    tickTock.Tick(true); // Run Tick
                }
                tickTock.Tock(false); // Tell Tock To Wait
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    tickTock.Tock(true); // Run Tock
                }
                tickTock.Tick(false); // Tell Tick To Wait
            }
        }
    }
}
