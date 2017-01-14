using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Livraria.Business
{
    public enum OperacaoTipo : int
    {
        Nenhum = 0,
        Adicao = 1,
        Atualizacao = 2,
        Delecao = 3,
    }

    public abstract class BusinessBase<T> : IBusiness<T> where T : EntityBase
    {
        protected IRepositorio Repositorio { get; set; }

        public virtual T FiltrarPorId(long id)
        {
            return this.Repositorio.FiltrarPorId<T>(id);
        }

        public virtual async Task<T> FiltrarPorIdAsync(long id)
        {
            return await this.Repositorio.FiltrarPorIdAsync<T>(id);
        }

        public virtual IQueryable<T> FiltrarTodos()
        {
            return this.Repositorio.FiltrarTodos<T>();
        }

        public virtual IQueryable<T> FiltrarTodos(Expression<Func<T, bool>> expressao)
        {
            return this.Repositorio.FiltrarTodos<T>(expressao);
        }

        public virtual async Task<List<T>> FiltrarTodosAsync()
        {
            return await this.Repositorio.FiltrarTodosAsync<T>();
        }

        public virtual async Task<List<T>> FiltrarTodosAsync(Expression<Func<T, bool>> expressao)
        {
            return await this.Repositorio.FiltrarTodosAsync<T>(expressao);
        }

        public virtual async Task<TDest> ProjetarPorIdAsync<TDest>(long id)
        {
            return await this.Repositorio.ProjetarPorIdAsync<T, TDest>(id);
        }

        public virtual async Task<List<TDest>> ProjetarTodosAsync<TDest>()
        {
            return await this.Repositorio.ProjetarTodosAsync<T, TDest>();
        }

        public virtual async Task<List<TDest>> ProjetarTodosAsync<TDest>(Expression<Func<T, bool>> expressao)
        {
            return await this.Repositorio.ProjetarTodosAsync<T, TDest>(expressao);
        }

        public virtual void Adicionar(T entidade)
        {
            using (var escopo = Transacao.ObterEscopo())
            {
                this.Validar(entidade, OperacaoTipo.Adicao);

                this.Repositorio.Adicionar<T>(entidade);
                escopo.Complete();
            }
        }

        public virtual void Atualizar(T entidade)
        {
            using (var escopo = Transacao.ObterEscopo())
            {
                this.Validar(entidade, OperacaoTipo.Atualizacao);

                this.Repositorio.Atualizar<T>(entidade);
                escopo.Complete();
            }
        }

        public virtual void Deletar(T entidade)
        {
            using (var escopo = Transacao.ObterEscopo())
            {
                this.Validar(entidade, OperacaoTipo.Delecao);

                this.Repositorio.Deletar<T>(entidade);
                escopo.Complete();
            }
        }

        public virtual void Deletar(IList<T> entidades)
        {
            using (var escopo = Transacao.ObterEscopo())
            {
                foreach (var entidade in entidades)
                {
                    this.Validar(entidade, OperacaoTipo.Delecao);
                }

                this.Repositorio.Deletar<T>(entidades);
                escopo.Complete();
            }
        }

        private void Validar(T entidade, OperacaoTipo operacao)
        {
            switch (operacao)
            {
                case OperacaoTipo.Adicao:
                    this.ValidarAdicao(entidade);
                    break;

                case OperacaoTipo.Atualizacao:
                    this.ValidarAtualizacao(entidade);
                    break;

                case OperacaoTipo.Delecao:
                    this.ValidarDelecao(entidade);
                    break;
            }
        }

        public abstract void ValidarAdicao(T entidade);

        public abstract void ValidarAtualizacao(T entidade);

        public abstract void ValidarDelecao(T entidade);
    }
}