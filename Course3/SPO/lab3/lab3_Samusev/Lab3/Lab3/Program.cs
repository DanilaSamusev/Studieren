using System;
using System.Linq;
using System.Threading;

namespace Lab3
{
    class Program
    {
        private static object syncToken = new object();

        static void Main(string[] args)
        {
            int[] array = CreateArray();

            Console.WriteLine("Исходный массив:");
            DisplayArray(array);

            Thread thread1 = new Thread(Thread1Method);
            Thread thread2 = new Thread(Thread2Method);

            thread1.Start(array);


            thread2.Start(array);
        }

        static void Thread1Method(object data)
        {
            int[] array = data as int[];
            
            lock (syncToken)
            {
                Console.WriteLine("Обработка....");

                Thread.Sleep(2000);
                
                for (int i = 0; i < array.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        array[i] = 0;
                    }
                }
            
                Console.WriteLine("Обработка завершена");
            }
            
        }

        private static void Thread2Method(object data)
        {
            int[] array = data as int[];

            lock (syncToken)
            {
                Console.WriteLine("Обработанный массив:");
                DisplayArray(array);
            
                int maxElementId = Array.IndexOf(array, array.Max());
                int minElementId = Array.IndexOf(array, array.Min());
            
                Console.WriteLine($"Индекс максимального элемента: {maxElementId}");
                Console.WriteLine($"Индекс минимального элемента: {minElementId}");
            }
        }

        private static int[] CreateArray()
        {
            Console.WriteLine("Введите размерность массива");

            string arraySizeString = Console.ReadLine();

            int arraySize;

            if (!int.TryParse(arraySizeString, out arraySize))
            {
                arraySize = 0;
            }

            int[] array = new int[arraySize];

            Random rand = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = -1 * rand.Next(99) + rand.Next(99);
            }

            return array;
        }

        private static void DisplayArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}