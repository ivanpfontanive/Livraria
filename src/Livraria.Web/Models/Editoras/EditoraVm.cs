using Livraria.Web.App_GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.Models.Editoras
{
    public class EditoraVm : BaseVm
    {
        [Required]
        [Display(Name = "lblNome", ResourceType = typeof(ResLabel))]
        public string Nome { get; set; }
    }
}