using AutoMapper;
using AutoMapper.Internal;
using Azure;
using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Dto;

using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace Be_bitirme.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, IMediator mediator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> ListAll()
        //{
        //    List<Category> result = await _categoryRepository.ListAllAsync();    
            
        //    return Ok(result);
        //}
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var result = await _mediator.Send(new CategoryCheckRequest());

            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> SingleCategory(string name)
        {
            Category result = await _categoryRepository.SingleCategoryAsync(name);
            return Ok(result);
        }
    }

    //public List<CategoryDto> MakeTree(IEnumerable<Category> list, CategoryDto parentNode)
    //{
    //    List<CategoryDto> treeviewList = new List<CategoryDto>();
    //    var nodes = list.Where(x => parentNode == null ? x.ParentId == 0 : x.ParentId == parentNode.Id);
    //    foreach (var node in nodes)
    //    {
    //        CategoryDto newNode = new CategoryDto();
    //        newNode.Id = node.CategoryId;
    //        newNode.CategoryName = node.CategoryName;
    //        if(parentNode == null)
    //        {
    //            treeviewList.Add(newNode);
    //        }
    //        else
    //        {
    //            parentNode.subCategories.Add(newNode);
    //        }

    //    }
    //    return treeviewList;
    //}
   
}
