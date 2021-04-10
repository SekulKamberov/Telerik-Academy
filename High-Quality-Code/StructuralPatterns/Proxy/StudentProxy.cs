namespace Proxy
{
    using System;

    /// <summary>
    /// Proxy Pattern
    /// </summary>
    public class StudentProxy : IStudent
    {
        private Student realStudent;

        public StudentProxy(string name)
        {
            this.realStudent = new Student(name);
        }

        public bool ProgressFromYearToYear()
        {
            if (this.realStudent.Status == StudentStatus.Freshmen && this.realStudent.Credits == 15)
            {
                this.realStudent.Status = StudentStatus.Sophomore;
                return true;
            }
            else if (this.realStudent.Status == StudentStatus.Sophomore && this.realStudent.Credits == 30)
            {
                this.realStudent.Status = StudentStatus.Junior;
                return true;
            }
            else if (this.realStudent.Status == StudentStatus.Junior && this.realStudent.Credits == 45)
            {
                this.realStudent.Status = StudentStatus.Senior;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int StudentCredits()
        {
            if (this.realStudent.Status != StudentStatus.DropOut)
            {
                return this.realStudent.Credits;
            }
            else
            {
                return 0;
            }
        }

        public void Add(IStudent student)
        {
            Console.WriteLine("Student cannot represent another student.");
        }

        public void Remove(IStudent student)
        {
            Console.WriteLine("Student cannot represent another student.");
        }

        public void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.realStudent.Name);
        }

        public void TakeExam()
        {
            // if exam is taken
            this.realStudent.Credits += 3;
        }
    }
}
