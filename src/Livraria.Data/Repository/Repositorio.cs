using AutoMapper.QueryableExtensions;
using Livraria.Data.Context;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Livraria.Data.Repository
{
    public class Repositorio : IRepositorio
    {
        private ContextoEF Contexto { get; set; }

        public Repositorio(IContextEF context)
        {
            this.Contexto = context.Contexto;
        }

        public void Adicionar<T>(T entidade) where T : EntityBase
        {
            try
            {
                this.Contexto.Set<T>().Add(entidade);
                this.Contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message, ex);
                }
                else
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public void Atualizar<T>(T entidade) where T : EntityBase
        {
            try
            {
                this.Contexto.Entry(entidade).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message, ex);
                }
                else
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public void Deletar<T>(IList<T> entidades) where T : EntityBase
        {
            try
            {
                for (int i = 0; i < entidades.Count(); i++)
                {
                    this.Contexto.Entry(entidades[i]).State = EntityState.Deleted;
                    this.Contexto.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message, ex);
                }
                else
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public void Deletar<T>(T entidade) where T : EntityBase
        {
            try
            {
                this.Contexto.Entry(entidade).State = EntityState.Deleted;
                this.Contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message, ex);
                }
                else
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public T FiltrarPorId<T>(long id) where T : EntityBase
        {
            return Contexto.Set<T>().Find(id);
        }

        public IQueryable<T> FiltrarTodos<T>() where T : EntityBase
        {
            return this.Contexto.Set<T>();
        }

        public IQueryable<T> FiltrarTodos<T>(Expression<Func<T, bool>> expressao) where T : EntityBase
        {
            return this.Contexto.Set<T>().Where(expressao);
        }

        public async Task<T> FiltrarPorIdAsync<T>(long id) where T : EntityBase
        {
            return await Contexto.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> FiltrarTodosAsync<T>() where T : EntityBase
        {
            return await this.Contexto.Set<T>().ToListAsync();
        }

        public async Task<List<T>> FiltrarTodosAsync<T>(Expression<Func<T, bool>> expressao) where T : EntityBase
        {
            return await this.Contexto.Set<T>().Where(expressao).ToListAsync();
        }

        public async Task<TDest> ProjetarPorIdAsync<T, TDest>(long id) where T : EntityBase
        {
            return await this.Contexto.Set<T>().Where(x => x.Id == id).ProjectTo<TDest>().FirstOrDefaultAsync();
        }

        public async Task<List<TDest>> ProjetarTodosAsync<T, TDest>() where T : EntityBase
        {
            return await this.Contexto.Set<T>().ProjectTo<TDest>().ToListAsync();
        }

        public async Task<List<TDest>> ProjetarTodosAsync<T, TDest>(Expression<Func<T, bool>> expressao) where T : EntityBase
        {
            return await this.Contexto.Set<T>().Where(expressao).ProjectTo<TDest>().ToListAsync();
        }
    }
}