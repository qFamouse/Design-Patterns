using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Matrix
{
    public sealed class DiagonalMatrix : BaseMatrix
    {
        private readonly double[] _diagonalMatrix;
        public override int Size { get; }

        public DiagonalMatrix(double[] diagonalMatrix)
        {
            _diagonalMatrix = diagonalMatrix;
            Size = diagonalMatrix.Length;
        }

        public override double Get(int i, int j)
        {
            IndexesRangeValidation(i, j);
            return i == j ? _diagonalMatrix[i] : 0;
        }

        public override void Set(int i, int j, double value)
        {
            IsDiagonalIndexes(i, j);
            IndexesRangeValidation(i, j);
            _diagonalMatrix[i] = value;
        }

        public void IsDiagonalIndexes(in int i, in int j)
        {
            if (i != j)
            {
                throw new ArgumentException("You can change only diagonal elements");
            }
        }

        private void IndexesRangeValidation(in int i, in int j)
        {
            if (i < 0 || i >= Size ||
                j < 0 || j >= Size)
            {
                throw new ArgumentException("Invalid indexes");
            }
        }
    }
}
