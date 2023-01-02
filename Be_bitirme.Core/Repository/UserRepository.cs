using Be_bitirme.Application.Interfaces;
using Be_bitirme.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
        {
            return await _context.Set<User>().AsNoTracking().SingleOrDefaultAsync(filter);
        }
        public async Task CreateAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();  
        }
    }
}
