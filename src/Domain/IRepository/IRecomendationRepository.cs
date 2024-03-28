using Domain.DTO;
using Domain.Entities;

namespace Domain.IRepository
{
    public interface IRecomendationRepository: IRepository<CommonUser>
    {
        Task<CommonUserDTO?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
