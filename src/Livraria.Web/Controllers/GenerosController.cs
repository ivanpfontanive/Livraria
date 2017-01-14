using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces.Services;
using Livraria.Ioc;
using Livraria.Web.Models.Generos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    [Authorize]
    public class GenerosController : BaseController
    {
        private const string _form = "_Form";
        private const string _list = "_List";

        private IGeneroBo GeneroBo { get; set; }

        public GenerosController()
        {
            GeneroBo = WindsorIoc.Resolve<IGeneroBo>();
        }

        // GET: Autores
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> List()
        {
            var entidades = await GeneroBo.ProjetarTodosAsync<GeneroVm>();
            return View(_list, entidades);
        }

        // GET: Autores/Create
        public ActionResult Create()
        {
            return View(_form, new GeneroVm());
        }

        // POST: Autores/Create
        [HttpPost]
        public ActionResult Create(GeneroVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_form, vm);
                }
                var entidade = Mapper.Map<Genero>(vm);

                GeneroBo.Adicionar(entidade);

                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(_form, vm);
            }
        }

        // GET: Autores/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(_form, await GeneroBo.ProjetarPorIdAsync<GeneroVm>(id));
        }

        // POST: Autores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(GeneroVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_form, vm);
                }
                var entidade = await GeneroBo.FiltrarPorIdAsync(vm.Id);
                Mapper.Map(vm, entidade);

                GeneroBo.Atualizar(entidade);

                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(_form, vm);
            }
        }

        // GET: Autores/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var entidade = await GeneroBo.FiltrarPorIdAsync(id);
                GeneroBo.Deletar(entidade);
                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                return RetornarMensagem(ex);
            }
        }
    }
}