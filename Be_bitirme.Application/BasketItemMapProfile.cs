using AutoMapper;
using Be_bitirme.Application.Dto;
using Be_bitirme.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application
{
    public class BasketItemMapProfile : Profile
    {
        public BasketItemMapProfile()
        {
            CreateMap<BasketItem, BasketItemDto>()
                .ForMember(destination => destination.BasketItemId, operation => operation.MapFrom(source => source.BasketItemId))
                .ForMember(destination => destination.BasketItemPrice, operation => operation.MapFrom(source => source.BasketItemPrice))
                .ForMember(dest => dest.BasketItemCount, ope => ope.MapFrom(source => source.BasketItemCount))
                .ForMember(dest => dest.ProductID, ope => ope.MapFrom(src => src.ProductId))
                ;
        }
    }
}
