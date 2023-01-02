using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Handlers
{
    public class MergeBasketRequestHandler : IRequestHandler<MergeBasketRequest>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public MergeBasketRequestHandler(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(MergeBasketRequest request, CancellationToken cancellationToken)
        {
            var GuestBasket = await _basketRepository.GetBasketByGIdAsync((Guid)request.GuestId);
            var UserBasket = await _basketRepository.GetBasketByIdAsync((int)request.UserId);
            if (UserBasket == null && GuestBasket != null)
            {

                GuestBasket.UserId = request.UserId;
                GuestBasket.GuestId = request.GuestId;
                GuestBasket.Deleted_on = null;
                GuestBasket.Created_on = GuestBasket.Created_on;
                //GuestBasket.BasketTotalPrice = GuestBasket.BasketTotalPrice;
                GuestBasket.Updated_on = DateTime.UtcNow;
                
                await _basketRepository.UpdateBasketAsync(GuestBasket);
            }
            else if(UserBasket != null && GuestBasket != null)
            {
                int checkDate = DateTime.Compare((DateTime)UserBasket.Created_on, (DateTime)GuestBasket.Created_on);
                DateTime finalCreationDate;
                if (checkDate < 0)
                {
                   finalCreationDate = (DateTime)UserBasket.Created_on;
                }
                else if (checkDate > 0)
                {
                    finalCreationDate = (DateTime)GuestBasket.Created_on;
                }
                else
                {
                    finalCreationDate = (DateTime)GuestBasket.Created_on;
                }


                UserBasket.UserId = request.UserId;
                UserBasket.GuestId = request.GuestId;
                UserBasket.Deleted_on = null;
                UserBasket.Created_on = finalCreationDate;
                //UserBasket.BasketTotalPrice = GuestBasket.BasketTotalPrice + UserBasket.BasketTotalPrice;
                UserBasket.Updated_on = DateTime.UtcNow;
                ;
                GuestBasket.BasketStatus = false;
                GuestBasket.Deleted_on = DateTime.UtcNow;
                await basketitemchangeMethod(UserBasket.BasketItems, GuestBasket.BasketItems, UserBasket.BasketId);
                await _basketRepository.UpdateBasketAsync(UserBasket);
                await _basketRepository.UpdateBasketAsync(GuestBasket);
            }

            return Unit.Value;
        }
        private async Task basketitemchangeMethod(List<BasketItem> userBasketItems, List<BasketItem> guestBasketItems, int basketId)
        {
            foreach (var item in guestBasketItems)
            {
                for(int i = 0; i < userBasketItems.Count; i++)
                {
                    if (item.ProductId == userBasketItems[i].ProductId)
                    {
                        decimal guestBasketItemsPrice = item.BasketItemPrice;
                        decimal userBasketItemsPrice = userBasketItems[i].BasketItemPrice;
                        userBasketItems[i].BasketId = basketId;
                        userBasketItems[i].BasketItemCount = item.BasketItemCount + userBasketItems[i].BasketItemCount;
                        userBasketItems[i].BasketItemPrice = userBasketItemsPrice + guestBasketItemsPrice;
                        await _basketRepository.UpdateBasketItemAsync(userBasketItems[i]);
                        await _basketRepository.RemoveBasketItem(item);
                        guestBasketItems.Remove(item);
                    }
                }
            }
            for (int x = 0; x < guestBasketItems.Count; x++)
            {
                var basketItem = guestBasketItems[x];
                basketItem.BasketId = basketId;
                basketItem.BasketItemId = guestBasketItems[x].BasketItemId;
                basketItem.BasketItemPrice =guestBasketItems[x].BasketItemPrice;
                basketItem.ProductId = guestBasketItems[x].ProductId;
                await _basketRepository.UpdateBasketItemAsync(basketItem);
            }

        }
    }
}
