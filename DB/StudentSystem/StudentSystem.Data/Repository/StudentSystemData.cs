namespace StudentSystem.Data.Repository
{
    using StudentSystemModel;

    public class StudentSystemData : IStudentSystemData
    {
        private IStudentSystemDbContext context;

        public StudentSystemData() : this (new StudentSystemDbContext())
        {
        }

        public StudentSystemData(IStudentSystemDbContext studentSystemDbContext)
        {
            this.context = studentSystemDbContext;
        }

        public IGenericRepository<Course> Courses
        {
            get
            {
                return new GenericRepository<Course>(this.context);
            }
        }

        public StudentsRepository Students
        {
            get
            {
                return new StudentsRepository(this.context);
            }
        }
    }
}
