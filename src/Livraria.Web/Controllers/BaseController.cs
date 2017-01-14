using Livraria.Domain.Excecoes;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected JsonResult RetornarMensagem(string mensagem, MensagemTipo tipo, long? idEntidade = null, string redirect = null, string callback = null)
        {
            string id = string.Empty;
            if (idEntidade.HasValue)
                id = idEntidade.Value.ToString();

            var retorno = new
            {
                id = id,
                sucesso = tipo == MensagemTipo.Sucesso ? true : false,
                tipo = tipo.ToString(),
                mensagem = mensagem,
                redirect = !string.IsNullOrEmpty(redirect),
                urlRedirect = !string.IsNullOrWhiteSpace(redirect) ? redirect : string.Empty,
                callBack = !string.IsNullOrWhiteSpace(callback) ? callback : string.Empty,
            };

            var json = new JsonResult();
            json.Data = retorno;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        protected JsonResult RetornarMensagem(long? idEntidade = null, string redirect = null, string callback = null)
        {
            return this.RetornarMensagem(ResMensagem.MsgSucesso, MensagemTipo.Sucesso, idEntidade, redirect, callback);
        }

        protected JsonResult RetornarMensagem(BusinessException ex, int? idEntidade = null, string redirect = null, string callback = null)
        {
            return this.RetornarMensagem(ex.Message, ex.Tipo, idEntidade, redirect, callback);
        }
    }
}