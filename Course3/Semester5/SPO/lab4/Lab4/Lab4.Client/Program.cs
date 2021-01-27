using System;
using System.Threading;
 
namespace Writer
{   
    class Program
    {
        static Semaphore sem = new Semaphore(2, 2, "Sema");
        
        static void Main(string[] args)
        {
            EventWaitHandle starEvent = EventWaitHandle.OpenExisting("starEvent");
            EventWaitHandle dotEvent = EventWaitHandle.OpenExisting("dotEvent");
            EventWaitHandle exitEvent = EventWaitHandle.OpenExisting("exitEvent");
            
            while (true)
            {
                starEvent.Reset();
                dotEvent.Reset();
                exitEvent.Reset();
 
                string input = Console.ReadLine();
 
                if (input != "+" && input != "-")
                {
                    exitEvent.Set();
                    break;
                }
                else if (input == "+")
                {
                    starEvent.Set();
                }
                else if (input == "-")
                {
                    dotEvent.Set();
                }
            }
            
            exitEvent.Reset();
        }
    }
}