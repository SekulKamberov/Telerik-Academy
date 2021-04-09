namespace DevilInTheSky
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Media;

    class StartScreen
    {
        public SoundPlayer startScreen = new SoundPlayer(@"..\..\Scary_Demon_Haunting.wav");

        public void PlaySound()
        {
            try
            {
                startScreen.PlayLooping();
            }
            catch (Exception)
            {
                Console.WriteLine("Problem with sound file loading!");
            }
        }

        public void StopSound()
        {
            startScreen.Stop();
        }

        public void SetFieldSize()
        {
            Console.BufferHeight = Console.WindowHeight = 78;
            Console.BufferWidth = Console.WindowWidth = 140;
        }

        public void PrintOnPosition(int x, int y, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }

        public bool StartScreenMenu()
        {
            SetFieldSize();

            #region startScreenStrings
            string startScreenTitle = @" 
                            (                                                                            
                             )\ )                  (                  (                    )        (     
                            (()/(     (    )   (   )\      (          )\   (     )      ( /(    (   )\ )  
                             /(_))   ))\  /((  )\ ((_)     )\   (    ((_) ))\ ( /(  (   )\())  ))\ (()/(  
                            (_))_   /((_)(_))\((_) _    _ ((_)  )\ )  _  /((_))(_)) )\ ((_)\  /((_) ((_)) 
                             |   \ (_))  _)((_)(_)| |  | | | | _(_/( | |(_)) ((_)_ ((_)| |(_)(_))   _| |  
                             | |) |/ -_) \ V / | || |  | |_| || ' \))| |/ -_)/ _` |(_-<| ' \ / -_)/ _` |  
                             |___/ \___|  \_/  |_||_|   \___/ |_||_| |_|\___|\__,_|/__/|_||_|\___|\__,_|  
                                                                                              ";
            string startScreenTitleWithSparks = @"
                             ( *                    *                  *                  *          *         
                             )\ )         *        (                  (         *          )        (     
                            (()/(     (    )   (   )\      (     *    )\   (     )      ( /(    (   )\ )  
                             /(_))   ))\  /((  )\ ((_)     )\   (    ((_) ))\ ( /(  (   )\())  ))\ (()/(  
                            (_))_   /((_)(_))\((_) _    _ ((_)  )\ )  _  /((_))(_)) )\ ((_)\  /((_) ((_)) 
                             |   \ (_))  _)((_)(_)| |  | | | | _(_/( | |(_)) ((_)_ ((_)| |(_)(_))   _| |  
                             | |) |/ -_) \ V / | || |  | |_| || ' \))| |/ -_)/ _` |(_-<| ' \ / -_)/ _` |  
                             |___/ \___|  \_/  |_||_|   \___/ |_||_| |_|\___|\__,_|/__/|_||_|\___|\__,_|  ";

            string startScreenDevil = @"            
                                                    L@@@C;          ;tt;          ;C@@@L      
                                                i@@@@@@@@@@@. ,@@@fi..if@@@, .@@@@@@@@@@@i    
                                               8@@@@@@@@@@@@@@ @L ;.  .; L@ @@@@@@@@@@@@@@8   
                                              G@@@@@@@@@@@@0@@@,tL.itti.Lt,@@@0@@@@@@@@@@@@G  
                                             .@@@@@10@@@@@@f.@:@@@,@@@@,@@@:@.f@@@@@@01@@@@@. 
                                             G@@@t,@C:L@@@@C@f,@0:.@88@.:0@,f@C@@@@L:C@,t@@@G 
                                             @@@@i@    .CG..@L@, 0; .. ;0 ,@L@..GC.    @i@@@@ 
                                             @@@t;L      8GiC  .@t:i@@i:t@.  CiG8      L:t@@@ 
                                             @@@,1,       t;i    @i .. i@    i:f       ,1.@@@ 
                                             @@@,@          ,0.   f0;;0f   .0,          @,@@@ 
                                             @@@i@          . @@@ ,@  @, @@@ .          @i@@@ 
                                             i@@@8          0.@GG 88..88 CG@.0          8@@@i 
                                              @@@ @      i   iGG;;t0GG0f;:GGi   i      @ @@@  
                                               @@@ t   ;@    :0it.1.1.1.1t10,    @;   t @@@   
                                                @@@@@@@@f     .iG1.1.1.1@iC     f@@@@@@@@    
                                                  ;8@@C         ,@.t@@t.@,         C@@8;      
                                                                  ;1@@1;                      ";

            #endregion

            PrintOnPosition(0, Console.WindowHeight / 2 - 5, startScreenDevil, ConsoleColor.DarkRed);

            while (true)
            {
                PrintOnPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2, "PRESS ENTER TO START!", ConsoleColor.White);

                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        PrintOnPosition(10, Console.WindowHeight / 2 - 15, startScreenTitle, ConsoleColor.DarkRed);
                    }
                    else
                    {
                        PrintOnPosition(10, Console.WindowHeight / 2 - 15, startScreenTitleWithSparks, ConsoleColor.Red);
                    }
                    Thread.Sleep(500);
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        return true;

                    }
                }
            }
        }
    }
}
