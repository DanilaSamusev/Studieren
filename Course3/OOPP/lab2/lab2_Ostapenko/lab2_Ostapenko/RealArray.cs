using System;

namespace lab2_Ostapenko
{
    public class RealArray
    {
        private double[,] _matrix;

        public double[,] Matrix 
        {
            get => _matrix; 
            set => _matrix = value; 
        }

        public RealArray()
        {
            _matrix = new double[3, 3];
        }

        public RealArray(double[,] matrix)
        {
            _matrix = matrix;
        }

        public RealArray(int dimensionOne, int dimensionTwo)
        {
            _matrix = new double[dimensionOne, dimensionTwo];
        }

        public RealArray(int dimension)
        {
            _matrix = new double[dimension, dimension];
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
            int counter = 0;
            int line = 0;
            for (int column = 0; column < _matrix.GetLength(1); column++)
            {
                if (_matrix[line, column] < 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public void MakeAllElementsRandomWithInterval(int leftLimit, int rightLimit)
        {
            var random = new Random();
            for (int line = 0; line < _matrix.GetLength(0); line++)
            {
                for (int column = 0; column < _matrix.GetLength(1); column++)
                {
                    _matrix[line, column] = random.NextDouble() * (rightLimit - leftLimit) + leftLimit;
                }
            }
        }

        public string GetArrayAsString()
        {
            string arrauString = string.Empty;

            for (var line = 0; line < _matrix.GetLength(0); line++)
            {
                for (var column = 0; column < _matrix.GetLength(1); column++)
                {
                    arrauString += $"\t{_matrix[line, column]:f2}";
                }

                arrauString += "\n";
            }

            return arrauString;
        }
    }
}
