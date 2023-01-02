using AutoMapper;
using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Dto;
using Be_bitirme.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Handlers
{
    public class CheckBasketRequestHandler : IRequestHandler<CheckBasketRequest, BasketDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CheckBasketRequestHandler(IBasketRepository basketRepository, IProductRepository productRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BasketDto> Handle(CheckBasketRequest request, CancellationToken cancellationToken)
        {
            decimal finalprice = 0;
            var dto = new BasketDto();
            if(request.UserId == null)
            {
              var response = await _basketRepository.GetBasketByGIdAsync((Guid)request.GuestId);
              

                for (int i = 0; i < response.BasketItems.Count; i++)
                {
                    var priceforeach = response.BasketItems[i].BasketItemPrice * response.BasketItems[i].BasketItemCount;
                    finalprice = finalprice + priceforeach;
                }
                dto.BasketId = response.BasketId;
                dto.GuestId = response.GuestId;
                dto.UserId = response.UserId;
                dto.BasketItems = _mapper.Map<List<BasketItemDto>>(response.BasketItems);
                dto.Created_on = response.Created_on;
                dto.Updated_on = response.Updated_on;
                dto.Deleted_on = response.Deleted_on;
                dto.OrderStatus = response.BasketStatus;
                dto.BasketTotalPrice = finalprice;
            }
            else 
            {
               var response = await _basketRepository.GetBasketByIdAsync((int)request.UserId);
               

                if (response.BasketItems.Count > 0)
                {

                for (int i = 0; i < response.BasketItems.Count; i++)
                {
                    var priceforeach = response.BasketItems[i].BasketItemPrice * response.BasketItems[i].BasketItemCount;
                    finalprice = finalprice + priceforeach;
                }
                }
                dto.BasketId = response.BasketId;
                dto.GuestId = response.GuestId;
                dto.UserId = response.UserId;
                dto.BasketItems = _mapper.Map<List<BasketItemDto>>(response.BasketItems);
                dto.Created_on = response.Created_on;
                dto.Updated_on = response.Updated_on;
                dto.Deleted_on = response.Deleted_on;
                dto.OrderStatus = response.BasketStatus;
                dto.BasketTotalPrice = finalprice;
            }


            return dto;
        }
    }
}
