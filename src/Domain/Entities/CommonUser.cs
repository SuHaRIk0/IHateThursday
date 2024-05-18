<<<<<<< HEAD
﻿
using Microsoft.AspNetCore.Identity;
=======
﻿using Microsoft.AspNetCore.Identity;
>>>>>>> origin/third_block

namespace Domain.Entities
{
    public class CommonUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string GenresReaded { get; set; }

    }
}
