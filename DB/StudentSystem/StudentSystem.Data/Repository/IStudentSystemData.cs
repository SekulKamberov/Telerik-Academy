namespace StudentSystem.Data.Repository
{
    using StudentSystemModel;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }

        StudentsRepository Students { get; }
    }
}
