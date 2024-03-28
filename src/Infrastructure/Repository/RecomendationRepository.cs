using Domain.DTO;
using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RecomendationRepository : IRecomendationRepository
    {
        private readonly TopDbContext _dbContext;

        public RecomendationRepository(TopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommonUserDTO?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return new CommonUserDTO(await _dbContext.Set<CommonUser>()
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken));
        }
    }
}
