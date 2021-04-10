namespace StudentSystem.Data.Repository
{
    using System.Linq;

    using StudentSystemModel;

    public class StudentsRepository:GenericRepository<Student>, IGenericRepository<Student>
    {
        public StudentsRepository(IStudentSystemDbContext context): base(context)
        {

        }
        public IQueryable<Student> AllAssistants()
        {
            return this.Search(s => s.Trainees.Count() > 0);
        }
    }
}
