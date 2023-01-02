using Be_bitirme.Domain.Data;
using Be_bitirme.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Domain.Data
{
    public class Basket 
    {

        public int BasketId { get; set; }
        public int? UserId { get; set; }
        public Guid? GuestId { get; set; }
        public bool? BasketStatus { get; set; }
        //public decimal? BasketTotalPrice { get; set; }
        public DateTime? Deleted_on { get; set; }
        public DateTime? Created_on { get; set; }
        public DateTime? Updated_on { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public User? User { get; set; }
    }
}
