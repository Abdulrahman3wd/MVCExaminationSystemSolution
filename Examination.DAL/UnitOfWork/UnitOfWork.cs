using Examination.DAL.Data;
using Examination.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposedValue;

        private readonly ApplicationDbContext _context = null!;
        public UnitOfWork( ApplicationDbContext context)
        {
            _context = context;
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

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            return repo;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
