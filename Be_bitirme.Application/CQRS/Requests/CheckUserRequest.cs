using Be_bitirme.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Requests
{
    public class CheckUserRequest : IRequest<UserDto>
    {
        public string Email { get; set; }   
        public string Password { get; set; }    
    }
}
