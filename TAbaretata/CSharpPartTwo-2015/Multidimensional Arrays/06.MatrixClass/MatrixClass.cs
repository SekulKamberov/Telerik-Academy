using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a class Matrix, to hold a matrix of integers. Overload the operators for adding, 
//subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString()

class Matrix
{
    private int[,] matrix;
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }
    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }
    public int Columns
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }
    public static Matrix operator +(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Columns);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] + second[row, col];
            }
        }
        return result;
    }
    public static Matrix operator -(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Columns);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] - second[row, col];
            }
        }
        return result;
    }
    public static Matrix operator *(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Columns);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] * second[col, row];
            }
        }
        return result;
    }
    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }
    public override string ToString()
    {
        string result = null;
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                result += matrix[row, col] + " ";
            }
            result += Environment.NewLine;
        }
        return result;
    }
}
class PrintMatrix
{
    static void Main()
    {
        Matrix matrix1 = new Matrix(3, 3);
        Matrix matrix2 = new Matrix(3, 3);
        Random randomGen = new Random();
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix2.Columns; j++)
            {
                matrix1[i, j] = randomGen.Next(20);
                matrix2[i, j] = randomGen.Next(20);
            }
        }
        Console.WriteLine("Matrix 1: ");
        Console.WriteLine(matrix1);
        Console.WriteLine("Matrix 2: ");
        Console.WriteLine(matrix2);
        Console.WriteLine("Matrix 1 + Matrix 2: ");
        Console.WriteLine(matrix1 + matrix2);
        Console.WriteLine("Matrix 1 - Matrix 2: ");
        Console.WriteLine(matrix1 - matrix2);
        Console.WriteLine("Matrix 1 * Matrix 2: ");
        Console.WriteLine(matrix1 * matrix2);
    }
}