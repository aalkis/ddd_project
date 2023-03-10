using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Requests
{
    public class RegisterUserRequest : IRequest
    {
        public string? Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? City { get; set; }
        public string? Password { get; set; }
        public string? SecondPassword { get; set; }
    }
}
