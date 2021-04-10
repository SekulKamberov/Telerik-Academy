namespace Homework
{
    using System;

    public class RotationMatrix
    {
        private int size;
        private int[,] matrix;
        private int rowChange;
        private int colChange;
        private int row;
        private int col;
        private int counter;

        public RotationMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[size, size];
            this.DrawMatrix();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value <= 0 || 100 < value)
                {
                    throw new ArgumentOutOfRangeException("Size is out of range: [1, 100]");
                }

                this.size = value;
            }
        }

        public void Print()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    Console.Write("{0,5}", this.matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private void ChangeDirection()
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int index = 0;
            for (int i = 0; i < dirX.Length; i++)
            {
                if (dirX[i] == this.rowChange && dirY[i] == this.colChange)
                {
                    index = i;
                    break;
                }
            }

            if (index != 7)
            {
                this.rowChange = dirX[index + 1];
                this.colChange = dirY[index + 1];
            }
            else if (index == 7)
            {
                this.rowChange = dirX[0];
                this.colChange = dirY[0];
            }
        }

        private bool HasEmptyNeighbourCell(int row, int col)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < dirX.Length; i++)
            {
                if (row + dirX[i] >= this.matrix.GetLength(0) || row + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (col + dirY[i] >= this.matrix.GetLength(0) || col + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (this.matrix[row + dirX[i], col + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool JumpToEmptyCell()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        this.counter++;
                        this.matrix[i, j] = this.counter;
                        this.row = i;
                        this.col = j;
                        this.rowChange = 1;
                        this.colChange = 1;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsValidCell()
        {
            bool isValidCell = this.row + this.rowChange < this.Size &&
                    this.row + this.rowChange >= 0 &&
                    this.col + this.colChange < this.Size &&
                    this.col + this.colChange >= 0 &&
                    this.matrix[this.row + this.rowChange, this.col + this.colChange] == 0;

            return isValidCell;
        }

        private void DrawMatrix()
        {
            this.counter = 1;
            this.row = 0;
            this.col = 0;
            this.rowChange = 1;
            this.colChange = 1;
            this.matrix[this.row, this.col] = this.counter;
            while (this.HasEmptyNeighbourCell(this.row, this.col) || this.JumpToEmptyCell())
            {
                while (this.IsValidCell() == false)
                {
                    this.ChangeDirection();
                }

                this.row += this.rowChange;
                this.col += this.colChange;
                this.counter++;
                this.matrix[this.row, this.col] = this.counter;
            }
        }
    }
}
