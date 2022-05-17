namespace Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Domain.Interfaces;
    using Infrastructure.Persistence;

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public async void AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            Context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToArrayAsync();
        }

        public async Task<T> Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
