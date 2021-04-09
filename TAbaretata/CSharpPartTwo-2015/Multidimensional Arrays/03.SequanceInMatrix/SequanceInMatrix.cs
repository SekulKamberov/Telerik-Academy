using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//We are given a matrix of strings of size N x M. Sequences in the matrix we define
//as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.

class SequanceInMatrix
{
    static void Main()
    {
        string[,] matrix = new string[,] { { "ha", "fifi", "ho", "hi" }, 
                                            { "fo", "ha", "hi", "xx" }, 
                                            { "xxx", "ho", "ha", "xx" } };
        int count = 1;
        int maxCount = 1;
        string maxValue = "";
        int direction = 1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)     //Searching horizontally
            {
                if ((matrix[row, col] == matrix[row, col + 1]))
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    maxValue = matrix[row, col];
                    direction = 1;
                }
            }
            count = 1;
        }

        for (int col = 0; col < matrix.GetLength(1); col++)                 //Searching vertically
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if ((matrix[row, col] == matrix[row + 1, col]))
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    maxValue = matrix[row, col];
                    direction = 2;
                }
            }
            count = 1;
        }

        //Searching diagonally from left to right
        for (int row = 0, col = 0; row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1; row++, col++)
        {
            if ((matrix[row, col] == matrix[row + 1, col + 1]))
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxCount)
            {
                maxCount = count;
                maxValue = matrix[row, col];
                direction = 3;
            }
        }
        count = 1;


        //Searching diagonally from right to left
        for (int row = 0, col = 0; row < matrix.GetLength(0) - 1 && col > 0; row++, col--)
        {
            if ((matrix[row, col] == matrix[row + 1, col + 1]))
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxCount)
            {
                maxCount = count;
                maxValue = matrix[row, col];
                direction = 4;
            }
        }
        count = 1;

        switch (direction)
        {
            case 1: Console.WriteLine("Element \"{0}\" repeats {1} times horizontally.", maxValue, maxCount); break;
            case 2: Console.WriteLine("Element \"{0}\" repeats {1} times vertically.", maxValue, maxCount); break;
            case 3: Console.WriteLine("Element \"{0}\" repeats {1} times diagonally from right to left.", maxValue, maxCount); break;
            case 4: Console.WriteLine("Element \"{0}\" repeats {1} times diagonally from left to right.", maxValue, maxCount); break;
            default: Console.WriteLine("No repeats found."); break;
        }
    }
}