namespace DevilInTheSky
{
    using System;
    using System.Threading;
    using System.Drawing;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    class GameFrame
    {
        public Stopwatch watch = new Stopwatch();
        public TimeSpan elapsedTime = new TimeSpan();

        //Var's for the messages
        int messageTimer = 0;
        int switchMessage = 0;
        string[] messages = new string[10]
            {
                "JUST DIE!",
                "EVIL IS GOOD!",
                "YOU CANNOT WIN!",
                "GIVE UP!",
                "YOU BELONG HERE!",
                "THE END IS NEAR!",
                "YOU ARE WEAK!",
                "JOIN US!",
                "DEATH IS A BLISS!",
                "IN DEATH YOU REST!"
            };

        int life = 5;
        string score = "Score";

        public void PrintOnScreen(int x, int y, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        public void PrintFrame()    // CHANGES IN THE FRAME SIZE 
        {
            for (int i = 0; i < Console.BufferHeight - 4; i++)// The frame around the play field
            {
                PrintOnScreen(0, i, "░", ConsoleColor.DarkGray);
                PrintOnScreen(Console.WindowWidth - 30, i, "░", ConsoleColor.DarkGray);
            }
            PrintOnScreen(0, 0, new string('░', Console.WindowWidth - 30), ConsoleColor.DarkGray);
            PrintOnScreen(0, Console.BufferHeight - 5, new string('░', Console.WindowWidth - 30), ConsoleColor.DarkGray);

            for (int i = 0; i < Console.BufferHeight - 4; i++)      // The frame around the side menu
            {
                PrintOnScreen(111, i, "█ █", ConsoleColor.DarkRed);
                PrintOnScreen(137, i, "█ █", ConsoleColor.DarkRed);

            }

            for (int i = 0; i <= 30; i += 10)       //The first lines in the side menu
            {
                PrintOnScreen(111, i, new string('█', 29), ConsoleColor.DarkRed);
            }

            PrintOnScreen(111, 60, new string('█', 29), ConsoleColor.DarkRed); //The last two lines of the menu
            PrintOnScreen(111, Console.BufferHeight - 5, new string('█', 29), ConsoleColor.DarkRed);
        }

        public void UpdateData(int scoree, int lifee)                               
        {
            this.life = lifee;
            this.score = scoree.ToString();
            //Elapsed game time 
            watch.Start();
            elapsedTime = watch.Elapsed;
            string displayTime = elapsedTime.ToString("mm\\:ss\\.ff");
            PrintOnScreen(122, 5, displayTime, ConsoleColor.Red);//The elapsed time
            PrintOnScreen(122, 15, "score:" + score, ConsoleColor.Red);// Score
            PrintOnScreen(124, 25, "\x0003 " + life.ToString(), ConsoleColor.Red);// Health
            string currentTime = DateTime.Now.ToString("hh:mm");//Displays current time

            // This prints the messages with a delay
            messageTimer = messageTimer + 1;
            if (messageTimer == 100 || messageTimer == 200 || messageTimer == 300 || messageTimer == 400 || messageTimer == 500 || messageTimer == 600 || messageTimer == 700 || messageTimer == 800 || messageTimer == 900)
            {
                switchMessage += 1;
                if (messageTimer == 1000)
                {
                    switchMessage = 0;
                }
            }
            PrintOnScreen(118, 45, messages[switchMessage], ConsoleColor.Red);
            PrintOnScreen(123, 62, currentTime, ConsoleColor.Red);
        }
    }
}
