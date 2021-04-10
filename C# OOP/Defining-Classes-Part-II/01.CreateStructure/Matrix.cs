namespace _01.CreateStructure
{
    using System;
    using System.Text;

    public class Matrix<T> where T :
           struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private const int DefaultSize = 8;

        public Matrix()
            : this(DefaultSize, DefaultSize)
        {
        }

        public Matrix(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                throw new ArgumentOutOfRangeException("Negative row or col value");
            }
            else
            {
                this.Row = row;
                this.Col = col;
                this.MatrixArray = new T[row, col];
            }
        }

        public Matrix(T[,] matrix)
            : this(matrix.GetLength(0), matrix.GetLength(1))
        {
            this.MatrixArray = matrix;
        }

        public T[,] MatrixArray { get; set; }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0 || this.Row < row || this.Col < col)
                {
                    throw new ArgumentOutOfRangeException("Index out of range for Row or Col");
                }
                else
                {
                    return this.MatrixArray[row, col];
                }
            }

            set
            {
                if (row < 0 || col < 0 || this.Row < row || this.Col < col)
                {
                    throw new ArgumentOutOfRangeException("Index out of range for Row or Col");
                }
                else
                {
                    this.MatrixArray[row, col] = value;
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Row == second.Row && first.Col == second.Col)
            {
                Matrix<T> tempArr = new Matrix<T>(first.Row, first.Col);

                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        checked
                        {
                            tempArr[i, j] = (dynamic)first[i, j] + second[i, j];
                        }
                    }
                }

                return tempArr;
            }
            else
            {
                throw new MatrixException("The given matrix are not with the same Col and Row size");
            }
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Row == second.Row && first.Col == second.Col)
            {
                Matrix<T> tempArr = new Matrix<T>(first.Row, first.Col);

                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        checked
                        {
                            tempArr[i, j] = (dynamic)first[i, j] - second[i, j];
                        }
                    }
                }

                return tempArr;
            }
            else
            {
                throw new MatrixException("The given matrix are not with the same Col and Row size");
            }
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Col == second.Row && (first.Row > 0 && second.Col > 0 && first.Col > 0))
            {
                Matrix<T> final = new Matrix<T>(first.Row, second.Col);

                for (int i = 0; i < final.Row; i++)
                {
                    for (int j = 0; j < final.Col; j++)
                    {
                        final[i, j] = (dynamic)0;
                        for (int k = 0; k < first.Col; k++)
                        {
                            checked
                            {
                                final[i, j] = final[i, j] + ((dynamic)first[i, k] * second[k, j]);
                            }
                        }
                    }
                }

                return final;
            }
            else
            {
                throw new MatrixException("Row on the first matrix and col on the second matrix, are with different size, multiplication cannot be done.");
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            int zero = 0;

            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if ((dynamic)matrix[i, j] == zero)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            int zero = 0;

            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if ((dynamic)matrix[i, j] == zero)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    builder.Append(this.MatrixArray[i, j] + " ");
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
