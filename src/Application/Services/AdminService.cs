using Domain.IRepository;
using Domain.IService;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;

        private readonly ILogger<AdminService> _logger;

        public AdminService(IBookRepository bookRepository, IUserRepository userRepository, IAdminRepository adminRepository, ILogger<AdminService> logger)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _adminRepository = adminRepository;
            _logger = logger;
        }
        public async Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Admin rying to delete book...");
            var isDeleted = await _bookRepository.DeleteBookByIdAsync(id);
            if (isDeleted)
            {
                _logger.LogInformation("Deletion was successful.");
            }
            else
            {
                _logger.LogInformation("Deletion was NOT successful.");

            }
            return isDeleted;
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Admin rying to delete user...");
            var isDeleted = await _userRepository.DeleteByIdAsync(id);
            if (isDeleted)
            {
                _logger.LogInformation("Deletion was successful.");
            }
            else
            {
                _logger.LogInformation("Deletion was NOT successful.");

            }
            return isDeleted;
        }

        public async Task<bool> IsAdminAsync(int id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Checking admin privilege...");
            var isAdmin = await _adminRepository.IsAdminAsync(id);
            if (isAdmin)
            {
                _logger.LogInformation("This user is an admin.");
            }
            else
            {
                _logger.LogInformation("This user is NOT an admin.");
            }
            return isAdmin;
        }
    }
}