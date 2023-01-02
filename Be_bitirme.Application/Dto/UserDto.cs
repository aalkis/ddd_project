using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Dto
{
    public class UserDto
    {
        public string? Email { get; set; }
        public bool IsExist { get; set; }
        public string? UserId { get; set; }
        public int? UserStatus { get; set; }
    }
}
