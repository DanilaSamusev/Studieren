using System;
using System.Threading;

namespace lab4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            EventWaitHandle DEvent = EventWaitHandle.OpenExisting("DEvent");
            EventWaitHandle EndClientEvent = EventWaitHandle.OpenExisting("EndClientEvent");

            Console.WriteLine("Введите сообщение состоящие из D для передачи серверу");
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "D")
                {                    
                    DEvent.Set();
                }
                else
                if (message == "")
                {
                    EndClientEvent.Set();
                    break;
                }
            }
        }
    }
}
