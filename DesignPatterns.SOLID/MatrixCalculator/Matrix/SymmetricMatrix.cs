using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Matrix
{
    public sealed class SymmetricMatrix : BaseMatrix
    {
        private readonly double[][] _matrix;
        public override int Size { get; }

        SymmetricMatrix(double[][] matrix)
        {
            IsTriangularMatrix(matrix);
            _matrix = matrix;
            Size = matrix.Length;
        }

        public override double Get(int i, int j)
        {
            return j < i ? _matrix[i][j] : _matrix[j][i];
        }

        public override void Set(int i, int j, double value)
        {
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
                    throw new ArgumentException("This is not a symmetric matrix");
                }
            }
        }
    }
}
