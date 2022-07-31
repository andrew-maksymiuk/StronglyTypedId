using Microsoft.EntityFrameworkCore;

namespace StronglyTypedId
{
    public partial class TestEntities : EntityContext
    {
        public TestEntities()
            : base("Data Source=DEV01\\DEV_SQL_01;Initial Catalog=Test;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")
        {
        }
        
        public virtual DbSet<TestTable> TestTable { get; set; }
    }
}
