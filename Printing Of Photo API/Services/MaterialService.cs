using Constants;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MaterialService : IBaseService<Material>
    {
        private readonly IBaseRepository<Material> _baseRepository;

        public MaterialService(IBaseRepository<Material> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task<IEnumerable<Material>> AddAllAsync(IEnumerable<Material> tList)
        {
            throw new NotImplementedException();
        }

        public async Task<Material> AddAsync(Material t)
        {
            return await _baseRepository.AddAsync(t);
        }

        public async Task<int> DeleteAsync(Material t)
        {
            t.Status = MaterialStatus.Deleted;
            var result = await _baseRepository.UpdateAsync(t, t.MaterialId);
            if (result.Status == MaterialStatus.Deleted)
            {
                return await Task.Run<int>(() => 1);
            }
            return await Task.Run<int>(() => 0);
        }

        public Task<IEnumerable<Material>> FindAllAsync(Expression<Func<Material, bool>> match)
        {
            throw new NotImplementedException();
        }

        public async Task<Material> FindAsync(Expression<Func<Material, bool>> match)
        {
            return await _baseRepository.FindAsync(match);
        }

        public async Task<IEnumerable<Material>> GetAllAsync(int num, int page)
        {
            return await _baseRepository.GetAllAsync(num, page, material => material.MaterialId, material => !material.Status.Equals(MaterialStatus.Deleted));
        }

        public Task<Material> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Material> UpdateAsync(Material updated, long key)
        {
            return await _baseRepository.UpdateAsync(updated, key);
        }
    }
}
