using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Core.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Category>> ListAllAsync()
        {
            return await _applicationDbContext.Set<Category>().AsNoTracking().ToListAsync();
            throw new NotImplementedException();
        }
        public async Task<Category> SingleCategoryAsync(string name)
        {
            return await _applicationDbContext.Set<Category>().AsNoTracking().Include(x=>x.Products).SingleOrDefaultAsync(x => x.CategoryName == name);
        }
        public async Task<List<Category>> ListAllAsync(int parentID)
        {
            return await _applicationDbContext.Set<Category>().AsNoTracking().Where(x => x.ParentId == parentID).ToListAsync();
           
        }

    }
}
