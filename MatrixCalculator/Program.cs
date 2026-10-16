using System.Globalization;

namespace MatrixCalculator;

class Program
{
    
    static void Main(string[] args)
    {
        Matrix matrix = new Matrix(3, 4);
        matrix.FillMatrix();
        matrix.PrintMatrix();
        Console.WriteLine();
        Matrix matrix2 = matrix.GetGaussJordan();
        matrix2.PrintMatrix();
    }
}