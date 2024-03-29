using Domain.DTO;

namespace Domain.IService
{
    public interface IRecomendationService
    {
        Task<IEnumerable<BookDto>> GetRecomendationsAsync(int id);
    }
}
