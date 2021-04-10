namespace SpecificationPattern.Specifications
{
    using SpecificationPattern.Specifications.Base;

    public class StudentFacultySpecification : ISpecification<Student>
    {
        public StudentFacultySpecification(FacultyName faculty)
        {
            this.Faculty = faculty;
        }

        public FacultyName Faculty { get; set; }

        public bool IsSatisfiedBy(Student student)
        {
            return student.Faculty == this.Faculty;
        }
    }
}
