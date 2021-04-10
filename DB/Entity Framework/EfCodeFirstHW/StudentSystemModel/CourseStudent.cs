namespace StudentSystemModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CourseStudent
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Key, Column(Order = 1)]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}