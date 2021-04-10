namespace _12.QueensBacktracking
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int boardSize = 8;
            var board = new QueenBoard(boardSize);
            var chessBoard = new QueenBoardFast(boardSize);
            Console.WriteLine(chessBoard.CountBoardSolutions());
            Console.WriteLine(board.FindQueensSolutions());
            var counter = 1000;
            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < counter; i++)
            {
                board.FindQueensSolutions();
            }

            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            for (int i = 0; i < counter; i++)
            {
                chessBoard.CountBoardSolutions();
            }

            Console.WriteLine(watch.Elapsed);
        }
    }
}
