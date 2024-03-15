using System;
using Serilog;


namespace TOP
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/TasselOnThePalm.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

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