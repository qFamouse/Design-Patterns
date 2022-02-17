using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;

namespace DesignPatterns.SOLID.MatrixCalculator
{
    public class ConstantMatrix : IMatrix
    {
        private readonly int _value;
        public int Size { get; }

        public ConstantMatrix(int value, int size)
        {
            SizeIsValid(size);
            _value = value;
            Size = size;
        }

        public int Get(int i, int j)
        {
            IndexWithinOfRange(i, j);
            return _value;
        }
        private void IndexWithinOfRange(in int i,in int j)
        {
            if (i >= Size || i < 0 ||
                j >= Size || j < 0)
            {
                throw new IndexOutOfRangeException("Incorrect indexes");
            }
        }

        private void SizeIsValid(in int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size must be positive");
            }
        }
    }
}