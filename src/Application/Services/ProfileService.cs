using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Domain.DTO;

namespace Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger<ProfileService> _logger;

        public ProfileService(IUserRepository userRepository, ILogger<ProfileService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<bool> EditByIdAsync(int id, CommonUser updatedUser)
        {
            _logger.LogInformation("Started edit operations...");

            var dummy = await _userRepository.GetByIdAsync(id);

            if (dummy == null)
            {
                return false;
            }

            dummy.Name = updatedUser.Name;
            dummy.Tag = updatedUser.Tag;
            dummy.Description = updatedUser.Description;
            dummy.GenresReaded = updatedUser.GenresReaded;

            if (dummy != null)
            {
                _logger.LogInformation("Retrivial successful!");
                return await _userRepository.EditByIdAsync(dummy.Id, dummy);
            }

            _logger.LogInformation("Retrivial UNsuccessful! The result is NULL!");
            return true;
        }

        public async Task<CommonUser?> ShowByIdAsync(int id)
        {
            var dummy = await _userRepository.GetByIdAsync(id);

            return dummy;
        }
    }
}