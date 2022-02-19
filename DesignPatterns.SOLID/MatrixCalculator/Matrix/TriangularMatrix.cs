using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Matrix
{
    class TriangularMatrix : BaseMatrix
    {
        private readonly double[][] _matrix;
        private readonly bool _isUpperTriangular;
        public override int Size { get; }

        public TriangularMatrix(double[][] matrix, bool isUpperTriangular = false)
        {
            IsTriangularMatrix(matrix);
            _matrix = matrix;
            Size = matrix.Length;
            _isUpperTriangular = isUpperTriangular;
        }

        public override double Get(int i, int j)
        {
            if (_isUpperTriangular)
            {
                return j < i ? 0 : _matrix[j][i];
            }
            else
            {
                return j < i ? _matrix[i][j] : 0;
            }
        }

        public override void Set(int i, int j, double value)
        {
            IsValidIndexes(i, j);

            if (i < j)
            {
                _matrix[i][j] = value;
            }
            else
            {
                _matrix[j][i] = value;
            }
        }

        private void IsTriangularMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Length != i + 1)
                {
                    throw new ArgumentException("This is not a triangular matrix");
                }
            }
        }

        private void IsValidIndexes(in int i, in int j)
        {
            if (_isUpperTriangular && i > j)
            {
                throw new ArgumentException("You can change only upper elements");
            }

            if (!_isUpperTriangular && i < j)
            {
                throw new ArgumentException("You can change only lower elements");
            }
        }
    }
}
