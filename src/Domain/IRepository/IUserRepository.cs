using Domain.DTO;
using Domain.Entities;

namespace Domain.IRepository
{
    public interface IUserRepository: IRepository<CommonUser>
    {
        Task<CommonUserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
