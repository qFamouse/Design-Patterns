using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Matrix
{
    class ConstantDiagonalMatrix : BaseMatrix
    {
        private double _diagonalValue;
        public override int Size { get; }

        ConstantDiagonalMatrix(int diagonalValue, int size)
        {
            SizeValidation(size);

            _diagonalValue = diagonalValue;
            Size = size;
        }

        public override double Get(int i, int j)
        {
            IndexesRangeValidation(i, j);
            return i == j ? _diagonalValue : 0;
        }

        public override void Set(int i, int j, double value)
        {
            if (i != j)
            {
                throw new ArgumentException("You can't change not diagonal element");
            }

            _diagonalValue = value;
        }

        private void SizeValidation(in int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size must be positive");
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
