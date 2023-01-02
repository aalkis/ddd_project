using Be_bitirme.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter);
        Task CreateAsync(User user);
    }
}
