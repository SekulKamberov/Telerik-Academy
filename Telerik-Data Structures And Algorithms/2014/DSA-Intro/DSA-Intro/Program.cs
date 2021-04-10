namespace DSA_Intro
{
    class Program
    {
        static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                    if (arr[start] < arr[end])
                    { 
                        start++; 
                        count++; 
                    }
                    else
                    {
                        end--;
                        count++;
                    }
            }
            return count;
        }

        public static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
                if (matrix[row, 0] % 2 == 0)
                    for (int col = 0; col < matrix.GetLength(1); col++)
                        if (matrix[row, col] > 0)
                            count++;
            return count;
        }

        public static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
                sum += matrix[row, col];
            if (row + 1 < matrix.GetLength(1))
                sum += CalcSum(matrix, row + 1);
            return sum;
        }


        static void Main(string[] args)
        {
            var arr = new int[]{1, 9, 3, 7, 5, 6, 4, 8, 2, 10 };
            System.Console.WriteLine(Compute(arr));

            var matrix = new[,] { { 2, 3, 4, 5, 6 }, { 11, 8, 22, 10, 11 }, { 7, 12, 9, 54, 11 }, { 54, 12, 9, 19, 11 }, { 89, 8, 9, 10, 11 } };
            System.Console.WriteLine(CalcCount(matrix));

            System.Console.WriteLine(CalcSum(matrix, 2));
        }
    }
}
