using Domain.Entities;
using Domain.IRepository;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(CommonUser user, string password);
        Task<SignInResult> LoginAsync(string email, bool rememberMe, string password);
        Task<CommonUser?> GetUserAsync(string email);
        Task LogoutAsync();
    }
}