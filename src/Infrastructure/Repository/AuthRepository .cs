using Domain.Entities;
using Domain.IRepository;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<CommonUser> _userManager;
        private readonly SignInManager<CommonUser> _signInManager;

        public AuthRepository(UserManager<CommonUser> userManager, SignInManager<CommonUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(CommonUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> LoginAsync(string email, bool rememberMe, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                return await _signInManager.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure: false);
            }

            return SignInResult.Failed;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<CommonUser?> GetUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

    }
}
