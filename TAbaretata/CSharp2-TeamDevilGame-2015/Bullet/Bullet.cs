using System;
using System.Drawing;
namespace DevilInTheSky
{
    class Bullet
    {
        public int direction = 0; // move direction (0-up,1-down,2-right,3-left,4-up right,5-up left,6-down right,7-down left
        public ConsoleColor color = new ConsoleColor();
        public Point position = new Point(0, 0);

        public Bullet(Point position,ConsoleColor color,int direction)
        {
            this.position = position;
            this.color = color;
            this.direction = direction;
        }

       public void moveBullet()
        {
           
            switch (direction)
            {
                case 0:
                    {
                        position.Y-=3;
                        break;
                    }
                case 1:
                    {
                        position.Y+=3;
                        break;
                    }
                case 2:
                    {
                        position.X += 5;
                        break;
                    }
                case 3:
                    {
                        position.X -= 5;
                        break;
                    }
                case 4:
                    {
                        position.Y-=3;
                        position.X+=3;
                        break;
                    }
                case 5:
                    {
                        position.Y-=3;
                        position.X-=3;
                        break;
                    }
                case 6:
                    {
                        position.Y+=3;
                        position.X+=3;
                        break;
                    }
                case 7:
                    {
                        position.Y+=3;
                        position.X-=3;
                        break;
                    }
            }

        }
        public void printBulet()
       {
           Console.SetCursorPosition(position.X, position.Y);
           Console.ForegroundColor=color;
           Console.Write("#");
       }
    }
}
