using System;

//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints 
//the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

class DateInBulgarian
{
    static void Main()
    {
        
        try
        {
            Console.WriteLine("Enter the date in format[Day.Month.Year Hours:Minutes:Seconds]: ");
            string[] inputOne = Console.ReadLine().Split(new char[] { '.', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            int day = int.Parse(inputOne[0]);
            int month = int.Parse(inputOne[1]);
            int year = int.Parse(inputOne[2]);
            int hour = int.Parse(inputOne[3]);
            int minutes = int.Parse(inputOne[4]);
            int seconds = int.Parse(inputOne[5]);

            
            DateTime date = new DateTime(year, month, day, hour, minutes, seconds);
            var culture = new System.Globalization.CultureInfo("bg-BG");
            var dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);

            Console.WriteLine(new string('-', 15));
            Console.WriteLine("Time now: {0}", date);
            Console.WriteLine(dayOfWeek);
            Console.WriteLine(new string('-',15));

            date = date.AddHours(6).AddMinutes(30);
            dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);

            Console.WriteLine("Time after 6 hours and 30 minutes: {0}", date);
            Console.WriteLine(dayOfWeek);
            Console.WriteLine(new string('-', 15));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
