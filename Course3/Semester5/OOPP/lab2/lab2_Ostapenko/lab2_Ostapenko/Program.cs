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
            Console.WriteLine();

            var random = new Random();
            int line = random.Next(array4.Matrix.GetLength(0));
            int column = random.Next(array4.Matrix.GetLength(1));
            Console.WriteLine($"Element ({line + 1};{column + 1}) is {array4[line, column]:f2}");
        }   
    }
}
