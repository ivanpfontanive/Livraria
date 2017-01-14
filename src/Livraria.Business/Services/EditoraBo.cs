using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Interfaces.Services;
using System.Linq;

namespace Livraria.Business.Services
{
    public class EditoraBo : BusinessBase<Editora>, IEditoraBo
    {
        public EditoraBo(IRepositorio repositorio)
        {
            this.Repositorio = repositorio;
        }

        public override void ValidarAdicao(Editora entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.Nome))
            {
                throw new BusinessException(string.Format(ResMensagem.MsgCampoObrigatorio, nameof(entidade.Nome)), MensagemTipo.Alerta);
            }
            if (this.FiltrarTodos(x => x.Nome == entidade.Nome).Any())
            {
                throw new BusinessException(string.Format(ResMensagem.MsgRegistroJaExiste, entidade.Nome), MensagemTipo.Alerta);
            }
        }

        public override void ValidarAtualizacao(Editora entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.Nome))
            {
                throw new BusinessException(string.Format(ResMensagem.MsgCampoObrigatorio, nameof(entidade.Nome)), MensagemTipo.Alerta);
            }
            if (this.FiltrarTodos(x => x.Nome == entidade.Nome && x.Id != entidade.Id).Any())
            {
                throw new BusinessException(string.Format(ResMensagem.MsgRegistroJaExiste, entidade.Nome), MensagemTipo.Alerta);
            }
        }

        public override void ValidarDelecao(Editora entidade)
        {
            if (entidade.Livros.Any())
            {
                throw new BusinessException(ResMensagem.MsgRegistroPossuiDependencias, MensagemTipo.Alerta);
            }
        }
    }
}