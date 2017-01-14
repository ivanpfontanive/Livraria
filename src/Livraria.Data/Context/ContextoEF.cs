using Livraria.Data.Mappings;
using Livraria.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace Livraria.Data.Context
{
    public class ContextoEF : DbContext
    {
        public ContextoEF() : base("ConnectionString")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<ContextoEF>(new CreateDatabaseIfNotExists<ContextoEF>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            var mappings = Assembly.GetAssembly(typeof(LivroMap));
            modelBuilder.Configurations.AddFromAssembly(mappings);

            modelBuilder.Types<EntityBase>().Configure(p =>
            {
                p.HasKey(q => q.Id);
                p.Property(q => q.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}