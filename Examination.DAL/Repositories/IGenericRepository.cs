using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.Repositories
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null!,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
            string IncludeProperties = "");
        
    }
}
