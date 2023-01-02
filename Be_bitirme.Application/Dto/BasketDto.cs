using Be_bitirme.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Dto
{
    public class BasketDto
    {
        public int BasketId { get; set; }
        public int? UserId { get; set; }
        public Guid? GuestId { get; set; }
        public bool? OrderStatus { get; set; }
        public decimal? BasketTotalPrice { get; set; }
        public DateTime? Deleted_on { get; set; }
        public DateTime? Created_on { get; set; }
        public DateTime? Updated_on { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
    }
}
