using System;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var calculator = new Calculator();
                double sum = calculator.CalculateFunction(10, 2, 5);

                Console.WriteLine(sum);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
