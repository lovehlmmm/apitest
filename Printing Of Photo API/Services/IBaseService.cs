using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Services
{
    public interface IBaseService<TObject> where TObject:class
    {
        Task<TObject> GetAsync(long id);
        Task<IEnumerable<TObject>> GetAllAsync(int num,int page);
        Task<TObject> FindAsync(Expression<Func<TObject, bool>> match);
        Task<IEnumerable<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match); 
        Task<TObject> AddAsync(TObject t);
        Task<TObject> UpdateAsync(TObject updated, long key);
        Task<IEnumerable<TObject>> AddAllAsync(IEnumerable<TObject> tList);
        Task<int> DeleteAsync(TObject t);
    }
}
