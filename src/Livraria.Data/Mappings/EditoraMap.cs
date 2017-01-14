using Livraria.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Data.Mappings
{
    internal class EditoraMap : EntityTypeConfiguration<Editora>
    {
        public EditoraMap()
        {
            this.ToTable("Editora");

            this.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        }
    }
}