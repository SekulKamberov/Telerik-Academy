namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        public int Id { get; set; }

        public int FriendshipId { get; set; }

        [ForeignKey("FriendshipId")]
        public virtual Friendship Friendship { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime DateTimeSent { get; set; }

        public DateTime DateTimeRead { get; set; }
    }
}
