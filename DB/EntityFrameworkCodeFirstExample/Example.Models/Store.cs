namespace Example.Models
{
    public class Store
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public virtual Person Owner { get; set; }
    }
}
