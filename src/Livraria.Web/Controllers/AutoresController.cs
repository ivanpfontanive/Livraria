using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces.Services;
using Livraria.Ioc;
using Livraria.Web.Models.Autores;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    [Authorize]
    public class AutoresController : BaseController
    {
        private const string _form = "_Form";
        private const string _list = "_List";

        private IAutorBo AutorBo { get; set; }

        public AutoresController()
        {
            AutorBo = WindsorIoc.Resolve<IAutorBo>();
        }

        // GET: Autores
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> List()
        {
            var entidades = await AutorBo.ProjetarTodosAsync<AutorVm>();
            return View(_list, entidades);
        }

        // GET: Autores/Create
        public ActionResult Create()
        {
            return View(_form, new AutorVm());
        }

        // POST: Autores/Create
        [HttpPost]
        public ActionResult Create(AutorVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_form, vm);
                }
                var entidade = Mapper.Map<Autor>(vm);

                AutorBo.Adicionar(entidade);

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
            return View(_form, await AutorBo.ProjetarPorIdAsync<AutorVm>(id));
        }

        // POST: Autores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(AutorVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_form, vm);
                }
                var entidade = await AutorBo.FiltrarPorIdAsync(vm.Id);
                Mapper.Map(vm, entidade);

                AutorBo.Atualizar(entidade);

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
                var entidade = await AutorBo.FiltrarPorIdAsync(id);
                AutorBo.Deletar(entidade);
                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                return RetornarMensagem(ex);
            }
        }
    }
}