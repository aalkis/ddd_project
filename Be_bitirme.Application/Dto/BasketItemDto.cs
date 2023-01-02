using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Dto
{
    public class BasketItemDto
    {
        public int ProductID { get; set; }
        public int BasketItemId { get; set; }
        public int BasketItemCount { get; set; }
        public Decimal BasketItemPrice { get; set; }
    }
}
