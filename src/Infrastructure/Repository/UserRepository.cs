using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TopDbContext _dbContext;

        public UserRepository(TopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommonUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<CommonUser>()
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
    }
}
