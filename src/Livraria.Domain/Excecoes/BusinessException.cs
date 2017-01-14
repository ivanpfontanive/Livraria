using System;

namespace Livraria.Domain.Excecoes
{
    public enum MensagemTipo : int
    {
        Informacao = 0,
        Alerta = 1,
        Erro = 2,
        Sucesso = 3
    }

    public class BusinessException : Exception
    {
        public MensagemTipo Tipo { get; private set; }

        public new string Message { get; private set; }

        public BusinessException(string message, MensagemTipo tipo)
            : base(message)
        {
            this.Message = message;
            this.Tipo = tipo;
        }

        public BusinessException(string message, MensagemTipo tipo, Exception ex)
            : base(message, ex)
        {
            this.Message = message;
            this.Tipo = tipo;
        }
    }
}