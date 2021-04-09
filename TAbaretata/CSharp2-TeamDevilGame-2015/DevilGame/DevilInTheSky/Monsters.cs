namespace DevilInTheSky
{
    using System;
    using System.Drawing;

    class Monsters
    {
        public char[,] radius1 = {  
                                    {'O','O'}, 
                                    {'(',')'},
                                 };

        public char[,] radius2 = {  
                                    {' ','^','^',' '},
                                    {'#','O','O','#'},
                                    {' ','<','>',' '},
                                    {'#',' ',' ','#'},
                                 };

        public char[,] radius3 = {  
                                    {' ','*',' ',' ','*',' '},
                                    {'*',' ','^','^',' ','*'},
                                    {' ',' ','x','X',' ',' '},
                                    {' ','*','_','_','*',' '},
                                    {'*',' ','*','*',' ','*'},
                                    {' ','*',' ',' ','*',' '},
                                 };


        public ConsoleColor color = ConsoleColor.Blue;
        public int radius = 0;// 1 or 2 or 3 
        public int direction = 0;// 1-down,2-down right,3-down left,4-up,5-up right,6-up left,7-right,8-right up,9-right down,10-left,11-left up,12-left down
        public Point currentPoint = new Point(0, 0);
        public int speed = 1;
        public Point startPoint = new Point(0, 0);
        static public Random randomSide = new Random();

        public Monsters(ConsoleColor clr, int radius, int frameHeight, int frameWidth, int speed)
        {
            this.speed = speed;
            color = clr;
            this.radius = radius;
            int side = randomSide.Next(1, 5);//1-top,2-bottom,3-right,4-left (side that asteroid will comming from)

            switch (side)
            {
                case 1:
                    {
                        currentPoint.Y = startPoint.Y = 1;
                        currentPoint.X = startPoint.X = randomSide.Next(0, frameWidth - (2 * radius) + 1);
                        direction = new Random().Next(1, 4);
                        break;
                    }
                case 2:
                    {
                        currentPoint.Y = startPoint.Y = frameHeight - (2 * radius);
                        currentPoint.X = startPoint.X = randomSide.Next(0, frameWidth - (2 * radius) + 1);
                        direction = new Random().Next(4, 7);
                        break;
                    }
                case 3:
                    {
                        currentPoint.Y = startPoint.Y = randomSide.Next(0, frameHeight - (2 * radius) + 1);
                        currentPoint.X = startPoint.X = frameWidth - (2 * radius);
                        direction = new Random().Next(10, 13);
                        break;
                    }
                case 4:
                    {
                        currentPoint.Y = startPoint.Y = randomSide.Next(0, frameHeight - (2 * radius) + 1);
                        currentPoint.X = startPoint.X = 1;
                        direction = new Random().Next(7, 10);
                        break;
                    }
            }
        }

        public void moveMonster()
        {
            switch (direction)
            {
                case 1:
                    {
                        currentPoint.Y += speed;
                        break;
                    }
                case 2:
                    {
                        currentPoint.Y += speed;
                        currentPoint.X += speed;
                        break;
                    }
                case 3:
                    {
                        currentPoint.Y += speed;
                        currentPoint.X -= speed;
                        break;
                    }
                case 4:
                    {
                        currentPoint.Y -= speed;
                        break;
                    }
                case 5:
                    {
                        currentPoint.X += speed;
                        currentPoint.Y -= speed;
                        break;
                    }
                case 6:
                    {
                        currentPoint.X -= speed;
                        currentPoint.Y -= speed;
                        break;

                    }
                case 7:
                    {
                        currentPoint.X += speed;
                        break;
                    }
                case 8:
                    {
                        currentPoint.X += speed;
                        currentPoint.Y -= speed;
                        break;
                    }
                case 9:
                    {
                        currentPoint.X += speed;
                        currentPoint.Y += speed;
                        break;
                    }
                case 10:
                    {
                        currentPoint.X -= speed;
                        break;
                    }
                case 11:
                    {
                        currentPoint.X -= speed;
                        currentPoint.Y -= speed;
                        break;
                    }
                case 12:
                    {
                        currentPoint.X -= speed;
                        currentPoint.Y += speed;
                        break;
                    }
            }
        }

        public void printMonster()
        {
            string l = "";

            for (int i = 0; i < 2 * radius; i++)
            {
                for (int j = 0; j < (2 * radius); j++)
                {
                    if (radius == 1)
                    {
                        l += radius1[i, j];
                    }
                    else if (radius == 2)
                    {
                        l += radius2[i, j];
                    }
                    else if (radius == 3)
                    {
                        l += radius3[i, j];
                    }
                }

                Console.SetCursorPosition(currentPoint.X, currentPoint.Y + i);
                Console.ForegroundColor = color;
                Console.Write(l);
                l = "";
            }
        }
    }
}
