namespace _01.Students
{
    public class Student
    {
        public Student(string firstName, string lastName, string courseName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CourseName = courseName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CourseName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t|{1}\t|{2}", this.CourseName, this.FirstName, this.LastName);
        }
    }
}
