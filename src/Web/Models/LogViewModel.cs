using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Web.Models
{
    public class LogViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public LogViewModel()
        {
        }

        public LogViewModel(CommonUser dummy)
        {
            Email = dummy.Email;
            Password = dummy.Password;
            RememberMe = false;
        }
    }
}