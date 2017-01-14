using Livraria.Web.App_GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.Models.Generos
{
    public class GeneroVm : BaseVm
    {
        [Required]
        [Display(Name = "lblDescricao", ResourceType = typeof(ResLabel))]
        public string Descricao { get; set; }
    }
}