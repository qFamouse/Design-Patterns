using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;

namespace DesignPatterns.SOLID.MatrixCalculator
{
    class ConstantDiagonalMatrix : IMatrix
    {
        private readonly int _diagonalValue;
        public int Size { get; }

        ConstantDiagonalMatrix(int diagonalValue, int size)
        {
            SizeValidation(size);

            _diagonalValue = diagonalValue;
            Size = size;
        }

        public int Get(int i, int j)
        {
            IndexesRangeValidation(i, j);
            return i == j ? _diagonalValue : 0;
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