namespace Lab2
{
    public class Matrix
    {
        private double[,] _matrix;

        public double[,] MatrixProperty
        {
            get => _matrix;
            set => _matrix = value;
        }

        public double this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

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

        public void ChangeMatrix()
        {
            for (var row = 0; row < _matrix.GetLength(0); row++)
            {
                double max = FindMaxInRow(row);

                if (max != 0)
                {
                    for (var column = 0; column < _matrix.GetLength(1); column++)
                    {
                        _matrix[row, column] /= max;
                    }
                }
            }
        }

        public string GetMatrixAsString()
        {
            string result = string.Empty;

            for (var row = 0; row < _matrix.GetLength(0); row++)
            {
                for (var column = 0; column < _matrix.GetLength(1); column++)
                {
                    result += $"{_matrix[row, column]}  ";
                }

                result += "\n";
            }

            return result;
        }

        private void InitializeMatrix()
        {
            double element = 1;

            for (var row = 0; row < _matrix.GetLength(0); row++)
            {
                for (var column = 0; column < _matrix.GetLength(1); column++)
                {
                    _matrix[row, column] = element;
                    element++;
                }
            }
        }

        private double FindMaxInRow(int row)
        {
            double max = _matrix[row, 0];

            for (var column = 0; column < _matrix.GetLength(1); column++)
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
