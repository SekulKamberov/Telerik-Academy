namespace _02.StudentsAndWorkers
{
    public class Worker : Human
    {
        private static int weekWorkingDays = 5;
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WorkHourPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public double WorkHourPerDay
        {
            get 
            {
                return this.workHoursPerDay; 
            }

            set 
            {
                this.workHoursPerDay = value; 
            }
        }
        
        public double WeekSalary
        {
            get 
            { 
                return this.weekSalary; 
            }

            set 
            { 
                this.weekSalary = value; 
            }
        }

        public double MoneyPerHour()
        {
            double moneyPerHour = this.weekSalary / this.workHoursPerDay / weekWorkingDays;
            return moneyPerHour;
        }
    }
}
