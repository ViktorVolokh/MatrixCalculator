namespace MatrixCalculator;

public class Matrix : IEquatable<Matrix>
{
    public readonly int Rows;
    public readonly int Cols;
    private readonly double[,] _data;

    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        _data = new double[Rows, Cols];
    }
    
    public Matrix(int rows, int cols, bool isFilledByUser)
    {
        Rows = rows;
        Cols = cols;
        _data = new double[Rows, Cols];
        bool[,] isCellSet = new bool[Rows, Cols];
        if (isFilledByUser)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    while (!isCellSet[i, j])
                    {
                        isCellSet[i, j] = double.TryParse(Console.ReadLine(), out double value);
                        if (isCellSet[i, j])
                        {
                            _data[i, j] = value;
                        }
                    }
                }
            }
        }
    }

    public double this[int row, int col]
    {
        get => _data[row, col];
        private set => _data[row, col] = value;
    }
    
    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrix = Add(matrix1, matrix2);
        return matrix;
    }
    
    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrix = Subtruct(matrix1, matrix2);
        return matrix;
    }
    
    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
        Matrix matrix = Multiply(matrix1, matrix2);
        return matrix;
    }
    public static bool operator ==(Matrix? left, Matrix? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        
        return left.Equals(right);
    }

    public static bool operator !=(Matrix? left, Matrix? right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
    
        hash.Add(Rows);
        hash.Add(Cols);

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                hash.Add(this[i, j]);
            }
        }

        return hash.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Matrix);
    }

    public bool Equals(Matrix? other)
    {
        if (other is null) return false;

        if (ReferenceEquals(this, other)) return true;
        
        if (Rows != other.Rows || Cols != other.Cols) return false;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (this[i, j] != other[i, j]) return false;
            }
        }
        
        return true;
    }

    public static Matrix Add(Matrix matrix1, Matrix matrix2)
    {
        Matrix outMatrix = new Matrix(matrix1.Rows, matrix1.Cols);
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Cols; j++)
            {
                outMatrix[i, j] =  matrix1[i, j] + matrix2[i, j];
            }
        }
        return outMatrix;
    }

    public static Matrix Subtruct(Matrix matrix1, Matrix matrix2)
    {
        Matrix outMatrix = new Matrix(matrix1.Rows, matrix1.Cols);
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Cols; j++)
            {
                outMatrix[i, j] =  matrix1[i, j] - matrix2[i, j];
            }
        }
        return outMatrix;
    }

    public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
    {
        Matrix outMatrix = new Matrix(matrix1.Rows, matrix1.Cols);
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Cols; j++)
            {
                for (int k = 0; k < matrix2.Rows; k++)
                {
                    outMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }  
            }
        }
        return outMatrix;
    }
    
    public double Determinant()
    {
        double determinant = 1; 
        (Matrix matrix, int swaps, _) = this.GetUpperTriangularMatrix();
        for (int i = 0; i < Rows; i++)
        {
            determinant *= matrix[i, i];
        }

        if (swaps % 2 == 0)
        {
            return determinant;
        }
        else
        {
            return -1 * determinant;
        }
    }

    public (Matrix upperTriangularMatrix, int swapsForDeterminant, Matrix lowerTriangularMatrix) GetUpperTriangularMatrix()
    {
        Matrix lowerTriangularMatrix = new Matrix(Rows, Cols);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                if (i > j)
                {
                    lowerTriangularMatrix[i, j] = 0;
                }
                else if (i == j)
                {
                    lowerTriangularMatrix[i, j] = 1;
                }
            }
        }
        Matrix matrix = this.Clone();
        int swapsForDeterminant = 0;
        for (int i = 0; i < Rows-1; i++)
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
                
                lowerTriangularMatrix[startRow1, i] = multiplier;
                
                for (int j = 0; j < Cols; j++)
                {
                    matrix[startRow1, j] -= multiplier * matrix[i, j];
                }

                startRow1 = matrix.FindFirstNonZeroRow(startRow1, i);
            }
        }

        return (matrix, swapsForDeterminant, lowerTriangularMatrix);
    }
    
    public Matrix GetGaussJordan()
    {
        if (Determinant() == 0)
        {
            throw new DivideByZeroException();
        }
        (Matrix matrix, _, _) = this.GetUpperTriangularMatrix();
        for (int i = 0; i < Rows; i++)
        {
            double divider = matrix[i, i];
            if (divider == 0)
            {
                continue;
            }
            {
                
            }
            for (int j = 0; j < Cols; j++)
            {
                matrix[i, j] /= divider;
            }
        }
        for (int i = Rows - 1; i > 0; i--)
        {
            int startRow1 = matrix.FindFirstNonZeroRowUpper(i, i);

            if (startRow1 != -1)
            {
                startRow1 = matrix.FindFirstNonZeroRowUpper(startRow1 - 1, i);
            }

            while (startRow1 != -1)
            {
                double multiplier = matrix[startRow1, i] / matrix[i, i];
                
                
                for (int j = 0; j < Cols; j++)
                {
                    matrix[startRow1, j] -= multiplier * matrix[i, j];
                }

                startRow1 = matrix.FindFirstNonZeroRowUpper(startRow1, i);
            }
        }
        return matrix;
    }
    
    public Matrix GetTransposedMatrix()
    {
        Matrix matrix = new Matrix(Rows, Cols);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                matrix[i, j] = this[j, i];
            }
        }
        return matrix;
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
    
    private int FindFirstNonZeroRowUpper(int startRow, int col)
    {
        for (int i = startRow; i > -1; i--)
        {
            if (this[i, col] != 0)
            {
                return i;
            }
        }
        return -1;
    }
    
    // not esential methods for developer for checking

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