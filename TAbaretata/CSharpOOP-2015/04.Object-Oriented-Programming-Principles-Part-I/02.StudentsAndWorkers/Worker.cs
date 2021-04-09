namespace _02.StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        public Worker(string fname, string lname, decimal weekSalary, int workDayHours)
            :base(fname, lname)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workDayHours;
        }

        public decimal WeekSalary {get; private set;}

        public int WorkHoursPerDay { get; private set; }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (5m * WorkHoursPerDay);
        }
    }
}
