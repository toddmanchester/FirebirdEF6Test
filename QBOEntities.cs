using FirebirdEF6Test.Model;
using FirebirdSql.Data.FirebirdClient;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace FirebirdEF6Test
{
    public class QBOEntities : DbContext
    {
        public QBOEntities()
            : base(new FbConnection(@"database=C:\Data\test.fdb;user=sysdba;password=masterkey;dialect=3"), true)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<QBOEntities>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ACCOUNT>().HasKey(a => new { a.ID });
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
        public virtual DbSet<ACCOUNT> ACCOUNTS { get; set; }
    }
}