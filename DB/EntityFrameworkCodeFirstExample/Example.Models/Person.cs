namespace Example.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        private ICollection<Store> stores;
        private ICollection<Kid> childs;
        private ICollection<Kid> parents;

        public Person()
        {
            this.stores = new HashSet<Store>();
            this.childs = new HashSet<Kid>();
            this.parents = new HashSet<Kid>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsMale { get; set; }

        public int? MotherId { get; set; }

        public virtual Person Mother { get; set; }

        public int? FatherId { get; set; }

        public virtual Person Father { get; set; }

        public virtual ICollection<Store> Stores
        {
            get
            {
                return this.stores;
            }

            set
            {
                this.stores = value;
            }
        }

        public virtual ICollection<Kid> Childs
        {
            get
            {
                return this.childs;
            }

            set
            {
                this.childs = value;
            }
        }

        public virtual ICollection<Kid> Parents
        {
            get
            {
                return this.parents;
            }

            set
            {
                this.parents = value;
            }
        }
    }
}
