using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TopDbContext : DbContext
    {
        public TopDbContext(DbContextOptions<TopDbContext> options) : base(options) { }

        public DbSet<CommonUser> CommonUsers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookState> BookStates { get; set; }
    }
}
