using Be_bitirme.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Requests
{
    public class CheckBasketRequest : IRequest<BasketDto>
    {
        public int? UserId { get; set; }
        public Guid? GuestId { get; set; }
    }
}
