namespace StudentSystemModel
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public DateTime Deadline { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        [ForeignKey("Student")]
        public int StudentIdentification { get; set; }

        public virtual Student Student { get; set; }
    }
}
