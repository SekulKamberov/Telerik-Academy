namespace SpecificationPattern.Specifications
{
    using SpecificationPattern.Specifications.Base;

    public class StudentNameStartsWithSpecification : ISpecification<Student>
    {
        public StudentNameStartsWithSpecification(string substring)
        {
            this.StartSubstring = substring;
        }

        public string StartSubstring { get; set; }

        public bool IsSatisfiedBy(Student student)
        {
            return student.Name.StartsWith(this.StartSubstring);
        }
    }
}
