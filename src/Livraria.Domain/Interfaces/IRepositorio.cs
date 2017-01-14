using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface IRepositorio
    {
        void Adicionar<T>(T entidade) where T : EntityBase;

        void Atualizar<T>(T entidade) where T : EntityBase;

        void Deletar<T>(T entidade) where T : EntityBase;

        void Deletar<T>(IList<T> entidades) where T : EntityBase;

        T FiltrarPorId<T>(long id) where T : EntityBase;

        Task<T> FiltrarPorIdAsync<T>(long id) where T : EntityBase;

        IQueryable<T> FiltrarTodos<T>() where T : EntityBase;

        IQueryable<T> FiltrarTodos<T>(Expression<Func<T, bool>> expressao) where T : EntityBase;

        Task<List<T>> FiltrarTodosAsync<T>() where T : EntityBase;

        Task<List<T>> FiltrarTodosAsync<T>(Expression<Func<T, bool>> expressao) where T : EntityBase;

        Task<TDest> ProjetarPorIdAsync<T, TDest>(long id) where T : EntityBase;

        Task<List<TDest>> ProjetarTodosAsync<T, TDest>() where T : EntityBase;

        Task<List<TDest>> ProjetarTodosAsync<T, TDest>(Expression<Func<T, bool>> expressao) where T : EntityBase;
    }
}