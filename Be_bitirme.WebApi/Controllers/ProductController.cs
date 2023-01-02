using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Be_bitirme.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository? _productRepository;
        private readonly IMediator _mediator;

        public ProductController(IProductRepository? productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Product(CheckProductRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.ProductName == null)
             {
             return BadRequest("A product like this is not found");
            }
             else
                 return Ok(result);
        }


    }
}
