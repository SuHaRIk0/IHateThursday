using Domain.Entities;

namespace Domain.IService
{
    public interface IRecomendationService : IService
    {
        Task<IEnumerable<Book>?> GetRecomendationsAsync(int id, CancellationToken cancellationToken);
    }
}