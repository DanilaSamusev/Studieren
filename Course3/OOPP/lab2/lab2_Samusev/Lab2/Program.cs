using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix();

            string matrixAsString = matrix.GetMatrixAsString();
            Console.WriteLine(matrixAsString);

            matrix.ChangeMatrix();
            matrixAsString = matrix.GetMatrixAsString();
            Console.WriteLine($"Changed matrix: \n{matrixAsString}");

            matrix = new Matrix(4);
            matrixAsString = matrix.GetMatrixAsString();
            Console.WriteLine(matrixAsString);

            matrix.ChangeMatrix();
            matrixAsString = matrix.GetMatrixAsString();
            Console.WriteLine($"Changed matrix: \n{matrixAsString}");

            matrix = new Matrix(4, 5);
            matrixAsString = matrix.GetMatrixAsString();
            Console.WriteLine(matrixAsString);

            matrix.ChangeMatrix();
            matrixAsString = matrix.GetMatrixAsString();
            Console.WriteLine($"Changed matrix: \n{matrixAsString}");

            Console.WriteLine($"Element 1-1: {matrix[1, 1]}");

            Console.ReadKey();
        }
    }
}
