using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix1 = new Matrix();
            
            double[,] array = new double[2,2];
            array[0, 0] = 1;
            array[0, 1] = 1;
            array[1, 0] = 1;
            array[1, 1] = 1;
            var matrix2 = new Matrix(array); 

            string matrix1AsString = matrix1.GetMatrixAsString();
            string matrix2AsString = matrix2.GetMatrixAsString();
            Console.WriteLine($"Matrix1: \n{matrix1AsString}");
            Console.WriteLine($"Matrix2: \n{matrix2AsString}");

            Console.WriteLine($"Matrix1 size: {matrix1.Size}");
            
            var result = matrix1 > matrix2;
            string message = result ? "Matrix1 > Matrix2" : "Matrix1 > Matrix1"; 
            
            Console.WriteLine(message);
            
            Console.ReadKey();
        }
    }
}