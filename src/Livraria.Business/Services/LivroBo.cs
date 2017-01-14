using Livraria.Domain.Entities;
using Livraria.Domain.Excecoes;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Interfaces.Services;
using System.Linq;

namespace Livraria.Business.Services
{
    public class LivroBo : BusinessBase<Livro>, ILivroBo
    {
        public LivroBo(IRepositorio repositorio)
        {
            this.Repositorio = repositorio;
        }

        public override void ValidarAdicao(Livro entidade)
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

        public override void ValidarAtualizacao(Livro entidade)
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

        public override void ValidarDelecao(Livro entidade)
        {
            // throw new NotImplementedException();
        }
    }
}