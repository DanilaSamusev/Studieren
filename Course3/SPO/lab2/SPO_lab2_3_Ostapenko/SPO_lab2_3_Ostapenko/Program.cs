using System;
using System.Threading;

namespace SPO_lab2_3_Ostapenko
{
    class Program
    {
        public static void Main()
        {
            int countLimit = 1000000;
            var thread1 = new MyThread("Thread1", countLimit);
            var thread2 = new MyThread("Thread2", countLimit);
            var thread3 = new MyThread("Thread3", countLimit);
            var thread4 = new MyThread("Thread4", countLimit);

            // Устанавливаем приоритеты.
            thread1.thread.Priority += 1;
            thread2.thread.Priority += 1;
            thread3.thread.Priority -= 1;
            thread4.thread.Priority -= 2;

            // Запускаем потоки на выполнение. 
            thread1.thread.Start();
            thread2.thread.Start();
            thread3.thread.Start();
            thread4.thread.Start();

            thread1.thread.Join();
            thread2.thread.Join();
            thread3.thread.Join();
            thread4.thread.Join();

            Console.WriteLine();
            Console.WriteLine("Поток " + thread1.thread.Name + " досчитал до " + thread1.Count);
            Console.WriteLine("Поток " + thread2.thread.Name + " досчитал до " + thread2.Count);
            Console.WriteLine("Поток " + thread3.thread.Name + " досчитал до " + thread3.Count);
            Console.WriteLine("Поток " + thread4.thread.Name + " досчитал до " + thread4.Count);
        }
    }
}
