using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;

namespace DesignPatterns.SOLID.MatrixCalculator
{
    public class DiagonalMatrix : IMutableMatrix
    {
        private readonly int[] _diagonalMatrix;
        public int Size { get; }

        public DiagonalMatrix(int[] diagonalMatrix)
        {
            _diagonalMatrix = diagonalMatrix;
            Size = diagonalMatrix.Length;
        }

        public int Get(int i, int j)
        {
            IndexesRangeValidation(i, j);
            return i == j ? _diagonalMatrix[i] : 0;
        }

        public void Set(int i, int j, int value)
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
