#define DEBUG_MODE

using System;
using System.Collections.Generic;

class AllPathsInLabyrinth
{

    /*
     * 10. We are given a matrix of passable and non-passable cells. Write a recursive program for finding all areas of passable cells in the matrix.
    */
    static List<string> path = new List<string>();
    static string[,] lab = 
    {
        {"P1",  "P2",   "P3",   "N",    "P11",  "P10",  "P9"},
        {"N",   "N",    "P4",   "N",    "P12",  "N",    "P8"},
        {"P2",  "P1",   "N",    "P14",  "P13",  "P6",   "P7"},
        {"P3",  "N",    "N",    "N",    "N",    "N",    "P4"},
        {"P4",  "P5",   "P6",   "N",    "P1",   "P2",   "P3"},
    };

    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < lab.GetLength(0);
        bool colInRange = col >= 0 && col < lab.GetLength(1);
        return rowInRange && colInRange;
    }

    static void FindPathToExit(int row, int col)
    {
        if (!InRange(row, col))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        if (lab[row, col] != "N" && lab[row, col] != "PASSED")
        {
            path.Add(lab[row, col]);
            lab[row, col] = "PASSED";

            // Recursively explore all possible directions
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down
        }
    }

    static void Main()
    {
        for (int row = 0; row < lab.GetLength(0); row++)
        {
            for (int col = 0; col < lab.GetLength(1); col++)
            {
                // start indexes
                if (lab[row, col] != "N" && lab[row, col] != "PASSED")
                {
                    FindPathToExit(row, col);
                    Console.WriteLine("Path: ");
                    foreach (var item in path)
                    {
                        Console.Write(item);
                    }
                    path.RemoveRange(0, path.Count);
                    Console.WriteLine();
                }
            }
        }
    }
}
