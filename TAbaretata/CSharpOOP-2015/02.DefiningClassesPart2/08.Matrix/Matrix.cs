/*
 * Task 8: Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
 * Task 9: Implement an indexer this[row, col] to access the inner matrix cells.
 * Task 10: Implement the operators + and - (addition and subtraction of matrices of the same size) 
        and * for matrix multiplication. Throw an exception when the operation cannot be performed. 
        Implement the true operator (check for non-zero elements).
 */

namespace _08.Matrix
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Matrix<T> : IEnumerable<T> where T: struct, IFormattable
    {
        private T[,] matrix;

        public Matrix(int row, int col)
        {
            this.matrix = new T[row, col];
        }

        //task 9
        public T this[int row,int col]
        {
            get 
            {
                ExceptionHandle(row,col);
                return matrix[row, col];
            }
            set
            {
                ExceptionHandle(row, col);
                this.matrix[row, col] = value;
            }
        }

        private void ExceptionHandle(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
        }

        //task 10
        public static Matrix<T> operator +(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if ((matrixOne.matrix.GetLength(0) != matrixTwo.matrix.GetLength(0)) ||
                (matrixOne.matrix.GetLength(1) != matrixTwo.matrix.GetLength(1)))
            {
                throw new ArgumentException("Matrix's sizes are different");
            }

            Matrix<T> resultMatrix = new Matrix<T>(matrixOne.matrix.GetLength(0), matrixOne.matrix.GetLength(1));

            for (int r = 0; r < matrixOne.matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrixOne.matrix.GetLength(1); c++)
                {
                    resultMatrix[r, c] = (dynamic)matrixOne[r, c] + matrixTwo[r, c];
                }  
            }

            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if ((matrixOne.matrix.GetLength(0) != matrixTwo.matrix.GetLength(0)) ||
                (matrixOne.matrix.GetLength(1) != matrixTwo.matrix.GetLength(1)))
            {
                throw new ArgumentException("Matrix's sizes are different");
            }

            Matrix<T> resultMatrix = new Matrix<T>(matrixOne.matrix.GetLength(0), matrixOne.matrix.GetLength(1));

            for (int r = 0; r < matrixOne.matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrixOne.matrix.GetLength(1); c++)
                {
                    resultMatrix[r, c] = (dynamic)matrixOne[r, c] - matrixTwo[r, c];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.matrix.GetLength(0) != matrixTwo.matrix.GetLength(1))
            {
                throw new ArgumentException("Matrix's columns and rows should be equal");
            }

            Matrix<T> resultMatrix = new Matrix<T>(matrixOne.matrix.GetLength(0), matrixOne.matrix.GetLength(1));

            for (int r = 0; r < matrixOne.matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrixOne.matrix.GetLength(1); c++)
                {
                    for (int i = 0; i < matrixOne.matrix.GetLength(1); i++)
                    {
                        resultMatrix[r, c] = (dynamic)matrixOne[r, i] * matrixTwo[i, c];
                    }
                }
            }
            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrixOne)
        {
            bool result = false;
            for (int r = 0; r < matrixOne.matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrixOne.matrix.GetLength(1); c++)
                {
                    if ((dynamic)matrixOne[r,c] != 0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool operator false(Matrix<T> matrixOne)
        {
            bool result = true;
            for (int r = 0; r < matrixOne.matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrixOne.matrix.GetLength(1); c++)
                {
                    if ((dynamic)matrixOne[r, c] == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    sb.AppendFormat("{0} ", (dynamic)this.matrix[i,j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.matrix)
	        {
		        yield return item;
	        }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
