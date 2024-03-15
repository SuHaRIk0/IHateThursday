using System;
using Serilog;
using TOP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace TOP
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = "Host=cdgn4ufq38ipd0.cluster-czz5s0kz4scl.eu-west-1.rds.amazonaws.com;Port=5432;Database=da34olh1r8hn0a;Username=uek3pbiak18apr;Password=p5b55330b733d41afb15c201e028d0d46ba93064bdc56375cf76b9d206cb2640f";

            builder.Services.AddDbContext<TopDbContext>(options =>
                options.UseNpgsql(connectionString));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/TOP.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            try
            {
                Log.Debug("Trying to use HTTPs redirection...");
                app.UseHttpsRedirection();
                Log.Information("Redirection successful!");
            }
            catch(Exception ex)
            {
                Log.Error($"Something went wrong! Details {ex.Message}");
            }
            app.UseStaticFiles();

            try
            {
                Log.Debug("Trying to use routing...");
                app.UseRouting();
                Log.Information("Routing successful!");
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong! Details {ex.Message}");
            }

            try
            {
                Log.Debug("Trying to use authorization...");
                app.UseAuthorization();
                Log.Information("Authorization successful!");
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong! Details {ex.Message}");
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            try 
            {
                Log.Debug("Trying to run the program...");
                app.Run();
            }
            catch (Exception ex) 
            {
                Log.Error($"Something went wrong! Details {ex.Message}");
            }
            finally
            {
                await Log.CloseAndFlushAsync();
            }
        }
    }
}