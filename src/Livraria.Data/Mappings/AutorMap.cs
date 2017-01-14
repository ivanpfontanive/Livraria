using Livraria.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Data.Mappings
{
    internal class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            this.ToTable("Autor");

            this.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        }
    }
}