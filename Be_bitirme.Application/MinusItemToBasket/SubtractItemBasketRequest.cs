using Be_bitirme.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.SubtractItemToBasket
{
    public class SubtractItemBasketRequest : IRequest
    {
        public int? UserId { get; set; }
        public Guid? GuestId { get; set; }
        public int? count { get; set; }
        public int productId { get; set; }

    }
}
