using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TopDbContext _dbContext;

        public AdminRepository(TopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsAdminAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Admin>().AnyAsync(a => a.User.Id == id, cancellationToken);
        }
    }
}