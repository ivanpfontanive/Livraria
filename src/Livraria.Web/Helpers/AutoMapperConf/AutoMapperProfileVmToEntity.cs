using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Web.Models.Autores;
using Livraria.Web.Models.Editoras;
using Livraria.Web.Models.Generos;
using Livraria.Web.Models.Livros;

namespace Livraria.Web.Helpers.AutoMapperConf
{
    public class AutoMapperProfileVmToEntity : Profile
    {
        public AutoMapperProfileVmToEntity()
        {
            ShouldMapProperty = propertyInfo => true;

            CreateMap<AutorVm, Autor>().ForMember(x => x.Livros, x => x.Ignore());
            CreateMap<EditoraVm, Editora>().ForMember(x => x.Livros, x => x.Ignore());
            CreateMap<GeneroVm, Genero>().ForMember(x => x.Livros, x => x.Ignore());
            CreateMap<LivroVm, Livro>()
                .ForMember(x => x.Genero, x => x.Ignore())
                .ForMember(x => x.Editora, x => x.Ignore())
                .ForMember(x => x.Autor, x => x.Ignore());
        }
    }
}