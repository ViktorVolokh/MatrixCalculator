namespace MatrixCalculator;

class Program
{
    
    static void Main(string[] args)
    {
        Matrix matrix = new Matrix(3, 3);
        matrix.FillMatrix();
        matrix.PrintMatrix();
        (Matrix test, int a, Matrix lowerTriangularMatrix) = matrix.GetUpperTriangularMatrix();
        /*Console.WriteLine();
        test.PrintMatrix();
        Console.WriteLine(matrix.Determinant());
        Console.WriteLine();
        matrix.GetTransposedMatrix().PrintMatrix();
        (Matrix test2, int b) = matrix.GetLowerTriangularMatrix();
        test2.PrintMatrix();
        */
        test.PrintMatrix();
        Console.WriteLine();
        lowerTriangularMatrix.PrintMatrix();
    }
}