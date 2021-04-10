namespace UniversitySystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        private const int ContentMinLength = 5;
        private const int ContentMaxLength = 1000;

        public Homework()
        {
            this.TimeSent = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ContentMinLength)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
