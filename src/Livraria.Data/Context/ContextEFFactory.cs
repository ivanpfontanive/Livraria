using System;

namespace Livraria.Data.Context
{
    public class ContextEFFactory : IContextEF, IDisposable
    {
        public ContextoEF Contexto { get; private set; }

        public ContextEFFactory()
        {
            this.Contexto = new ContextoEF();
        }

        public void Dispose()
        {
            if (this.Contexto != null)
            {
                this.Contexto.Dispose();
                this.Contexto = null;
            }
        }
    }
}