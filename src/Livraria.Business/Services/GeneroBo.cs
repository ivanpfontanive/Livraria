using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Interfaces.Services;
using System.Linq;

namespace Livraria.Business.Services
{
    public class GeneroBo : BusinessBase<Genero>, IGeneroBo
    {
        public GeneroBo(IRepositorio repositorio)
        {
            this.Repositorio = repositorio;
        }

        public override void ValidarAdicao(Genero entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.Descricao))
            {
                throw new BusinessException(string.Format(ResMensagem.MsgCampoObrigatorio, nameof(entidade.Descricao)), MensagemTipo.Alerta);
            }
            if (this.FiltrarTodos(x => x.Descricao == entidade.Descricao).Any())
            {
                throw new BusinessException(string.Format(ResMensagem.MsgRegistroJaExiste, entidade.Descricao), MensagemTipo.Alerta);
            }
        }

        public override void ValidarAtualizacao(Genero entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.Descricao))
            {
                throw new BusinessException(string.Format(ResMensagem.MsgCampoObrigatorio, nameof(entidade.Descricao)), MensagemTipo.Alerta);
            }
            if (this.FiltrarTodos(x => x.Descricao == entidade.Descricao && x.Id != entidade.Id).Any())
            {
                throw new BusinessException(string.Format(ResMensagem.MsgRegistroJaExiste, entidade.Descricao), MensagemTipo.Alerta);
            }
        }

        public override void ValidarDelecao(Genero entidade)
        {
            if (entidade.Livros.Any())
            {
                throw new BusinessException(ResMensagem.MsgRegistroPossuiDependencias, MensagemTipo.Alerta);
            }
        }
    }
}