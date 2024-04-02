using Domain.Entities;

namespace Domain.IService
{
    public interface IRecomendationService
    {
        Task<IEnumerable<Book>?> GetRecomendationsAsync(int id);
    }
}
