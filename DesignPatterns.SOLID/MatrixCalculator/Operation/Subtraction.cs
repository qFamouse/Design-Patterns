using DesignPatterns.SOLID.MatrixCalculator.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Operation
{
    public class Subtraction : IOperation
    {
        public BaseMatrix Calc(BaseMatrix a, BaseMatrix b)
        {
            int size = a.Size;
            if (size != b.Size)
            {
                throw new ArgumentException("The dimensions of the matrix must be equal");
            }

            BaseMatrix matrix = new UsualMatrix(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double sum = a.Get(i, j) - b.Get(i, j);
                    matrix.Set(i, j, sum);
                }
            }

            return matrix;
        }
    }
}
