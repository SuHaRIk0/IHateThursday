using Domain.Entities;

namespace Domain.IRepository
{
    public interface IUserRepository : IRepository<CommonUser>
    {
        Task<CommonUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> EditByIdAsync(int id, CommonUser updatedUser, CancellationToken cancellationToken = default);
        Task<CommonUser?> ShowByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<CommonUser?> GetByTagAsync(string tag, CancellationToken cancellationToken = default);
    }
}