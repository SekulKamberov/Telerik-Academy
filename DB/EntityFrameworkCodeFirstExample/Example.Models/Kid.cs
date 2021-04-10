namespace Example.Models
{
    public class Kid
    {
        public int ParentId { get; set; }

        public virtual Person Parent { get; set; }

        public int ChildId { get; set; }

        public virtual Person Child { get; set; }
    }
}
