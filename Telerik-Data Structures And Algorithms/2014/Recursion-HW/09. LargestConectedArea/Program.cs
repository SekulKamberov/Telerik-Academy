#define DEBUG_MODE

using System;
using System.Collections.Generic;

class AllPathsInLabyrinth
{

    /*
     *  09. Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
     */
    static int counter = 0;
    static int largestConnerctedAreaCount = 0;
    static string[,] lab = 
    {
        {" ", " ", " ", "*", " ", " ", " "},
        {"*", "*", " ", "*", " ", "*", " "},
        {" ", " ", "*", " ", " ", " ", " "},
        {" ", "*", "*", "*", "*", "*", " "},
        {" ", " ", " ", "*", " ", " ", " "},
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

        IsLargestConectedArea();

        if (lab[row, col] == " " )
        {
            // Temporary mark the current cell as visited
            lab[row, col] = counter.ToString();
            counter++;

            // Recursively explore all possible directions
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down
        }
    }

    static void IsLargestConectedArea()
    {
        if(counter > largestConnerctedAreaCount)
        {
            largestConnerctedAreaCount = counter;
        }
    }

    static void Main()
    {
        for (int row = 0; row < lab.GetLength(0); row++)
        {
            for (int col = 0; col < lab.GetLength(1); col++)
            {
                // start indexes
                if(lab[row, col] == " ")
                {
                    FindPathToExit(row, col);
                    counter = 0;
                }
            }
        }
        Console.WriteLine("Largest connected area: " + largestConnerctedAreaCount);
    }
}
