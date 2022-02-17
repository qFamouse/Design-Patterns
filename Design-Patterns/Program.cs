using System;
using DesignPatterns.SOLID.MatrixCalculator;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            UsualMatrix a = new UsualMatrix(new int[2, 2]
            {
                {2, 2},
                {2, 2}
            });

            ConstantMatrix b = new ConstantMatrix(1, 2);

            var c = b + a;

            var s = 5 + 5;
        }
    }
}