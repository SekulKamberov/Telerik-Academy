namespace SpecificationPattern.Specifications
{
    using System.Linq;
    using SpecificationPattern.Specifications.Base;

    public class ExcellentStudentSpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student studend)
        {
            if (studend.Grades.Count == 0)
            {
                return false;
            }

            if (studend.Grades.Contains(2))
            {
                return false;
            }

            bool isExcellentStudent = studend.Grades.Sum() / studend.Grades.Count() >= 5.5;

            return isExcellentStudent;
        }
    }
}
