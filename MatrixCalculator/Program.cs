using System.Globalization;
using System.Numerics;

namespace MatrixCalculator;

class Program
{
    
    static void Main(string[] args)
    {
        Matrix matrix1 = new Matrix(2, 2, true);
        matrix1.GetGaussJordan();
    }
}