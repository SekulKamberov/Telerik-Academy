namespace DS_EXAM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static int[,] arr;

        static int path;

        static int startX;
        static int startY;

        static int rows;
        static int cols;

        static int maxJumValue = 0;

        static void Main(string[] args)
        {
            arr = ReadArray();

            FindPathToExit(startX, startY);

            Console.WriteLine(maxJumValue);
        }

        static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (arr[row, col] > arr.GetLength(0) || arr[row, col] > arr.GetLength(1))
            {
                return;
            }

            if (arr[row, col] == -1 || arr[row, col] == -2)
            {
                if (maxJumValue < path)
                {
                    maxJumValue = path;
                }
                return;
            }

            int innerJumpValue = arr[row, col];

            if(innerJumpValue > arr.GetLength(0) || innerJumpValue > arr.GetLength(1))
            {
                return;
            }

            path += innerJumpValue;

            if (arr[row, col] != -1 && arr[row, col] != -2)
            {
                arr[row, col] = -2;

                FindPathToExit(row, col - innerJumpValue);
                FindPathToExit(row - innerJumpValue, col);
                FindPathToExit(row, col + innerJumpValue);
                FindPathToExit(row + innerJumpValue, col);

                arr[row, col] = innerJumpValue;

            }

            path -= innerJumpValue;
        }

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < arr.GetLength(0);
            bool colInRange = col >= 0 && col < arr.GetLength(1);
            return rowInRange && colInRange;
        }

        private static int[,] ReadArray()
        {
            string startPosition = Console.ReadLine();
            char[] separator = new char[] { ' ' };
            string[] startPositions = startPosition.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            startX = int.Parse(startPositions[0]);
            startY = int.Parse(startPositions[1]);

            string dimention = Console.ReadLine();
            string[] dimentions = dimention.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            rows = int.Parse(dimentions[0]);
            cols = int.Parse(dimentions[1]);

            int[,] graph = new int[rows, cols];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                string[] elements = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    string element = elements[j];
                    int elementToInt;
                    if (element.Equals("#"))
                    {
                        elementToInt = -1;
                    }
                    else
                    {
                        elementToInt = int.Parse(element);
                    }

                    graph[i, j] = elementToInt;
                }
            }

            //Console.WriteLine();
            //for (int i = 0; i < graph.GetLength(0); i++)
            //{
            //    for (int j = 0; j < graph.GetLength(1); j++)
            //    {
            //        Console.Write(graph[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            return graph;
        }
    }
}
