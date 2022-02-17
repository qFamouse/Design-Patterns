using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace DesignPatterns.SOLID.MatrixCalculator
{
    public sealed class UsualMatrix : BaseMatrix, IMutableMatrix
    {
        private readonly double[,] _matrix;
        public int Size { get; }

        public UsualMatrix(double[,] matrix)
        {
            MatrixIsNotNull(matrix);
            IsSquareMatrix(matrix);

            _matrix = matrix;
            Size = matrix.GetLength(0);
        }

        public double Get(int i, int j) => _matrix[i, j];
        public void Set(int i, int j, double value) => _matrix[i, j] = value;

        #region Operators

        public static UsualMatrix operator +(UsualMatrix m1, IMatrix m2)
        {
            EqualSizeValidation(m1.Size, m2.Size);
            double[,] sum = Addition(m1, m2);
            return new UsualMatrix(sum);
        }

        public static UsualMatrix operator -(UsualMatrix m1, IMatrix m2)
        {
            EqualSizeValidation(m1.Size, m2.Size);

            var sum = new double[m1.Size, m1.Size];

            for (int i = 0; i < m1.Size; i++)
            {
                for (int j = 0; j < m1.Size; j++)
                {
                    sum[i, j] = m1.Get(i, j) - m2.Get(i, j);
                }
            }

            return new UsualMatrix(sum);
        }

        public static UsualMatrix operator *(UsualMatrix m1, IMatrix m2)
        {
            EqualSizeValidation(m1.Size, m2.Size);

            var sum = new double[m1.Size, m1.Size];

            for (var i = 0; i < m1.Size; i++)
            {
                for (var j = 0; j < m1.Size; j++)
                {
                    sum[i, j] = 0;

                    for (var k = 0; k < m1.Size; k++)
                    {
                        sum[i, j] += m1.Get(i, k) * m2.Get(k, j);
                    }
                }
            }

            return new UsualMatrix(sum);
        }



        #endregion

        #region Validation

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

        private static void EqualSizeValidation(int size1, int size2)
        {
            if (size1 != size2)
            {
                throw new ArithmeticException("The dimensions of the matrix are not equal");
            }
        }


        #endregion

    }
}