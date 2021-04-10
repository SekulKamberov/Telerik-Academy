namespace EnitityFrameworkHW
{
    using System.Data.Entity;

    public partial class NorthwindEntities : DbContext
    {
        public NorthwindEntities(string connectionString)
            :base(connectionString)
        {
        }
    }
}
