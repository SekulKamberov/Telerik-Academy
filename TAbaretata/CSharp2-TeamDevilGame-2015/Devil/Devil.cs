using System;
using System.Drawing;
namespace DevilInTheSky
{
    class Devil
    {

     
         static public char[,] turnUp = new char[8, 8] {{' ','.','(',')','(',')','.',' '},
                                                        {'.','.','.','o','o','.','.','.'},
                                                        {'.','.','*','^','^','*','.','.'},
                                                        {'.','*','.','*','*','.','*','.'},
                                                        {'.','.',' ','#','#',' ','.','.'},
                                                        {'.',' ',' ','#','#',' ',' ','.'},
                                                        {' ',' ','*',' ',' ','*',' ',' '},
                                                        {' ',' ','*',' ',' ','*',' ',' '}};

        static public char[,] turnUpRight = new char[8, 8]{{' ',' ',' ',' ',' ',' ','o','>'},
                                                    {' ',' ',' ',' ',' ',' ','o','>'},
                                                    {' ',' ',' ','*',' ','*','.',' '},
                                                    {' ',' ',' ',' ','*','.','.','.'},
                                                    {' ',' ',' ','#','*','.','.',' '},
                                                    {'*','*','#','#',' ','*','.',' '},
                                                    {' ',' ','#',' ','.','.',' ',' '},
                                                    {' ','*','*',' ',' ',' ',' ',' '},
                                                    };
        public char[,] imageDevil = turnUp; 
        public Point teleportStartPoint = new Point(1, 1); // devil teleporting point when the  frame is touched
        public Point position = new Point(30, 20);// Start position for the devil
        public ConsoleColor color = ConsoleColor.Red; // Devil in  red color 
        public int direction = 0; // move direction (0-up,1-down,2-right,3-left,4-up right,5-up left,6-down right,7-down left
        public int speed = 1;

        public Devil(Point startPosition,int speed, int direction)// defined constructor for Devil class
        {
            position = startPosition;
            this.speed= speed;
            this.direction = direction;
        }

        public void moveDevil(int nextPosoka)//increment od decrement x,y cordinates  with speed coeficient 
        {
            if (direction != nextPosoka)
            {
                imageDevil = getImage(nextPosoka); // get the right image 
            }
            switch (nextPosoka)
            {
                case 0:
                    {
                        position.Y-=speed;
                        break;
                    }
                case 1:
                    {
                        position.Y+=speed;
                        break;
                    }
                case 2:
                    {
                        position.X+=speed;
                        break;
                    }
                case 3:
                    {
                        position.X-=speed;
                        break;
                    }
                case 4:
                    {
                        position.Y-=speed;
                        position.X+=speed;
                        break;
                    }
                case 5:
                    {
                        position.Y-=speed;
                        position.X-=speed;
                        break;
                    }
                case 6:
                    {
                        position.Y+=speed;
                        position.X+=speed;
                        break;
                    }
                case 7:
                    {
                        position.Y+=speed;
                        position.X-=speed;
                        break;
                    }
            }

        }

        public char[,] getImage(int posoka)// function that rotate turnUp or turnUpRight matrix and return the right image for the devil that depend from direction.

        {
            switch (posoka)
            {
                case 0:
                    {
                        direction = 0;
                        return turnUp;
                        
                    }
                case 4:
                    {
                        direction = 4;
                        return turnUpRight;
                        

                    }
                case 1:
                    {
                        char[,] pom = new char[8, 8];
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                pom[7 - i, j] = turnUp[i, j];
                            }
                        direction = 1;
                        return pom;


                    }
                case 2:
                    {

                        char[,] pom = new char[8, 8];

                        for (int i = 0; i< 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                pom[j, 7-i] = turnUp[i, j];
                            }
                        direction = 2;
                        return pom;

                    }
                case 3:
                    {

                        char[,] pom = new char[8, 8];

                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                pom[j, i] = turnUp[i, j];
                            }
                        direction = 3;
                        return pom;

                    }
                case 5:
                    {

                        char[,] pom = new char[8, 8];

                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                pom[7-j, i] = turnUpRight[i, j];
                            }
                        direction = 5;
                        return pom;

                    }
                case 6:
                    {
                        char[,] pom = new char[8, 8];
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                pom[7 - i, j] = turnUpRight[i, j];
                            }
                        direction = 6;
                        return pom;

                    }
                case 7:
                    {
                        char[,] pom = new char[8, 8];
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                pom[7 - i, j] = turnUpRight[i, j];
                            }

                        char[,] pom2 = new char[8, 8];


                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                pom2[j, 7 - i] = pom[i, j];
                          }
                        direction = 7;
                        return pom2;

                    }
                default:
                    {
                        return null;
                    }
            }


        } 

    }
}
