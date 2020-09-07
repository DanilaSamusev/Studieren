using System;

namespace lab2_Ostapenko
{
    class Program
    {
        static void Main(string[] args)
        {
            var array1 = new RealArray();
            Console.WriteLine("array1");
            Console.WriteLine(array1.GetArrayAsString());
            Console.WriteLine();

            var array2 = new RealArray(4);
            Console.WriteLine("array2");
            Console.WriteLine(array2.GetArrayAsString());
            Console.WriteLine();

            var array3 = new RealArray(3, 4);
            Console.WriteLine("array3");
            Console.WriteLine(array3.GetArrayAsString());
            Console.WriteLine();

            double[,] matrix = new double[4, 5];
            var array4 = new RealArray(matrix);
            Console.WriteLine("array4");
            Console.WriteLine(array4.GetArrayAsString());
            Console.WriteLine();

            array4.MakeAllElementsRandomWithInterval(-5, 5);
            Console.WriteLine("array4.1");
            Console.WriteLine(array4.GetArrayAsString());
            Console.WriteLine();

            Console.WriteLine($"Number of columns starts with negatives: {array4.GetColumnsStartsWithNegativesNumber()}");
        }   
    }
}
