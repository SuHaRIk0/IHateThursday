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

// Adding services and repositories. Better to move to another file in the future
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IRecomendationService, RecomendationService>();

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
        pattern: "Recomendations/{action=GetRecomendationsAsync}/{id?}",
        defaults: new { controller = "Recomendations" });
});

app.Run();