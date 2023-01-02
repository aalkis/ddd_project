using Be_bitirme.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> SingleProductAsync(int id);
        Task<Product> SingleProductByUrl(string name);
    }
}
