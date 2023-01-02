using Azure.Core;
using Be_bitirme.Application.Dto;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Application.SubtractItemToBasket;
using Be_bitirme.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.MinusItemToBasket
{
    public class SubtractItemBasketRequestHandler : IRequestHandler<SubtractItemBasketRequest>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public SubtractItemBasketRequestHandler(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(SubtractItemBasketRequest request, CancellationToken cancellationToken)
        {
            if (request.count == null)
            {
                int oneCount = 1;
                await SubtractMethod(request.GuestId, request.UserId, oneCount, request.productId);
            }
            else
            {
                await SubtractMethod(request.GuestId, request.UserId, (int)request.count, request.productId);
            }
            return Unit.Value;
        }

        private async Task SubtractMethod(Guid? GuestId, int? UserId, int count, int productId)
        {
            var iteminfo = await _productRepository.SingleProductAsync(productId);
            if (UserId == null && GuestId != null)
            {
                var newbasket = await _basketRepository.GetBasketByGIdAsync((Guid)GuestId);
                var oldbasketItem = await _basketRepository.FindBasketItem(newbasket.BasketId, productId);

                oldbasketItem.BasketItemCount = oldbasketItem.BasketItemCount - (int)count;
                oldbasketItem.BasketItemPrice = oldbasketItem.BasketItemCount * iteminfo.Price;
                if(oldbasketItem.BasketItemCount > 0)
                {
                await _basketRepository.UpdateBasketItemAsync(oldbasketItem);
                }
            }

            else if (UserId != null)
            {
                var newbasket = await _basketRepository.GetBasketByIdAsync((int)UserId);
                var oldbasketItem = await _basketRepository.FindBasketItem(newbasket.BasketId, productId);

                oldbasketItem.BasketItemCount = oldbasketItem.BasketItemCount - (int)count;
                oldbasketItem.BasketItemPrice = oldbasketItem.BasketItemCount * iteminfo.Price;
                if (oldbasketItem.BasketItemCount > 0)
                {
                    await _basketRepository.UpdateBasketItemAsync(oldbasketItem);
                }
            }
        }
    }


}
