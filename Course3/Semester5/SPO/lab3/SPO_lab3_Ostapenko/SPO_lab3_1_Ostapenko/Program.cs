using System;
using System.Linq;
using System.Threading;

namespace SPO_lab3_1_Ostapenko
{
    class Program
    {
        private static object syncObject = new object();

        static void Main(string[] args)
        {
            int[] array = CreateArray();

            Console.WriteLine("Исходный массив:");
            DisplayArray(array);

            Thread thread1 = new Thread(ThreadMethod1);
            Thread thread2 = new Thread(ThreadMethod2);

            thread1.Start(array);
            thread2.Start(array);
        }

        static void ThreadMethod1(object data)
        {
            int[] array = data as int[];

            lock (syncObject)
            {
                Console.WriteLine("Обработка...");

                Thread.Sleep(2000);

                for (int index = 0; index < array.Length; index++)
                {
                    if (index % 2 == 0)
                    {
                        array[index] -= 5;
                    }
                }

                Console.WriteLine("Обработка завершена.");
            }

        }

        private static void ThreadMethod2(object data)
        {
            int[] array = data as int[];

            lock (syncObject)
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
            Console.Write("Введите размерность массива: ");

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
                array[i] = rand.Next(-50, 50);
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
