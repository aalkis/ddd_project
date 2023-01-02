using Azure.Core;
using Be_bitirme.Application.Dto;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.AddItemToBasket
{
    public class AddItemBasketRequestHandler : IRequestHandler<AddItemBasketRequest>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public AddItemBasketRequestHandler(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddItemBasketRequest request, CancellationToken cancellationToken)
		{
            var product= await _productRepository.SingleProductAsync(request.productId);
            var productstock = product.Stock;

            if(productstock >= request.count)
            {
                if (request.count == 0 || request.count == null)
                {
                    int oneCount = 1;
                    await AddItemMethod(request.GuestId, request.UserId, oneCount, request.productId);
                }
                else
                {
                    await AddItemMethod(request.GuestId, request.UserId, request.count, request.productId);
                }
            }

            return Unit.Value ;
        }

        public async Task AddItemMethod(Guid? GuestId, int? UserId, int? count, int productId)
        {
            var iteminfo = await _productRepository.SingleProductAsync(productId);
            if (UserId == null && GuestId == null)
            {
                var finalbasket = new Basket()
                {
                    GuestId = Guid.NewGuid(),
                    UserId = null,
                    BasketStatus = true,
                    //BasketTotalPrice = count * iteminfo.Price,
                    Created_on = DateTime.UtcNow,
                };
                await _basketRepository.CreateBasket(finalbasket);
                var newbasket = await _basketRepository.GetBasketByGIdAsync((Guid)finalbasket.GuestId);
                if (newbasket != null)
                {
                    var newBasketItem = new BasketItem()
                    {
                        BasketId = newbasket.BasketId,
                        BasketItemCount = (int)count,
                        BasketItemPrice = (int)count * iteminfo.Price,
                        ProductId = productId
                    };
                    await _basketRepository.AddBasketItemAsync(newBasketItem);
                }             
            }
            else if (UserId == null && GuestId != null )
            {
                var newbasket = await _basketRepository.GetBasketByGIdAsync((Guid)GuestId);
                var oldbasketItem = await _basketRepository.FindBasketItem(newbasket.BasketId, productId);
                if (oldbasketItem != null)
                {
                    oldbasketItem.BasketItemCount = oldbasketItem.BasketItemCount + (int)count;
                    oldbasketItem.BasketItemPrice = oldbasketItem.BasketItemCount * iteminfo.Price;

                    await _basketRepository.UpdateBasketItemAsync(oldbasketItem);
                }
                else
                {
                    var newBasketItem = new BasketItem()
                    {
                        BasketId = newbasket.BasketId,
                        BasketItemCount = (int)count,
                        BasketItemPrice = (int)count * iteminfo.Price,
                        ProductId = productId
                    };
                    await _basketRepository.AddBasketItemAsync(newBasketItem);
                }
            }

            else if (UserId != null)
            {
                var newbasket = await _basketRepository.GetBasketByIdAsync((int)UserId);
                if (newbasket == null)
                {
                    var finalbasket = new Basket()
                    {
                        GuestId = null,
                        UserId = UserId,
                        BasketStatus = true,
                        //BasketTotalPrice = count * iteminfo.Price,
                        Created_on = DateTime.UtcNow,
                    };
                    await _basketRepository.CreateBasket(finalbasket);
                    var newbasket2 = await _basketRepository.GetBasketByIdAsync((int)UserId);
                    {
                        var newBasketItem = new BasketItem()
                        {
                            BasketId = newbasket2.BasketId,
                            BasketItemCount = (int)count,
                            BasketItemPrice = (int)count * iteminfo.Price,
                            ProductId = productId
                        };
                        await _basketRepository.UpdateBasketItemAsync(newBasketItem);
                    }
                }

                else
                {
                    var oldbasketItem = await _basketRepository.FindBasketItem(newbasket.BasketId, productId);
                    if (oldbasketItem != null)
                    {
                        oldbasketItem.BasketItemCount = oldbasketItem.BasketItemCount + (int)count;
                        oldbasketItem.BasketItemPrice = oldbasketItem.BasketItemCount * iteminfo.Price;

                        await _basketRepository.UpdateBasketItemAsync(oldbasketItem);
                    }
                    else
                    {
                        var newBasketItem = new BasketItem()
                        {
                            BasketId = newbasket.BasketId,
                            BasketItemCount = (int)count,
                            BasketItemPrice = (int)count * iteminfo.Price,
                            ProductId = productId
                        };
                        await _basketRepository.AddBasketItemAsync(newBasketItem);
                    }
                }
            }
        }

    }   
}
