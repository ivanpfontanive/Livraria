using System.Collections.Generic;

namespace Livraria.Domain.Entities
{
    public class Genero : EntityBase
    {
        public string Descricao { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }

        public override string ToString()
        {
            return $"{Descricao}-#-{Id}";
        }
    }
}