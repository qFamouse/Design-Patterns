using System;
using DesignPatterns.SOLID.MatrixCalculator.Matrix;
using DesignPatterns.SOLID.MatrixCalculator.Operation;
using Microsoft.VisualBasic.CompilerServices;

namespace DesignPatterns.Tests.SOLID
{
    static class MatrixCalculator
    {
        private static BaseMatrix ChoosingMatrix()
        {
            Console.WriteLine("Write matrix size");
            int size = ReadNumber();

            int? type = null;
            while (type is null)
            {
                Console.WriteLine("Choose Matrix Type");
                Console.WriteLine(@"
1 - Usual Matrix
2 - Constant Matrix
3 - Diagonal Matrix
4 - Constant Diagonal Matrix
5 - Symmetric Matrix
6 - Upper Triangular Matrix
7 - Down Triangular Matrix");

                if (int.TryParse(Console.ReadLine(), out int inputNumber))
                {
                    type = inputNumber;
                }
            }

            bool isUpperTriangularMatrix = false;
            switch (type)
            {
                case 1:
                    var usualMatrix = new double[size, size];
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            WriteMatrix(usualMatrix);
                            Console.WriteLine($"matrix[{i}{j}]"); 
                            usualMatrix[i, j] = ReadNumber();
                        }
                    }

                    return new UsualMatrix(usualMatrix);

                case 2:
                    Console.WriteLine("Enter the value for constant matrix");
                    var matrixValue = ReadNumber();
                    return new ConstantMatrix(matrixValue, size);

                case 3:
                    Console.WriteLine("Write only diagonal elements for diagonal matrix");
                    var diagonalMatrix = new double[size];
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write($"matrix[{i}, {i}] = ");
                        diagonalMatrix[i] = ReadNumber();
                    }

                    return new DiagonalMatrix(diagonalMatrix);

                case 4:
                    Console.WriteLine("Enter constant diagonal value for matrix");
                    var diagonalValue = ReadNumber();
                    return new ConstantDiagonalMatrix(diagonalValue, size);

                case 5:
                    var symmetricMatrix = new double[size][];
                    for (int i = 0; i < size; i++)
                    {
                        symmetricMatrix[i] = new double[i + 1];
                    }

                    for (int i = 0; i < symmetricMatrix.Length; i++)
                    {
                        for (int j = 0; j < symmetricMatrix[i].Length; j++)
                        {
                            WriteMatrix(symmetricMatrix);
                            symmetricMatrix[i][j] = ReadNumber();
                        }
                    }

                    return new SymmetricMatrix(symmetricMatrix);

                case 6:
                    isUpperTriangularMatrix = true;
                    goto case 7;
                case 7:
                    var triangularMatrix = new double[size][];
                    for (int i = 0; i < size; i++)
                    {
                        triangularMatrix[i] = new double[i + 1];
                    }

                    for (int i = 0; i < triangularMatrix.Length; i++)
                    {
                        for (int j = 0; j < triangularMatrix[i].Length; j++)
                        {
                            WriteTriangularMatrix(triangularMatrix, isUpperTriangularMatrix);
                            triangularMatrix[i][j] = ReadNumber();
                        }
                    }

                    return new TriangularMatrix(triangularMatrix, isUpperTriangularMatrix);
                default: throw new ArgumentException("Unknown type");
            }
        }

        private static int ReadNumber()
        {
            string number = null;
            while (number is null)
            {
                number = Console.ReadLine();
            }

            return int.Parse(number);
        }

        private static void WriteTriangularMatrix(double[][] matrix, bool isUpperTriangular)
        {
            const int offset = 14; // Offset for values
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (isUpperTriangular)
                    {
                        if (j < i)
                        {
                            Console.Write($"{0,offset:g6}");
                        }
                        else
                        {
                            Console.Write($"{matrix[j][i],offset:g6}");
                        }
                    }
                    else
                    {
                        if (j < i)
                        {
                            Console.Write($"{matrix[i][j],offset:g6}");
                        }
                        else
                        {
                            Console.Write($"{0,offset:g6}");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private static void WriteMatrix(double[,] matrix)
        {
            const int offset = 14; // Offset for values
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{matrix[row, column],offset:g6}");
                }
                Console.WriteLine();
            }
        }

        private static void WriteMatrix(double[][] matrix)
        {
            const int offset = 14; // Offset for values
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j],offset:g6}");
                }
                Console.WriteLine();
            }
        }

        private static BaseMatrix Operation(BaseMatrix a, BaseMatrix b)
        {
            Console.WriteLine("Choose operation");
            Console.WriteLine(@"
1 - Addition
2 - Subtract
3 - Multiplication
4 - Division");
            var operation = ReadNumber();

            switch (operation)
            {
                case 1: return new Addition().Calc(a, b);
                case 2: return new Subtraction().Calc(a, b);
                case 3: return new Multiplication().Calc(a, b);
                case 4: return new Division().Calc(a, b);
                default: throw new ArgumentException("Unknown operation");
            }

        }

        public static void Test()
        {
            Console.WriteLine("Matrix A");
            var A = ChoosingMatrix();
            Console.WriteLine("Matrix B");
            var B = ChoosingMatrix();

            Console.Clear();
            Console.WriteLine("Matrix A");
            WriteMatrix(A.ToArray());
            Console.WriteLine("Matrix B");
            WriteMatrix(B.ToArray());

            var C = Operation(A, B);
            WriteMatrix(C.ToArray());
        }
    }
}
