using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }   
        public string CategoryName { get; set; }
        public List<CategoryDto> subCategories { get; set; }
    }
}
