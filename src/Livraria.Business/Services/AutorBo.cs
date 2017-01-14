using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Interfaces.Services;
using System.Linq;

namespace Livraria.Business.Services
{
    public class AutorBo : BusinessBase<Autor>, IAutorBo
    {
        public AutorBo(IRepositorio repositorio)
        {
            this.Repositorio = repositorio;
        }

        public override void ValidarAdicao(Autor entidade)
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

        public override void ValidarAtualizacao(Autor entidade)
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

        public override void ValidarDelecao(Autor entidade)
        {
            if (entidade.Livros.Any())
            {
                throw new BusinessException(ResMensagem.MsgRegistroPossuiDependencias, MensagemTipo.Alerta);
            }
        }
    }
}