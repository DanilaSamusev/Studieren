using System;

namespace lab2_Ostapenko
{
    class Program
    {
        static void Main(string[] args)
        {
            var array1 = new RealArray();
            Console.WriteLine();

            var array2 = new RealArray(4);
            Console.WriteLine();

            var array3 = new RealArray(3, 4);
            Console.WriteLine();

            double[,] matrix = new double[4, 5];
            var array4 = new RealArray(matrix);
            Console.WriteLine();
        }   
    }
}
