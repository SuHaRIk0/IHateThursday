using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class TopDbContext : IdentityDbContext<CommonUser, IdentityRole<int>, int>
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
