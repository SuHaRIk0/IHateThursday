using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterAsync(CommonUser user, string password);

        Task<SignInResult> LoginAsync(string email, bool rememberMe, string password);

        Task LogoutAsync();

        Task<CommonUser?> GetUserAsync(string email);
    }
}
