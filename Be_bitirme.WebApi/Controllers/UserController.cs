using Be_bitirme.Application.CQRS.Requests;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Be_bitirme.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UserController(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn(CheckUserRequest request)
        {
            var dto = await _mediator.Send(request);
            if (dto.IsExist)
            {
                if (dto.UserStatus == 1)
                {
                    return Ok(dto);
                }
                else
                {
                    string abc = dto.Email + " is not active";
                    return Ok(abc);
                }
            }
            else 
                return BadRequest("Username veya Password hatalı");
        }

    }
}
