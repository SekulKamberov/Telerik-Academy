namespace UniversitySystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        private const int CourseNameMinLength = 2;
        private const int CourseNameMaxLength = 100;
        private const string CourseNameLengthErrorMessage = "Course name min length is 2 and max is 100.";
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;
        private ICollection<Course> childCourses;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
            this.childCourses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CourseNameMaxLength, MinimumLength = CourseNameMinLength, ErrorMessage = CourseNameLengthErrorMessage)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Materials { get; set; }

        // Aternative SelfReference
        public int? PriorCourseId { get; set; }

        [InverseProperty("ChildCourses")]
        public virtual Course PriorCourse { get; set; }

        public virtual ICollection<Course> ChildCourses
        {
            get
            {
                return this.childCourses;
            }

            set
            {
                this.childCourses = value;
            }
        }

        public virtual ICollection<Student> Students 
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
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
