using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Interfaces
{
    public interface IMutableMatrix : IMatrix
    {
        void Set(int i, int j, int value);
    }
}