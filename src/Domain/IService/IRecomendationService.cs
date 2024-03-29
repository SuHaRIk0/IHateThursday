using Domain.DTO;

namespace Domain.IService
{
    public interface IRecomendationService
    {
        IEnumerable<BookDto> GetRecomendations(int id);
    }
}
