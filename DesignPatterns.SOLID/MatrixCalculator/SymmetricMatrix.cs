using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;

namespace DesignPatterns.SOLID.MatrixCalculator
{
    class SymmetricMatrix : IMutableMatrix
    {
        private readonly int[][] _matrix;
        public int Size { get; }

        SymmetricMatrix(int[][] matrix)
        {
            IsTriangularMatrix(matrix);
            _matrix = matrix;
            Size = matrix.Length;
        }

        public int Get(int i, int j)
        {
            return j < i ? _matrix[i][j] : _matrix[j][i];
        }

        public void Set(int i, int j, int value)
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

        private void IsTriangularMatrix(int[][] matrix)
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
