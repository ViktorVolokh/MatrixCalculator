using System.Globalization;

namespace MatrixCalculator;

class Program
{
    
    static void Main(string[] args)
    {
        Matrix matrix = new Matrix(3, 3);
        matrix.FillMatrix();
        matrix.PrintMatrix();
        Console.WriteLine();
        Matrix matrix2 = matrix.GetDiagonalMatrix();
        matrix2.PrintMatrix();
    }
}