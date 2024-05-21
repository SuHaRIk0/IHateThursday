namespace Domain.IService
{
    public interface IAdminService
    {
        Task<bool> IsAdminAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}