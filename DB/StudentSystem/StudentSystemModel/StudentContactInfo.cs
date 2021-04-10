namespace StudentSystemModel
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class StudentContactInfo
    {
        [Column("E-mail")]
        public string Email { get; set; }

        [Column("Facebook account")]
        public string Facebook { get; set; }

        [Column("Skype account")]
        public string Skype { get; set; }
    }
}
