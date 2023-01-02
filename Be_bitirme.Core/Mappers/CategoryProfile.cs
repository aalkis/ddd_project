using AutoMapper;
using Be_bitirme.Application.Dto;
using Be_bitirme.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Core.Mappers
{
    public class CategoryProfile : Profile
    {
        // Buraya Tree view yazıcaz son outputta düzgün liste versin diye
        // Son output apiden çıkan şöyle olmalı 
        // {[
        //   [Giyim]
        //   [Elektronik]
        //   [Hobi]
        //      [Boya]
        //      [...]
        //      [Kitap] 
        //         [Roman]
        //            [korku]
        //            [aksiyon]
        //            [...]
        //         [Geliştirme]
        //  
        //public CategoryDecider(CategoryDto categoryDto)
        //{
        //    if (categoryDto.ParentId == 0)
        //    {
                
        //    }
        //}
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()

                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                
                ;
                
        }
    }
}
