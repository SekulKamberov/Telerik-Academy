namespace VariablesExpressionsConstants
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var width = 10;
            var height = 20;
            var size = new Size(width, height);
            Console.WriteLine("Old Width: " + width);
            Console.WriteLine("Old Height: " + height);
            size.Rotate(130);
            Console.WriteLine("New Width: " + size.Width);
            Console.WriteLine("New Height: " + size.Height);
        }

        public void PrintStatistics(double[] numbers, int maxIndex)
        {
            double max = double.MinValue;
            for (int i = 0; i < maxIndex; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            PrintMax(max);

            double min = max;
            for (int i = 0; i < maxIndex; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            PrintMin(min);

            double sum = 0;
            for (int i = 0; i < maxIndex; i++)
            {
                sum += numbers[i];
            }

            double average = sum / maxIndex;
            PrintAvg(average);
        }

        private void PrintAvg(double value)
        {
            throw new NotImplementedException();
        }

        private void PrintMin(double value)
        {
            throw new NotImplementedException();
        }

        private void PrintMax(double value)
        {
            throw new NotImplementedException();
        }
    }
}
