
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class CommonUser : IdentityUser<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string GenresReaded { get; set; }
    }
}
