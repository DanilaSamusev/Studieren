using System;
using System.Linq;
using System.Text;

namespace Lab7
{
    class Program
    {
        public static string Message = "He.......llo .......wo..rl.d";

        static void Main(string[] args)
        {
            Task1_6();
            Task2_6();
            Task3_6();
        }

        public static void Task1_6()
        {
            char[] array = Message.ToCharArray();
            char[] sortedArray = new char[array.Count()];
            Array.Copy(array, sortedArray, array.Count());
            Array.Sort(sortedArray);

            bool result = true;

            for (var i = 0; i < array.Count(); i++)
            {
                if (array[i] != sortedArray[i])
                {
                    result = false;
                    break;
                }
            }

            Console.WriteLine(result);
        }

        public static void Task2_6()
        {
            StringBuilder result = new StringBuilder(Message);

            int i = 0;

            while (i < Message.Length)
            {
                int dotsCount = 0;
                StringBuilder dots = new StringBuilder();

                while (i < Message.Length && Message[i] == '.')
                {
                    dotsCount++;
                    dots.Append('.');
                    i++;
                }

                if (dotsCount >= 7)
                {
                    result.Replace(dots.ToString(), "...");
                }

                i++;            
            }

            Console.WriteLine(result.ToString());
        }

        public static void Task3_6()
        {
            string[] array = Message.Split();
            int[] lengths = array.Select(str => str.Length).ToArray();
            int maxLength = lengths.Max();
            string result = array.First(l => l.Length == maxLength);

            Console.WriteLine(result);
        }
    }
}
