using System;
using System.Threading;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread mtl =new MyThread("с высоким приоритетом"); 
            MyThread mt2 =new MyThread("со среднем приоритетом"); 
            MyThread mt3 = new MyThread("с низким приоритетом");
            
            mtl.thrd.Priority = ThreadPriority.Highest; 
            mt2.thrd.Priority = ThreadPriority.Normal;
            mt3.thrd.Priority = ThreadPriority.Lowest;
            
            mtl.thrd.Start (); 
            mt2.thrd.Start ();
            mt3.thrd.Start (); 
            
            mtl. thrd. Join() ;
            mt2.thrd.Join () ;
            mt3.thrd.Join () ;
            
            Console.WriteLine();
            Console.WriteLine("Поток " + mtl.thrd.Name +
                              " досчитал до " + mtl.count);
            Console.WriteLine("Поток " + mt2.thrd.Name +
                              " досчитал до " + mt2.count);
            Console.WriteLine("Поток " + mt3.thrd.Name +
                              " досчитал до " + mt3.count);
            Console.ReadKey();

        }
    }
}
