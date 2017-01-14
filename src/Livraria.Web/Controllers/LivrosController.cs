using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces.Services;
using Livraria.Ioc;
using Livraria.Web.Models.Livros;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    [Authorize]
    public class LivrosController : BaseController
    {
        private const string _form = "_Form";
        private const string _list = "_List";

        private ILivroBo LivroBo { get; set; }
        private IGeneroBo GeneroBo { get; set; }
        private IEditoraBo EditoraBo { get; set; }
        private IAutorBo AutorBo { get; set; }

        public LivrosController()
        {
            LivroBo = WindsorIoc.Resolve<ILivroBo>();
            GeneroBo = WindsorIoc.Resolve<IGeneroBo>();
            EditoraBo = WindsorIoc.Resolve<IEditoraBo>();
            AutorBo = WindsorIoc.Resolve<IAutorBo>();
        }

        // GET: Autores
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> List()
        {
            var entidades = await LivroBo.ProjetarTodosAsync<LivroVm>();
            return View(_list, entidades.OrderBy(x => x.Nome));
        }

        // GET: Autores/Create
        public ActionResult Create()
        {
            var vm = new LivroVm();
            InicializarForm(vm);
            return View(_form, vm);
        }

        // POST: Autores/Create
        [HttpPost]
        public ActionResult Create(LivroVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    InicializarForm(vm);
                    return View(_form, vm);
                }
                var entidade = Mapper.Map<Livro>(vm);

                LivroBo.Adicionar(entidade);

                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError("", ex.Message);
                InicializarForm(vm);
                return View(_form, vm);
            }
        }

        // GET: Autores/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var vm = await LivroBo.ProjetarPorIdAsync<LivroVm>(id);
            InicializarForm(vm);
            return View(_form, vm);
        }

        // POST: Autores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(LivroVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    InicializarForm(vm);
                    return View(_form, vm);
                }
                var entidade = await LivroBo.FiltrarPorIdAsync(vm.Id);
                Mapper.Map(vm, entidade);

                LivroBo.Atualizar(entidade);

                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError("", ex.Message);
                InicializarForm(vm);
                return View(_form, vm);
            }
        }

        // GET: Autores/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var entidade = await LivroBo.FiltrarPorIdAsync(id);
                LivroBo.Deletar(entidade);
                return RetornarMensagem();
            }
            catch (BusinessException ex)
            {
                return RetornarMensagem(ex);
            }
        }

        private void InicializarForm(LivroVm vm)
        {
            vm.Editoras = EditoraBo.FiltrarTodos().Select(x => new SelectListItem() { Text = x.Nome, Value = x.Id.ToString(), Selected = vm.EditoraId == x.Id });
            vm.Generos = GeneroBo.FiltrarTodos().Select(x => new SelectListItem() { Text = x.Descricao, Value = x.Id.ToString(), Selected = vm.GeneroId == x.Id });
            vm.Autores = AutorBo.FiltrarTodos().Select(x => new SelectListItem() { Text = x.Nome, Value = x.Id.ToString(), Selected = vm.AutorId == x.Id });
        }
    }
}