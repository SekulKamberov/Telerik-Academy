namespace StudentSystemModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        // if  ovverided 
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;
        private ICollection<Test> tests;
        private ICollection<Student> trainees;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.tests = new HashSet<Test>();
            this.ContactInfo = new StudentContactInfo();
            this.trainees = new HashSet<Student>();
        }

        // OR StudentId... OR Id
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        // allow search by Index
        [Index]
        public int Age { get; set; }

        public virtual Student Assistant { get; set; }

        // Foreign Key To same table (like employee - manager)
        [InverseProperty("Assistant")]
        public virtual ICollection<Student> Trainees
        {
            get
            {
                return this.trainees;
            }
            set
            {
                this.trainees = value;
            }
        }

        public StudentStatus StudentStatus { get; set; }

        public StudentContactInfo ContactInfo { get; set; }

        // virtual => lazy loading, when Courses needed they will get them
        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }

        public virtual ICollection<Test> Tests
        {
            get
            {
                return this.tests;
            }

            set
            {
                this.tests = value;
            }
        }
    }
}
