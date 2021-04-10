namespace LongestCommonSubsequence
{
    using System;
    using System.Linq;
    using System.Text;

    public static class LongestCommonSubsequenceCalculator
    {
        public static int[,] DrawLongestCommonSequenceMatrix(string first, string second)
        {
            int rows = first.Length;
            int cols = second.Length;
            int[,] matrix = new int[rows + 1, cols + 1];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        matrix[i, j] = matrix[(i - 1), (j - 1)] + 1;
                    }
                    else
                    {
                        int max = matrix[i, j - 1];
                        if (max < matrix[i - 1, j])
                        {
                            max = matrix[i - 1, j];
                        }

                        matrix[i, j] = max;
                    }
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix, string first, string second)
        {
            Console.WriteLine("    " + string.Join(" ", second.ToCharArray()));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i > 0)
                {
                    Console.Write("{0} ", first[i - 1]);
                }
                else
                {
                    Console.Write("  ");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public static string ExtractSequence(int[,] matrix, string first, string second)
        {
            int row = first.Length;
            int col = second.Length;
            var stringBuilder = new StringBuilder();
            while (row != 0 && col != 0)
            {
                if (first[row - 1] == second[col - 1])
                {
                    stringBuilder.Append(second[col - 1]);
                    row--;
                    col--;
                }
                else if (matrix[row, col] == matrix[row - 1, col])
                {
                   row--;
                }
                else
                {
                    col--;
                }
            }

            return string.Join(string.Empty, stringBuilder.ToString().Reverse());
        }
    }
}
