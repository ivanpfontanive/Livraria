using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Web.Models.Autores;
using Livraria.Web.Models.Editoras;
using Livraria.Web.Models.Generos;
using Livraria.Web.Models.Livros;

namespace Livraria.Web.Helpers.AutoMapperConf
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ShouldMapProperty = propertyInfo => true;

            CreateMap<Autor, AutorVm>();
            CreateMap<Genero, GeneroVm>();
            CreateMap<Editora, EditoraVm>();
            CreateMap<Livro, LivroVm>()
                .ForMember(x => x.Generos, x => x.Ignore())
                .ForMember(x => x.Editoras, x => x.Ignore())
                .ForMember(x => x.Autores, x => x.Ignore());
        }
    }
}