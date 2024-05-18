using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IAuthRepository authRepository, ILogger<AuthService> logger)
        {
            _authRepository = authRepository;
            _logger = logger;
        }

        public async Task<IdentityResult> RegisterAsync(CommonUser user, string password)
        {
            _logger.LogInformation("Registering a new user...");

            var result = await _authRepository.RegisterAsync(user, password);

            if (result.Succeeded)
            {
                _logger.LogInformation("Registration successful.");
            }
            else
            {
                _logger.LogError("Registration failed.");
            }

            return result;
        }

        public async Task<SignInResult> LoginAsync(string email, bool rememberMe, string password)
        {
            _logger.LogInformation("Attempting to log in user...");

            var result = await _authRepository.LoginAsync(email, rememberMe, password);

            if (result.Succeeded)
            {
                _logger.LogInformation("Login successful.");
            }
            else
            {
                _logger.LogError("Login failed.");
            }

            return result;
        }

        public async Task LogoutAsync()
        {
            _logger.LogInformation("Logging out user...");

            await _authRepository.LogoutAsync();

            _logger.LogInformation("Logout successful.");
        }

        public async Task<CommonUser?> GetUserAsync(string email)
        {
            var user = await _authRepository.GetUserAsync(email);

            return user;
        }

    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/third_block
