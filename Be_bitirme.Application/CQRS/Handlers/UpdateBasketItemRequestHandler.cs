using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Handlers
{
    public class UpdateBasketItemRequestHandler : IRequestHandler<UpdateBasketItemRequest>
    {
        private readonly IBasketRepository _basketrepository;
        private readonly IProductRepository _productrepository;

        public UpdateBasketItemRequestHandler(IBasketRepository basketrepository, IProductRepository productrepository)
        {
            _basketrepository = basketrepository;
            _productrepository = productrepository;
        }

        public async Task<Unit> Handle(UpdateBasketItemRequest request, CancellationToken cancellationToken)
        {

            var updatedProduct = await _basketrepository.GetBasketByIdAsync(request.UserId);
            var updatedGProduct = await _basketrepository.GetBasketByGIdAsync(request.GuestId);

            int[] updatedbasketproductlist = Array.ConvertAll(request.ProductIdListString.Split(','), int.Parse);
            decimal finalprice = 0;
            for (int i = 0; i < updatedbasketproductlist.Length; i++)
            {
                var fetchedproduct = await _productrepository.SingleProductAsync(updatedbasketproductlist[i]);
                var productprice = fetchedproduct.Price;
                finalprice = finalprice + productprice;
            }

            if (updatedProduct != null)
            {
               
                updatedProduct.Updated_on = request.Updated_on;
                //updatedProduct.BasketTotalPrice = finalprice;
                updatedProduct.UserId = request.UserId;
                updatedProduct.GuestId = null;

                await _basketrepository.UpdateBasketAsync(updatedProduct);
            }
            else if(updatedGProduct != null)
            {

                updatedGProduct.Updated_on = request.Updated_on;
                //updatedGProduct.BasketTotalPrice = finalprice;
                updatedGProduct.GuestId = request.GuestId;
                await _basketrepository.UpdateBasketAsync(updatedGProduct);
            }
            
            return Unit.Value;
            
        }
    }
}
