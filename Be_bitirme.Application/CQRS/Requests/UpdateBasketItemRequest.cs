using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Requests
{
    public class UpdateBasketItemRequest : IRequest
    {
        public int UserId { get; set; }
        public Guid GuestId { get; set; }
        public string ProductIdListString { get; set; }
        public DateTime? Updated_on { get; set; }
    }
}
