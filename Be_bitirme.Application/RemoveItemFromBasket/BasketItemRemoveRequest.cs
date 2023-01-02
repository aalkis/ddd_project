using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.RemoveItemFromBasket
{
    public class BasketItemRemoveRequest : IRequest
    {
        public int basketItemId { get; set; }
    }
}
