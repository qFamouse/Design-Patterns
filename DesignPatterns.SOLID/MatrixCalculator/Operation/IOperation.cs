using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.SOLID.MatrixCalculator.Matrix;

namespace DesignPatterns.SOLID.MatrixCalculator.Operation
{
    public interface IOperation
    {
        BaseMatrix Calc(BaseMatrix a, BaseMatrix b);
    }
}
