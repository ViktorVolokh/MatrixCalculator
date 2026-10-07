namespace MatrixCalculator;

public class Matrix
{
    public readonly int Rows;
    public readonly int Cols;
    private readonly double[,] _data;
    private readonly bool[,] _isCellSet;
    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        _data = new double[Rows, Cols];
        _isCellSet = new bool[rows, cols];
    }

    public double this[int row, int col]
    {
        get => _data[row, col];
        set
        {
            if (_isCellSet[row, col])
            {
                throw new InvalidOperationException($"Cell [{row}, {col}] is already set! Rewriting is not allowed.");
            }

            _data[row, col] = value;
            _isCellSet[row, col] = true;
        }
    }

    public double Determinant()
    {
        return 0;
    }

    public (Matrix upperTriangularMatrix, int swapsForDeterminant) GetUpperTriangularMatrix()
    {
        
        
        Matrix a = new Matrix(3, 3);
        return (a, 0);
    }
    
    public (Matrix lowerTriangularMatrix, int swapsForDeterminant) GetLowerTriangularMatrix()
    {
        
        
        Matrix a = new Matrix(3, 3);
        return (a, 0);
    }
    
    public Matrix GetDiagonalMatrix()
    {
        Matrix a = new Matrix(3, 3);
        return a;
    }
    
    //supporting methods
    public void SwapRows(int row1, int col1, int row2, int col2)
    {
        
    }

    public void SwapCols(int col1, int col2, int row1, int row2)
    {

    }
}