using System;
using System.Threading;

namespace lab2
{
    public class MyThread
    {
        public int count; 
        public Thread thrd;
        static bool stop; 
        static string currentName;
        
        public MyThread(string name)
        { 
            count = 0;
            thrd= new Thread(Run); 
            thrd.Name = name; 
            currentName = name;
        }
        
        public void Run() 
        {
            Console.WriteLine("Поток " + thrd.Name + " стартовал. "); 
            
            do {
                count++;
                
                if(currentName != thrd.Name)
                { 
                    currentName=thrd.Name;
                    Console.WriteLine("В потоке " + currentName);
                }
                
            } while(stop == false && count < 1000000);
            
            stop = true;
            
            Console.WriteLine("Поток " + thrd.Name + " завершен.");
        }
    }
}