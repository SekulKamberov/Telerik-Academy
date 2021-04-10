namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Tag> tags;
        private ICollection<Image> images;
        private ICollection<Message> message;

        public User()
        {
            this.tags = new HashSet<Tag>();
            this.images = new HashSet<Image>();
            this.message = new HashSet<Message>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(20, MinimumLength = 4)]
        public string UserName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags;
            }

            set
            {
                this.tags = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

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
