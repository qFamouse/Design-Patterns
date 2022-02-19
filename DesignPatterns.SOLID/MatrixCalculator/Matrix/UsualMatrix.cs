using System;

namespace DesignPatterns.SOLID.MatrixCalculator.Matrix
{
    public sealed class UsualMatrix : BaseMatrix
    {
        public override int Size { get; }

        private readonly double[,] _matrix;

        public UsualMatrix(double[,] matrix)
        {
            MatrixIsNotNull(matrix);
            IsSquareMatrix(matrix);

            _matrix = matrix;
            Size = matrix.GetLength(0);
        }

        public UsualMatrix(int size)
        {
            Size = size;
            _matrix = new double[size, size];
        }

        public override double Get(int i, int j) => _matrix[i, j];

        public override void Set(int i, int j, double value) => _matrix[i, j] = value;

        private static void IsSquareMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("This matrix is not square");
            }
        }

        private static void MatrixIsNotNull(double[,] matrix)
        {
            if (matrix is null)
            {
                throw new NullReferenceException("Matrix is null");
            }
        }
    }
}
