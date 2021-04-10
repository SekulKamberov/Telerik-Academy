﻿namespace AsynchronousPrograming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            Parallel.For(
                0, 
                20, 
                index => 
                {
                    if (index % 2 == 0)
                    {
                        Console.WriteLine(index);
                    }
                });
        }
    }
}
