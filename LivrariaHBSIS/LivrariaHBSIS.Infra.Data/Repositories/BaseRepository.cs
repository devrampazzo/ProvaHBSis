using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Domain.Interfaces.Repositories;
using LivrariaHBSIS.Infra.Data.Configuration;
using LivrariaHBSIS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaHBSIS.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly ContextoAplicacao _context;

        public BaseRepository(ContextoAplicacao context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            TEntity obj = GetById(id);
            Delete(obj);
        }

        public void Delete(TEntity obj) =>
            _context.Set<TEntity>().Remove(obj);

        public IQueryable<TEntity> GetAll() =>
            _context.Set<TEntity>();

        public TEntity GetById(int id) =>
            _context.Set<TEntity>().Find(id);

        public void Insert(TEntity obj) =>
            _context.Set<TEntity>().Add(obj);

        public void Update(TEntity obj) =>
            _context.Entry(obj).State = EntityState.Modified;
    }
}
