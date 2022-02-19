using System;

namespace DesignPatterns.SOLID.MatrixCalculator.Matrix
{
    public abstract class BaseMatrix
    {
        public abstract int Size { get; }
        public abstract double Get(int i, int j);
        public abstract void Set(int i, int j, double value);

        public virtual double Determinant()
        {
            var matrix = ToArray();

            double det = 1;

            for (int i = 0; i < Size; ++i)
            {
                double mx = Math.Abs(matrix[i,i]);
                int idx = i;
                for (int j = i + 1; j < Size; ++j)
                {
                    if (mx < Math.Abs(matrix[i,j]))
                    {
                        mx = Math.Abs(matrix[i, idx = j]);
                    }
                }

                if (idx != i)
                {
                    for (int j = i; j < Size; ++j)
                    {
                        (matrix[j, i], matrix[j, idx]) = (matrix[j, idx], matrix[j, i]);
                    }

                    det = -det;
                }

                for (int k = i + 1; k < Size; ++k)
                {
                    double t = matrix[k, i] / matrix[i, i];

                    for (int j = i; j < Size; ++j)
                    {
                        matrix[k, j] -= matrix[i, j] * t;
                    }
                }
            }

            for (int i = 0; i < Size; ++i)
            {
                det *= matrix[i, i];
            }

            return det;
        }

        public virtual double[,] ToArray()
        {
            var matrix = new double[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = Get(i, j);
                }
            }

            return matrix;
        }

        public virtual double[] GetRow(int rowIndex)
        {
            if (rowIndex >= Size)
            {
                throw new IndexOutOfRangeException("Invalid row index");
            }

            var row = new double[Size];

            for (int i = 0; i < Size; i++)
            {
                row[i] = Get(rowIndex, i);
            }

            return row;
        }
    }
}