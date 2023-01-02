using Be_bitirme.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.CQRS.Requests
{
    public class CheckProductRequest : IRequest<ProductDto>
    {
        public int? ProductID { get; set; }
        public string? SmartUrl { get; set; }
    }
}
