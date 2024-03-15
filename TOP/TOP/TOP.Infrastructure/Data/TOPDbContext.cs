using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TOP.Models
{
    public class TOPDbContext : DbContext
    {
        public TOPDbContext(DbContextOptions<TOPDbContext> options) : base(options) { }

        public DbSet<CommonUser> CommonUsers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookState> BookStates { get; set; }
    }
}
