using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_Ostapenko
{
    public class RealArray
    {
        private double[,] _matrix;

        public double[,] Matrix { get => _matrix; set => _matrix = value; }

        public RealArray()
        {
        }

        public RealArray(double[,] matrix)
        {
            _matrix = matrix;
        }
    }
}
