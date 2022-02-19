using DesignPatterns.SOLID.MatrixCalculator.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace DesignPatterns.SOLID.MatrixCalculator.Operation
{
    class Multiplication : IOperation
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
                    double multiply = 0;
                    for (var k = 0; k < size; k++)
                    {
                        multiply += a.Get(i, k) * b.Get(k, j);
                    }
                    matrix.Set(i, j, multiply);
                }
            }

            return matrix;
        }
    }
}
