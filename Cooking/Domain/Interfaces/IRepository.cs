namespace Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void AddAsync(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task<T> FindAsync(Expression<Func<T, bool>> expression);

        IQueryable<T> FindAll(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression);

        public Task<T> Update(T entity);
    }
}
