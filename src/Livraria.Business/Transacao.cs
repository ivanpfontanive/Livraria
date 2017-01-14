using System;
using System.Configuration;
using System.Transactions;

namespace Livraria.Business
{
    /// <summary>
    /// Fabrica de escopos de transações.
    /// </summary>
    public class Transacao
    {
        /// <summary>
        /// Retorna um escopo de transação requerido, ele fara parte do escopo pai.
        /// </summary>
        /// <returns>TransactionScope requerido.</returns>
        public static TransactionScope ObterEscopo()
        {
            return Transacao.ObterEscopo(TransactionScopeOption.Required, Convert.ToInt32(ConfigurationManager.AppSettings["timeout_transacao"]));
        }

        /// <summary>
        /// Retorna um novo escopo de transação, ele é uma transação nova e independente.
        /// </summary>
        /// <returns>TransactionScope novo.</returns>
        public static TransactionScope ObterEscopoNovo()
        {
            return Transacao.ObterEscopo(TransactionScopeOption.RequiresNew, Convert.ToInt32(ConfigurationManager.AppSettings["timeout_transacao"]));
        }

        /// <summary>
        /// Define que o bloco dentro deste escopo de transação não participa de nenhuma transação.
        /// </summary>
        /// <returns>TransactionScope Suprimido.</returns>
        public static TransactionScope ObterEscopoSuprimido()
        {
            return Transacao.ObterEscopo(TransactionScopeOption.Suppress, Convert.ToInt32(ConfigurationManager.AppSettings["timeout_transacao"]));
        }

        /// <summary>
        /// Cria escopos de transações.
        /// </summary>
        /// <param name="scopeOption">TransactionScopeOption</param>
        /// <param name="timeOut">int</param>
        /// <returns>TransactionScope</returns>
        public static TransactionScope ObterEscopo(TransactionScopeOption scopeOption, int timeOut)
        {
            return new TransactionScope(scopeOption, TimeSpan.FromSeconds(timeOut), TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}