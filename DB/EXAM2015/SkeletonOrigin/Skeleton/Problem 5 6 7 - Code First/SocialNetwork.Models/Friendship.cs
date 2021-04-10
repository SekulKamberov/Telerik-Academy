namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        private ICollection<Message> message;

        public Friendship()
        {
            this.message = new HashSet<Message>();
        }

        public int Id { get; set; }

        public int FirstUserId { get; set; }

        [ForeignKey("FirstUserId")]
        public virtual User FirstUser { get; set; }

        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual User SecondUser { get; set; }

        [Index]
        public bool IsApproved { get; set; }

        public DateTime WhenIsApproved { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }
    }
}
