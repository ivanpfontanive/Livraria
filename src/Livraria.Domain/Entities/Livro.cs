namespace Livraria.Domain.Entities
{
    public class Livro : EntityBase
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int Paginas { get; set; }

        public int Estoque { get; set; }

        public int Ano { get; set; }

        public long GeneroId { get; set; }

        public virtual Genero Genero { get; set; }

        public long AutorId { get; set; }

        public virtual Autor Autor { get; set; }

        public long EditoraId { get; set; }

        public virtual Editora Editora { get; set; }

        public override string ToString()
        {
            return $"{Nome}-#-{Id}";
        }
    }
}