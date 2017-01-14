using System.Collections.Generic;

namespace Livraria.Domain.Entities
{
    public class Editora : EntityBase
    {
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }

        public override string ToString()
        {
            return $"{Nome}-#-{Id}";
        }
    }
}