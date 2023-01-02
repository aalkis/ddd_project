using Be_bitirme.Application.AddItemToBasket;
using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.RemoveItemFromBasket;
using Be_bitirme.Application.SubtractItemToBasket;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Be_bitirme.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;


        public BasketController(IMediator mediator, IValidator<AddItemBasketRequest> validator)
        {
            _mediator = mediator;

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Merge(MergeBasketRequest request)
        {
                await _mediator.Send(request);
                return NoContent();
          
        }
      
        [HttpPut("[action]")]
        public async Task<IActionResult> IncreaseBasketItem(AddItemBasketRequest request)
        {           
            await _mediator.Send(request);
            return NoContent();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> CheckBasket(CheckBasketRequest request)
        {

                var res = await _mediator.Send(request);
                return Ok(res);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SubtractBasketItem(SubtractItemBasketRequest request)
        {

                await _mediator.Send(request);
                return NoContent();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveBasketItem(BasketItemRemoveRequest request)
        {

             await _mediator.Send(request);
             return NoContent();
        }
    }
}
