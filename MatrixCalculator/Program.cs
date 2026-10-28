using System.Globalization;
using System.Numerics;

namespace MatrixCalculator;

class Program
{
    
    static void Main(string[] args)
    {
        Matrix matrix = new Matrix(2, 2, true);
        Matrix mtrix = Matrix.Multiply(matrix, matrix);
        mtrix.PrintMatrix();
    }
}