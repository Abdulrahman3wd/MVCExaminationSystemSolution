using Examination.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.Repositories
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private bool disposedValue;
        internal DbSet<T> _dbSet;
        private readonly ApplicationDbContext _context = null!;
        public GenericRepository( ApplicationDbContext context)
        {
            _dbSet = _context.Set<T>();
            _context = context;
            
        }

        public void Add(T entity)
        {
             _dbSet.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
          await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }

        public async Task<T?> DeleteAsync(T entityToDelete)
        {
           
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
            return entityToDelete;

        }

        public void DeleteById(object id)
        {
          T? entityToDelete = _dbSet.Find(id);
            if (entityToDelete is not null)
                Delete(entityToDelete);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null!,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
            string IncludeProperties = "")
        {
           IQueryable<T> query = _dbSet;
            if (filter is not null)         
                query = query.Where(filter);
            foreach (var includeProperty in IncludeProperties.Split(new char[] {','} , StringSplitOptions.RemoveEmptyEntries))            
                query = query.Include(includeProperty);
            
            if (orderBy is not null)
                return orderBy(query).ToList();

            else
                return query.ToList();


        }

        public T? GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
          return  await _dbSet.FindAsync(id) ;
        }

        public void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State= EntityState.Modified;
        }

        public async Task<T> UpdateAsync(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }


                disposedValue = true;
            }
        }



        public void Dispose()
        {
         
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
