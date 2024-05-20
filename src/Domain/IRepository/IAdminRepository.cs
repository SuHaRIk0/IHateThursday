using Domain.Entities;

namespace Domain.IRepository
{
    public interface IAdminRepository: IRepository<Admin>
    {
        Task<bool> IsAdminAsync(int id, CancellationToken cancellationToken = default);
    }
}
