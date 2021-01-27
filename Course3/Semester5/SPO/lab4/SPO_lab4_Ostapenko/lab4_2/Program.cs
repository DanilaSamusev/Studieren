using System;
using System.Threading;

namespace lab4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Открываем созданные Сервером события
            EventWaitHandle CEvent = EventWaitHandle.OpenExisting("CEvent");
            EventWaitHandle EndClientEvent = EventWaitHandle.OpenExisting("EndClientEvent");

            Console.WriteLine("Введите сообщение состоящие из С для передачи серверу");
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "C")
                {
                    CEvent.Set();
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
