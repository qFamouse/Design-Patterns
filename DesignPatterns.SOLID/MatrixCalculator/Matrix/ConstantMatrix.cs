using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Matrix
{
    class ConstantMatrix : BaseMatrix
    {
        private double _value;
        public override int Size { get; }

        public ConstantMatrix(double value, int size)
        {
            SizeIsValid(size);
            _value = value;
            Size = size;
        }

        public override double Get(int i, int j)
        {
            IndexWithinOfRange(i, j);
            return _value;
        }

        public override void Set(int i, int j, double value)
        {
            IndexWithinOfRange(i, j);
            _value = value;
        }

        private void IndexWithinOfRange(in int i, in int j)
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
