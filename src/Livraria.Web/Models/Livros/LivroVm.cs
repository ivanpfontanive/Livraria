using Livraria.Web.App_GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Livraria.Web.Models.Livros
{
    public class LivroVm : BaseVm
    {
        [Required]
        [Display(Name = "lblNome", ResourceType = typeof(ResLabel))]
        public string Nome { get; set; }

        [Required]
        public decimal? Valor { get; set; }

        [Required]
        public int? Paginas { get; set; }

        [Required]
        public int? Estoque { get; set; }

        [Required]
        public int? Ano { get; set; }

        [Required]
        public long GeneroId { get; set; }

        [Required]
        public long AutorId { get; set; }

        [Required]
        public long EditoraId { get; set; }

        public string GeneroDescricao { get; set; }

        public string EditoraNome { get; set; }

        public string AutorNome { get; set; }

        public IEnumerable<SelectListItem> Editoras { get; set; }
        public IEnumerable<SelectListItem> Generos { get; set; }
        public IEnumerable<SelectListItem> Autores { get; set; }
    }
}