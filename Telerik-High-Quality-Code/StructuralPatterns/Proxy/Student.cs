namespace Proxy
{
    using System;

    public class Student : IStudent
    {
        public Student(string name)
        {
            this.Name = name;
            this.Status = StudentStatus.Freshmen;
            this.Credits = 0;
        }

        public string Name { get; set; }

        public StudentStatus Status { get; set; }

        public int Credits { get; set; }

        public bool ProgressFromYearToYear()
        {
            if (this.Status == StudentStatus.Freshmen)
            {
                this.Status = StudentStatus.Sophomore;
                return true;
            }
            else if (this.Status == StudentStatus.Sophomore)
            {
                this.Status = StudentStatus.Junior;
                return true;
            }
            else if (this.Status == StudentStatus.Junior)
            {
                this.Status = StudentStatus.Senior;
                return true;
            }

            return false;
        }

        public int StudentCredits()
        {
            return this.Credits;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Status: {1}, Credits: {2}", this.Name, this.Status, this.Credits);
        }

        public void Add(IStudent student)
        {
            Console.WriteLine("Student cannot represent another student.");
        }

        public void Remove(IStudent student)
        {
            Console.WriteLine("Student cannot represent another student.");
        }

        public virtual void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);
        }

        public void TakeExam()
        {
            // if exam is taken
            this.Credits += 3;
        }
    }
}
