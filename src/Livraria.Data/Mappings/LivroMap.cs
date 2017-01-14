using Livraria.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Data.Mappings
{
    internal class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            this.ToTable("Livro");

            this.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            this.Property(x => x.Valor).IsRequired().HasPrecision(16, 2);

            this.HasRequired(x => x.Autor)
                .WithMany(x => x.Livros)
                .HasForeignKey(x => x.AutorId);

            this.HasRequired(x => x.Genero)
                .WithMany(x => x.Livros)
                .HasForeignKey(x => x.GeneroId);

            this.HasRequired(x => x.Editora)
                .WithMany(x => x.Livros)
                .HasForeignKey(x => x.EditoraId);
        }
    }
}