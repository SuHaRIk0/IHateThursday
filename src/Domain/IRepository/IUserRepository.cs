using Domain.Entities;

namespace Domain.IRepository
{
    public interface IUserRepository : IRepository<CommonUser>
    {
        Task<CommonUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}