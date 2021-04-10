using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentSystemModel
{
    public class TeacherCourse
    {
        [Key, Column(Order = 0)]
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        [Key, Column(Order = 1)]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
