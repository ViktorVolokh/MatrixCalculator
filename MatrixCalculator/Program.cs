namespace MatrixCalculator;

class Program
{
    
    static void Main(string[] args)
    {
        Matrix matrix = new Matrix(3, 3);
        matrix.FillMatrix();
        matrix.PrintMatrix();
        (Matrix test, int a) = matrix.GetUpperTriangularMatrix();
        Console.WriteLine();
        test.PrintMatrix();
        Console.WriteLine(matrix.Determinant());
    }
}