using Livraria.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Data.Mappings
{
    internal class GeneroMap : EntityTypeConfiguration<Genero>
    {
        public GeneroMap()
        {
            this.ToTable("Genero");

            this.Property(x => x.Descricao).IsRequired().HasMaxLength(200);
        }
    }
}