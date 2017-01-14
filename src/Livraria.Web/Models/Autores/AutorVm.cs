using Livraria.Web.App_GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.Models.Autores
{
    public class AutorVm : BaseVm
    {
        [Required]
        [Display(Name = "lblNome", ResourceType = typeof(ResLabel))]
        public string Nome { get; set; }
    }
}