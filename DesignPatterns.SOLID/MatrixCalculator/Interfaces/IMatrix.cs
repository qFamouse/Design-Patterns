using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.MatrixCalculator.Interfaces
{
    public interface IMatrix
    {
        int Size { get; }
        int Get(int i, int j);
    }
}