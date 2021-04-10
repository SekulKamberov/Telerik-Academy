namespace UniversitySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        private const int StudentNameMinLength = 2;
        private const int StudentNumberLength = 6;
        private const int StudentNameMaxLength = 10;
        private const string StudentNumberErrorMessage = "Student number must have length 6 and contains year (yy), faculty number (01) and personal number (01). Example: 150101";
        private const string StudentNameLengthErrorMessage = "Student Name has minLength of 2 and max 10";
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;
        private ICollection<Student> mentorStudents;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
            this.mentorStudents = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(StudentNameMaxLength, MinimumLength = StudentNameMinLength, ErrorMessage = StudentNameLengthErrorMessage)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [StringLength(StudentNumberLength, MinimumLength = StudentNumberLength, ErrorMessage = StudentNumberErrorMessage)]
        [Index(IsUnique = true)]
        public string Number { get; set; }

        [DefaultValue(Gender.NotSelected)]
        public Gender Gender { get; set; }

        // override OnModelCreating at UniversitySystemDbContext
        public int? MentorId { get; set; }

        [InverseProperty("MentorId")]
        public virtual Student Menthor { get; set; }

        public virtual ICollection<Student> MentorStudents
        {
            get
            {
                return this.mentorStudents;
            }

            set
            {
                this.mentorStudents = value;
            }
        }

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
    }
}
