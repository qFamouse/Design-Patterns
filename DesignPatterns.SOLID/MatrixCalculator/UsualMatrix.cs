using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace DesignPatterns.SOLID.MatrixCalculator
{
    public sealed class UsualMatrix : IMutableMatrix
    {
        private readonly int[,] _matrix;
        public int Size { get; }

        public UsualMatrix(int[,] matrix)
        {
            MatrixIsNotNull(matrix);
            IsSquareMatrix(matrix);

            _matrix = matrix;
            Size = matrix.GetLength(0);
        }

        public int Get(int i, int j) => _matrix[i, j];
        public void Set(int i, int j, int value) => _matrix[i, j] = value;

        #region Validation

        private void IsSquareMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("This matrix is not square");
            }
        }

        private void MatrixIsNotNull(int[,] matrix)
        {
            if (matrix is null)
            {
                throw new NullReferenceException("Matrix is null");
            }
        }

        #endregion
    }
}