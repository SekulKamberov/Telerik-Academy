namespace _01.CreateStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestMatrixClass
    {
        public static void Main()
        {
            double[,] first = { { 0, 2, 3, 4.2 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            double[,] second = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 0, 3, 4 } };
            Matrix<double> arrFirst = new Matrix<double>(first);
            Matrix<double> arrSecond = new Matrix<double>(second);
            if (arrFirst)
            {
                Console.WriteLine("There is no zero inside");
            }
            else
            {
                Console.WriteLine("There is at least one zero inside\n");
            }

            Console.WriteLine("Sum of the two matrices");
            Console.WriteLine(arrFirst + arrSecond);
            Console.WriteLine("Substraction of the two matrices");
            Console.WriteLine(arrFirst - arrSecond);
            Console.WriteLine("Multiplication of the two matrices");
            Console.WriteLine(arrFirst * arrSecond);
        }
    }
}