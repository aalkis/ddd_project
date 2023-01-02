using Be_bitirme.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketByIdAsync(int id);
        Task UpdateBasketAsync(Basket basket);
        Task<Basket> GetBasketByGIdAsync(Guid gid);
        Task CreateBasket(Basket basket);
        Task AddBasketItemAsync(BasketItem basketItem);
        Task UpdateBasketItemAsync(BasketItem basketitem);
        Task RemoveBasketItem(BasketItem basketItem);
        Task<BasketItem> CheckBasketItemByBasketId(int BasketItemId);
        Task<BasketItem> FindBasketItem(int basketId, int productId);
    }
}
