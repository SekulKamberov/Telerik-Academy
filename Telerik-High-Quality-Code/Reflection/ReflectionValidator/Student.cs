namespace ReflectionValidator
{
    using System.Collections.Generic;
    using ObjectStateValidator.Annotations;

    public class Student
    {
        [Mandatory]
        public string FirstName { get; set; }

        [Mandatory]
        public string LastName { get; set; }

        [Range(18, 50)]
        public int Age { get; set; }

        [Elements(10, MinCount = 2)]
        public ICollection<int> Marks { get; set; }

        public Student Mentor { get; set; }
    }
}
