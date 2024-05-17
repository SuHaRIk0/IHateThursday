using Domain.DTO;
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

        public async Task<bool> EditByIdAsync(int id, CommonUser updatedUser, CancellationToken cancellationToken = default)
        {

            _dbContext.Update<CommonUser>(updatedUser);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<CommonUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<CommonUser>()
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public Task<CommonUser?> ShowByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}