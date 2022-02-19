using DesignPatterns.SOLID.MatrixCalculator.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Operation
{
    class Division : IOperation
    {
        public static BaseMatrix Inverse(BaseMatrix matrix)
        {
            double det = matrix.Determinant();
            if (det.Equals(0))
            {
                Console.WriteLine("The determinant is 0, there is no inverse matrix");
            }
            else
            {
                double[,] adjM = GetAdjointMatrix(matrix);
                for (int i = 0; i < matrix.Size; i++)
                {
                    for (int j = i + 1; j < matrix.Size; j++)
                    {
                        var div = matrix.Get(i, j) / det;
                        matrix.Set(i, j, div);
                    }
                }
            }
            return matrix;
        }

        public static double[,] GetAdjointMatrix(BaseMatrix matrix)
        {
            if (matrix.Size <= 2) return matrix.ToArray();
            double[,] result = new double[matrix.Size, matrix.Size];
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    double[,] temp = GetSubArr(matrix.ToArray(), i, j);
                    result[i, j] = (float)Math.Pow(-1, i + j) * new UsualMatrix(temp).Determinant();
                }
            }
            return result;
        }

        public static double[,] GetSubArr(double[,] arr, int x, int y)
        {
            if (arr.GetLength(0) <= 1) return arr;
            double[,] temp = new double[arr.GetLength(0) - 1, arr.GetLength(1) - 1];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i == x) continue;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == y) continue;
                    temp[i < x ? i : i - 1, j < y ? j : j - 1] = arr[i, j];
                }
            }

            return temp;
        }

        public BaseMatrix Calc(BaseMatrix a, BaseMatrix b)
        {
            return new Multiplication().Calc(a, Inverse(b));
        }
    }
}
