using Be_bitirme.Application.Dto;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Core.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ApplicationDbContext _context;

        public BasketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Basket> GetBasketByIdAsync(int id)
        {
            var res =await _context.Set<Basket>().AsNoTracking().Include(x => x.BasketItems).SingleOrDefaultAsync(x => x.UserId == id);
            return res;
        }
        public async Task<Basket> GetBasketByGIdAsync(Guid gid)
        {
          
           var res = await _context.Set<Basket>().AsNoTracking().Include(x => x.BasketItems).SingleOrDefaultAsync(x => x.GuestId == gid);
           return res;
           
        }
        public async Task UpdateBasketAsync(Basket basket)
        {
            _context.Set<Basket>().Update(basket);
            await _context.SaveChangesAsync();
        }
        public async Task CreateBasket(Basket basket)
        {
            _context.Set<Basket>().AddAsync(basket);
            await _context.SaveChangesAsync();
        }
        public async Task<BasketItem> CheckBasketItemByBasketId(int BasketItemId)
        {   
            var res = await _context.Set<BasketItem>().AsNoTracking().SingleOrDefaultAsync(x => x.BasketItemId == BasketItemId);
            return res;
        }
        public async Task<BasketItem> FindBasketItem(int basketId, int productId)
        {
            var res = await _context.Set<BasketItem>().AsNoTracking().SingleOrDefaultAsync(x => x.BasketId == basketId && x.ProductId == productId);
            return res;
        }

        public async Task AddBasketItemAsync(BasketItem basketItem)
        {
            await _context.Set<BasketItem>().AddAsync(basketItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBasketItemAsync(BasketItem basketitem)
        {
            _context.Set<BasketItem>().Update(basketitem);
            await _context.SaveChangesAsync();  
        }

        public async Task RemoveBasketItem(BasketItem basketItem)
        {
            _context.Set<BasketItem>().Remove(basketItem);
            await _context.SaveChangesAsync();
        }
    }
}
 