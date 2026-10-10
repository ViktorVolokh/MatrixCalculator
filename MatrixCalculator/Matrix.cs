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
        private set => _data[row, col] = value;
    }

    public double Determinant()
    {
        return 0;
    }

    public (Matrix upperTriangularMatrix, int swapsForDeterminant) GetUpperTriangularMatrix()
    {
        Matrix matrix = this.Clone();
        int swapsForDeterminant = 0;
        for (int i = 0; i < Cols-1; i++)
        {
            int startRow1 = matrix.FindFirstNonZeroRow(i, i);
            if (startRow1 != i && startRow1 != -1)
            {
                matrix.SwapRows(startRow1, i);
                swapsForDeterminant++;
            }

            if (startRow1 != -1)
            {
                startRow1 = matrix.FindFirstNonZeroRow(startRow1 + 1, i);
            }

            while (startRow1 != -1)
            {
                double multiplier = matrix[startRow1, i] / matrix[i, i];

                for (int j = 0; j < Cols; j++)
                {
                    matrix[startRow1, j] -= multiplier * matrix[i, j];
                }

                startRow1 = matrix.FindFirstNonZeroRow(startRow1, i);
            }
        }

        return (matrix, swapsForDeterminant);
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
    private void SwapRows(int row1, int row2)
    {
        for (int i = 0; i < Cols; i++)
        {
            double temp = this[row1, i];
            this[row1, i] = this[row2, i];
            this[row2, i] = temp;
        }
    }

    private void SwapCols(int col1, int col2)
    {
        for (int i = 0; i < Cols; i++)
        {
            double temp = this[col1, i];
            this[col1, i] = this[col2, i];
            this[col2, i] = temp;
        }
    }

    public Matrix Clone()
    {
        Matrix matrix = new Matrix(Rows, Cols);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                matrix[i, j] = this[i, j];
            }
        }
        
        return matrix;
    }
    
    private int FindFirstNonZeroRow(int startRow, int col)
    {
        for (int i = startRow; i < Rows; i++)
        {
            if (this[i, col] != 0)
            {
                return i;
            }
        }
        return -1;
    }
    
    // not esential methods for developer for checking

    public void FillMatrix()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                this[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

    public void PrintMatrix()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                Console.Write(this[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}