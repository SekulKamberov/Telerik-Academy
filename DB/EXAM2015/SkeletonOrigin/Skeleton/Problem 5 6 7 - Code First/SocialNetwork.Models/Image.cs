namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(4)]
        [Required]
        public string FileExtension { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
