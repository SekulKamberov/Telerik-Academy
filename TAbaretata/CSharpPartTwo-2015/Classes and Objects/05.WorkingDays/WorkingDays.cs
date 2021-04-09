using System;

/*  Write a method that calculates the number of workdays between today and given date, passed as parameter.
Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified
preliminary as array.   */

class WorkingDays
{
    static void Main()
    {
        try
        {
            Console.Write("Enter date YYYY/MM/DD: ");
            string[] endDateStr = Console.ReadLine().Split('/');
            int endDay = int.Parse(endDateStr[2]);
            int endMonth = int.Parse(endDateStr[1]);
            int endYear = int.Parse(endDateStr[0]);

            DateTime today = DateTime.Today;
            DateTime endDate = new DateTime(endYear, endMonth, endDay);
            int timeLength = 0;
            timeLength = Math.Abs((endDate - today).Days);
            if (today > endDate)
            {
                today = endDate;
                endDate = DateTime.Today;
            }

            //Some holidays implemented
            DateTime[] holidays = { new DateTime(2015, 01, 01), new DateTime(2015, 03, 03), new DateTime(2015, 05, 24),
                                new DateTime(2015, 09, 06),new DateTime(2015, 09, 22), new DateTime(2015, 11, 01)};

            int workingDays = 0;
            bool isHoliday = false;
            for (int i = 0; i < timeLength; i++)
            {
                today = today.AddDays(1);
                if (today.DayOfWeek != DayOfWeek.Saturday || today.DayOfWeek != DayOfWeek.Sunday)
                {
                    for (int j = 0; j < holidays.Length; j++)
                    {
                        if (today == holidays[j])
                        {
                            isHoliday = true;
                            break;
                        }
                    }
                    if (!isHoliday)
                    {
                        workingDays++;
                    }
                    isHoliday = false;
                }
            }
            Console.WriteLine("There are {0} working days until the date you entered.", workingDays);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}