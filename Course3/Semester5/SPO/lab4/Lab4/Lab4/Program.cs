using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Administrator
{
    class Program
    {
        static Semaphore sem = new Semaphore(2, 2, "Sema");
        
        static void Main(string[] args)
        {
            
            EventWaitHandle starEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "starEvent");
            EventWaitHandle dotEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "dotEvent");
            EventWaitHandle exitEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "exitEvent");
 
            Console.WriteLine("Введите количество процессов Writer:");
 
            int procNum = int.Parse(Console.ReadLine());
            
            List<Process> processes=StartProcesses(procNum);

            int index=-1;
            int disposesProcesses = 0;
 
            while (disposesProcesses!=processes.Count)
            {
                index = EventWaitHandle.WaitAny(new[] { starEvent, dotEvent, exitEvent});
                sem.WaitOne();
                
                if (index == 0)
                {
                    Console.Write("+");
                }
                else if (index == 1)
                {
                    Console.Write("-");
                }
                else if (index == 2)
                {
                    Console.WriteLine();
                    disposesProcesses++;
                }

                sem.Release();
            }
 
            Console.ReadKey();
        }
 
        private static List<Process> StartProcesses(int num)
        {
            List<Process> processes=new List<Process>();
 
            for (int i = 0; i < num; i++)
            {
                processes.Add(Process.Start(@"F:\MyWorks\Учёба\Studieren\Course3\SPO\lab4\Lab4\Lab4.Client\bin\Debug\netcoreapp3.0\Lab4.Client.exe"));
            }
 
            return processes;
        }
    }
}