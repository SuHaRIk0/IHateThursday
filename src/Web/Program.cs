//using Infrastructure.Data;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Serilog;
//using Microsoft.Extensions.Configuration;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();

//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json", optional: true)
//    .Build();

//string connectionString = configuration.GetConnectionString("PostgreSQLConnection");

//builder.Services.AddDbContext<TopDbContext>(options =>
//    options.UseNpgsql(connectionString));

//builder.Host.UseSerilog((context, config) =>
//{
//    config.MinimumLevel.Debug()
//        .WriteTo.Console()
//        .WriteTo.File("logs/TOP.txt", rollingInterval: RollingInterval.Day)
//        .WriteTo.Seq("http://localhost:5341");
//});

//var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");

//    endpoints.MapControllerRoute(
//        name: "profile",
//        pattern: "Profile/{action=ShowProfile}/{id?}",
//        defaults: new { controller = "Profile" });

//    endpoints.MapControllerRoute(
//        name: "editprofile",
//        pattern: "Profile/{action=EditProfile}/{id?}",
//        defaults: new { controller = "Profile" });
//});

//app.Run();


using Application.Services;
using Domain.IRepository;
using Domain.IService;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

string connectionString = configuration.GetConnectionString("PostgreSQLConnection");

builder.Services.AddDbContext<TopDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Host.UseSerilog((context, config) =>
{
    config.MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("logs/TOP.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.Seq("http://localhost:5341");
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "profile",
        pattern: "Profile/{action=ShowProfile}/{id?}",
        defaults: new { controller = "Profile" });

    endpoints.MapControllerRoute(
        name: "recomendations",
        pattern: "Recomendations/{action=GetRecomendations}/{id?}",
        defaults: new { controller = "Recomendations" });
});

app.Run();