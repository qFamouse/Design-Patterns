using System;
using DesignPatterns.SOLID.MatrixCalculator;
using DesignPatterns.SOLID.MatrixCalculator.Interfaces;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            UsualMatrix a = new UsualMatrix(new int[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            });

            ConstantMatrix b = new ConstantMatrix(1, 3);

            var c = a + b;
        }
    }
}