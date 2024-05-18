using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Web.Models
{
    public class RegViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegViewModel()
        {
        }

        public RegViewModel(CommonUser dummy)
        {
            UserName = dummy.UserName;
            Email = dummy.Email;
            Password = dummy.Password;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/third_block
