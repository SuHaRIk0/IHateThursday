using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = "Host=cdgn4ufq38ipd0.cluster-czz5s0kz4scl.eu-west-1.rds.amazonaws.com;Port=5432;Database=da34olh1r8hn0a;Username=uek3pbiak18apr;Password=p5b55330b733d41afb15c201e028d0d46ba93064bdc56375cf76b9d206cb2640f";

            builder.Services.AddDbContext<TopDbContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Host.UseSerilog((context, config) =>
            {
                config.MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/TOP.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq("http://localhost:5341");
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
