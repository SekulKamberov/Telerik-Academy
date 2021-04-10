namespace Proxy
{
    public abstract class Assistant : Student
    {
        protected Assistant(Student student)
            : base(student.Name)
        {
            this.Student = student;
        }

        protected Student Student { get; private set; }
    }
}
