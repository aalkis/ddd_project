using Be_bitirme.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> ListAllAsync();
        Task<Category> SingleCategoryAsync(string name);
    }
}
