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
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> SingleProductAsync(int id)
        {
            return await _context.Set<Product>().AsNoTracking().SingleOrDefaultAsync(x => x.ProductID == id);
        }
        public async Task<Product> SingleProductByUrl(string smarturl)
        {
            return await _context.Set<Product>().AsNoTracking().SingleOrDefaultAsync(x => x.SmartUrl == smarturl);
        }
    }
}
