using Domain.Entities;

namespace Domain.IService
{
<<<<<<< HEAD
    public interface IRecomendationService : IService
    {
        Task<IEnumerable<Book>?> GetRecomendationsAsync(int id, CancellationToken cancellationToken);
    }
}
=======
    public interface IRecomendationService: IService
    {
        Task<IEnumerable<Book>?> GetRecomendationsAsync(int id, CancellationToken cancellationToken);
    }
}
>>>>>>> origin/third_block
