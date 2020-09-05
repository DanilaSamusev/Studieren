namespace Lab3
{
    public class Matrix
    {
        private double[,] _matrix;

        public int Size;
        
        public Matrix()
        {
            _matrix = new double[2, 2];
            Size = 2;
            InitializeMatrix();
        }

        public Matrix(double[,] matrix)
        {
            _matrix = matrix;
            Size = matrix.GetLength(0);
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

        public static bool operator > (Matrix matrix1, Matrix matrix2)
        {
            return GetMainDiagonalSum(matrix1._matrix) > GetMainDiagonalSum(matrix2._matrix);
        }
        
        public static bool operator < (Matrix matrix1, Matrix matrix2)
        {
            return !(matrix1 > matrix2);
        }

        private static double GetMainDiagonalSum(double[,] matrix)
        {
            double sum = 0;
            
            for (var index = 0; index < matrix.GetLength(0); index++)
            {
                sum += matrix[index, index];
            }

            return sum;
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
    }
}