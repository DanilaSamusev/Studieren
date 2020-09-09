using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab10
{
    public class FileHelper
    {
        private int _startValue;
        private int _endValue;
        private int _step;
        private string _fileName;

        public void Run()
        {
            ReadData();
            int[] x = CreateX();
            double[] y = Calculate(x);
            WriteResults(x, y);
            ReadCalculations();
        }
        
        private void ReadData()
        {
            Console.Write("Inter start value: ");
            _startValue = int.Parse(Console.ReadLine());
            
            Console.Write("Inter end value: ");
            _endValue = int.Parse(Console.ReadLine());
            
            Console.Write("Inter step: ");
            _step = int.Parse(Console.ReadLine());
            
            Console.Write("Inter file name: ");
            _fileName = Console.ReadLine();
        }

        private void ReadCalculations()
        {
            string[] row;
            List<double> y = new List<double>();

            using (var sr = new StreamReader(_fileName))
            {
                while (true)
                {
                    String str = sr.ReadLine();
                    if (str == null)
                        break;

                    row = str.Split(new[] {' '},
                        StringSplitOptions.RemoveEmptyEntries);

                    y.Add(double.Parse(row[1]));
                }
            }
            
            Console.WriteLine(y.Average());
        }

        private int[] CreateX()
        {
            int elementsCount = (_endValue - _startValue) / _step + 1;
            int[] x = new int[elementsCount];

            int currentValue = _startValue;
            
            for (var i = 0; i < elementsCount; i++)
            {
                x[i] = currentValue;
                currentValue += _step;
            }

            return x;
        }
        
        private void WriteResults(int[] x, double[] y)
        {
            FileStream fs = File.Create(_fileName);

            using (var bw = new StreamWriter(fs))
            {
                for (var i = 0; i < x.Length; i++)
                {
                    bw.WriteLine("{0, 10}  {1, 10}", x[i], y[i]);
                }
            }
        }

        private double[] Calculate(int[] x)
        {
            double[] y = new double[x.Length];

            for (var i = 0; i < y.Length; i++)
            {
                y[i] = Math.Sin(x[i]) * x[i];
            }

            return y;
        }
    }
}