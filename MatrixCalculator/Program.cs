namespace MatrixCalculator;

class Program
{
    
    static void Main(string[] args)
    {
        Matrix matrix = new Matrix(3, 3);
        matrix.FillMatrix();
        matrix.PrintMatrix();
    }
}