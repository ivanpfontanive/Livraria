using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces.Services;
using Livraria.Ioc;
using Livraria.Web.Models.Editoras;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    [Authorize]
    public class EditorasController : BaseController
    {
        private const string _form = "_Form";
        private const string _list = "_List";

        private IEditoraBo EditoraBo { get; set; }

        public EditorasController()
        {
            EditoraBo = WindsorIoc.Resolve<IEditoraBo>();
        }

        // GET: Autores
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> List()
        {
            var entidades = await EditoraBo.ProjetarTodosAsync<EditoraVm>();
            return View(_list, entidades);
        }

        // GET: Autores/Create
        public ActionResult Create()
        {
            return View(_form, new EditoraVm());
        }

        // POST: Autores/Create
        [HttpPost]
        public ActionResult Create(EditoraVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_form, vm);
                }
                var entidade = Mapper.Map<Editora>(vm);

                EditoraBo.Adicionar(entidade);

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
            return View(_form, await EditoraBo.ProjetarPorIdAsync<EditoraVm>(id));
        }

        // POST: Autores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EditoraVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_form, vm);
                }
                var entidade = await EditoraBo.FiltrarPorIdAsync(vm.Id);
                Mapper.Map(vm, entidade);

                EditoraBo.Atualizar(entidade);

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
                var entidade = await EditoraBo.FiltrarPorIdAsync(id);
                EditoraBo.Deletar(entidade);
                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                return RetornarMensagem(ex);
            }
        }
    }
}