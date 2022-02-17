using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;

namespace DesignPatterns.SOLID.MatrixCalculator
{
    public abstract class BaseMatrix
    {
        #region Mathematical operations

        protected virtual double[,] Addition(IMatrix m1, IMatrix m2)
        {
            var sum = new double[m1.Size,m1.Size];

            for (int i = 0; i < m1.Size; i++)
            {
                for (int j = 0; j < m1.Size; j++)
                {
                    sum[i, j] = m1.Get(i, j) + m2.Get(i, j);
                }
            }

            return sum;
        }

        protected virtual double[,] Subtraction(IMatrix m1, IMatrix m2)
        {
            var sum = new double[m1.Size, m1.Size];

            for (int i = 0; i < m1.Size; i++)
            {
                for (int j = 0; j < m1.Size; j++)
                {
                    sum[i, j] = m1.Get(i, j) - m2.Get(i, j);
                }
            }

            return sum;
        }

        protected virtual double[,] Multiplication(IMatrix m1, IMatrix m2)
        {
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

            return sum;
        }

        protected virtual double Determinant(IMatrix matrix)
        {

        }

        #endregion

        #region Validators

        private protected static void SizeEqualValidation(int sizeA, int sizeB)
        {
            if (sizeA != sizeB)
            {
                throw new ArgumentException("The dimensions of the matrix are not equal");
            }
        }

        #endregion
    }
}
