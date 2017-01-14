using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface IBusiness<T> where T : EntityBase
    {
        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Deletar(T entidade);

        void Deletar(IList<T> entidades);

        T FiltrarPorId(long id);

        Task<T> FiltrarPorIdAsync(long id);

        IQueryable<T> FiltrarTodos();

        IQueryable<T> FiltrarTodos(Expression<Func<T, bool>> expressao);

        Task<List<T>> FiltrarTodosAsync();

        Task<List<T>> FiltrarTodosAsync(Expression<Func<T, bool>> expressao);

        Task<TDest> ProjetarPorIdAsync<TDest>(long id);

        Task<List<TDest>> ProjetarTodosAsync<TDest>();

        Task<List<TDest>> ProjetarTodosAsync<TDest>(Expression<Func<T, bool>> expressao);

        void ValidarAdicao(T entidade);

        void ValidarAtualizacao(T entidade);

        void ValidarDelecao(T entidade);
    }
}