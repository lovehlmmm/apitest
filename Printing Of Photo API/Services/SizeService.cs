using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Models;
using PagedList;
using Repositories;

namespace Services
{

    public class SizeService : IBaseService<Size>
    {
        private readonly IBaseRepository<Size> _baseRepository;

        public SizeService(IBaseRepository<Size> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Task<IEnumerable<Size>> AddAllAsync(IEnumerable<Size> tList)
        {
            throw new NotImplementedException();
        }

        public async Task<Size> AddAsync(Size t)
        {
            return await _baseRepository.AddAsync(t);
        }

        public async Task<int> DeleteAsync(Size t)
        {
            
            t.Status = SizeStatus.Deleted;
            var result = await _baseRepository.UpdateAsync(t, t.SizeId);
            if (result.Status==SizeStatus.Deleted)
            {
                return await Task.Run<int>(() => 1);
            }
            return await Task.Run<int>(() => 0); 
        }

        public Task<IEnumerable<Size>> FindAllAsync(Expression<Func<Size, bool>> match)
        {
            throw new NotImplementedException();
        }

        public async Task<Size> FindAsync(Expression<Func<Size, bool>> match)
        {
            return await _baseRepository.FindAsync(match);
        }

        public async Task<IEnumerable<Size>> GetAllAsync(int num,int page)
        {
            return await _baseRepository.GetAllAsync(num,page,size =>size.SizeId,size => !size.Status.Equals(SizeStatus.Deleted));
        }

        public Task<Size> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Size> UpdateAsync(Size updated, long key)
        {
            return await _baseRepository.UpdateAsync(updated, key);
        }
    }
}
