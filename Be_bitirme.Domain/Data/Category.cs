using Be_bitirme.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Domain.Data
{
    public class Category 
    {
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
