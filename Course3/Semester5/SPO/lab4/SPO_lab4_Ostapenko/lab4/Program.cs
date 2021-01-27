using System;
using System.Diagnostics;
using System.Threading;

namespace lab4
{
    class Program
    {
        public static Semaphore sem = new Semaphore(4, 4);
        class MyThread1
        {
            public Thread Thrd;
            public MyThread1()
            {
                Thrd = new Thread(this.Run);
                Thrd.Start();
            }
            void Run()
            {
                Console.Write("C");
                Thread.Sleep(5000);
                // Освободить семафор
                sem.Release();
            }
        }
        class MyThread2
        {
            public Thread Thrd;
            public MyThread2()
            {
                Thrd = new Thread(this.Run);
                Thrd.Start();
            }
            void Run()
            {
                Console.Write("D");
                Thread.Sleep(5000);
                // Освободить семафор
                sem.Release();
            }

        }
        static void Main(string[] args)
        {            
            int n, m, counter;
            Console.WriteLine("Введите количество Parent процессов:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество Child процессов:");
            m = Convert.ToInt32(Console.ReadLine());
            counter = n + m;

            EventWaitHandle CEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "CEvent");
            EventWaitHandle DEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "DEvent");
            EventWaitHandle EndClientEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "EndClientEvent");

            for (int i=0;i<n;i++)
                Process.Start(@"..\..\..\lab4_2\bin\Debug\lab4_2.exe");
            for (int j=0;j<m;j++)
                Process.Start(@"..\..\..\lab4_3\bin\Debug\lab4_3.exe");            
            //Создаем два события с ручным сбросом
            
            Console.WriteLine("Ожидание клиентов...");
            while (true)
            {                
                //Устанавливаем режим ожидания одного из двух событий
                int eventIndex = WaitHandle.WaitAny(new WaitHandle[] { CEvent, DEvent, EndClientEvent });
                if (eventIndex == 0)
                {
                    CEvent.Reset();
                    sem.WaitOne();
                    MyThread1 newThread = new MyThread1();
                }
                else if (eventIndex == 1)
                {
                    DEvent.Reset();
                    sem.WaitOne();
                    MyThread2 newThread = new MyThread2();
                } 
                else if (eventIndex==2)
                {                    
                    counter--;
                    if (counter == 0)
                        break;
                    EndClientEvent.Reset();
                }
            }
        }

    }
}
