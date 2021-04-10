namespace _03.InvalidRangeException
{
    using System;
    using System.Globalization;

    public class Program
    {
        private const string DateFormat = "d.M.yyyy";

        public static void Main()
        {
            int start = 1;
            int end = 100;
            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);

            try
            {
                int number = ReadInteger(start, end);
                Console.WriteLine("Your number: " + number);
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("{0}\nRange: [{1}...{2}]", ex.Message, ex.Start, ex.End);
            }

            try
            {
                DateTime date = ReadDate(startDate, endDate);
                Console.WriteLine("Your date: " + date.ToString(DateFormat));
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("{0}\nRange: [{1} - {2}]", ex.Message, ex.Start.ToString(DateFormat), ex.End.ToString(DateFormat));
            }
        }

        private static int ReadInteger(int start, int end)
        {
            int number;
            string inputValue;

            do
            {
                Console.Write("Enter an integer in the range [{0}...{1}]: ", start, end);
                inputValue = Console.ReadLine();
            }
            while (!int.TryParse(inputValue, out number));

            if (number < start || end < number)
            {
                throw new InvalidRangeException<int>("Input value was not in the permissible range.", start, end);
            }

            return number;
        }

        private static DateTime ReadDate(DateTime start, DateTime end)
        {
            DateTime date;
            string inputValue;

            do
            {
                Console.Write("Enter a date in the range [{0} - {1}]: ", start.ToString(DateFormat), end.ToString(DateFormat));
                inputValue = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(inputValue, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date));

            if (date < start || end < date)
            {
                throw new InvalidRangeException<DateTime>("Input value was not in the permissible range.", start, end);
            }

            return date;
        }
    }
}
