using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Matrix
    {
        private double[,] _matrix;

        public Matrix()
        {
            _matrix = new double[3, 3];
            InitializeMatrix();
        }

        public Matrix(int side)
        {
            _matrix = new double[side, side];
            InitializeMatrix();
        }

        public Matrix(int height, int width)
        {
            _matrix = new double[height, width];
            InitializeMatrix();
        }

        public Matrix(double[,] matrix)
        {
            _matrix = matrix;
        }

        private void InitializeMatrix()
        {
            double element = 1;

            for (var row = 0; row < _matrix.GetLength(1); row++)
            {
                for (var column = 0; column < _matrix.GetLength(0); column++)
                {
                    _matrix[row, column] = element;
                    element++;
                }
            }
        }

        private void ChangeMatrix()
        {
            for (var row = 0; row < _matrix.GetLength(1); row++)
            {
                double max = FindMaxInRow(row);

                if (max != 0)
                {
                    for (var column = 1; column < _matrix.GetLength(1); column++)
                    {
                        _matrix[row, column] /= max;
                    }
                }
            }
        }

        private double FindMaxInRow(int row)
        {
            double max = _matrix[row, 0];

            for (var column = 1; column < _matrix.GetLength(1) - 1; column++)
            {
                double currentElement = _matrix[row, column];

                if (currentElement > max)
                {
                    max = currentElement;
                }
            }

            return max;
        }
    }
}
