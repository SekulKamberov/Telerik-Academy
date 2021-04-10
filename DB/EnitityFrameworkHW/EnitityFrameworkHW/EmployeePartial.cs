namespace EnitityFrameworkHW
{
    using System.Collections.Generic;

    public partial class Employee
    {
        public ICollection<Territory> TerritoriesProp
        {
            get
            {
                return this.Territories;
            }
        }
    }
}
