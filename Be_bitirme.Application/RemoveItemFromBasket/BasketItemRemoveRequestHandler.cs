using Azure;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.RemoveItemFromBasket
{
    public class BasketItemRemoveRequestHandler : IRequestHandler<BasketItemRemoveRequest>
    {
        private readonly IBasketRepository _basketRepository;

        public BasketItemRemoveRequestHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<Unit> Handle(BasketItemRemoveRequest request, CancellationToken cancellationToken)
        {
            if (request.basketItemId !=null )
            {
                var basketItem = await _basketRepository.CheckBasketItemByBasketId(request.basketItemId);
                await _basketRepository.RemoveBasketItem(basketItem);

            }


            return Unit.Value;

        }
    }
}
