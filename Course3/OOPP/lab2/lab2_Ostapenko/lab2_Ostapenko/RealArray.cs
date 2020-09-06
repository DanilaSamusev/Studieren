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

        public RealArray(int decimOne, int decimTwo)
        {
            _matrix = new double[decimOne, decimTwo];
        }

        public RealArray(int decim)
        {
            _matrix = new double[decim, decim];
        }

        public double this[int index1, int index2]
        {
            get
            {
                return _matrix[index1, index2];
            }
            set
            {
                _matrix[index1, index2] = value;
            }
        }

        public int GetColumnsStartsWithNegativesNumber()
        {
            return 1;
        }
    }
}
