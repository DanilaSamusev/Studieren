using System;
using System.Text;

namespace Lab9
{
    public class Class1
    {
        public void DoubleString(int k, string message)
        {
            StringBuilder result = new StringBuilder(message);
            result.Remove(k, 1);
            result.Append(result);

            Console.WriteLine(result);
        }

        public void ChangeString(int k, string message)
        {
            StringBuilder result = new StringBuilder(message);
            result[k] = '+';

            Console.WriteLine(result);
        }
    }
}
