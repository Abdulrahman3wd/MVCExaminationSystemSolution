using Examination.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<T> GenericRepository<T>() where T : class;
        void SaveChanges();
    }
}
