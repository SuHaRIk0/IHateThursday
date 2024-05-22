using Application.Services;
using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("uk-UA"), 
        new CultureInfo("en-US")  
    };

    options.DefaultRequestCulture = new RequestCulture("uk-UA");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddControllersWithViews();

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(builder.Configuration.GetConnectionString("AzureAppConfiguration"))
           .UseFeatureFlags();
});

var connectionString = builder.Configuration.GetConnectionString("AzureAppConfiguration");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'AzureAppConfiguration' is not set in the environment variables.");
}

builder.Services.AddDbContext<TopDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Host.UseSerilog((context, config) =>
{
    config.MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("logs/TOP.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.Seq("http://localhost:5341");
});

builder.Services.AddIdentity<CommonUser, IdentityRole<int>>(options => { })
    .AddEntityFrameworkStores<TopDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRecomendationService, RecomendationService>();
builder.Services.AddScoped<IBookTransformService, BookTransformService>();
builder.Services.AddScoped<IBookSearchService, BookSearchService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ISubscriptionSearchService, SubscriptionSearchService>();
builder.Services.AddScoped<IAdminService, AdminService>();

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

// Додайте середній шар локалізації
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);

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

    endpoints.MapControllerRoute(
        name: "login",
        pattern: "Login/{action=Login}/{id?}",
        defaults: new { controller = "Login", action = "Login" });

    endpoints.MapControllerRoute(
        name: "register",
        pattern: "Register/{action=Register}/{id?}",
        defaults: new { controller = "Register", action = "Register" });

    endpoints.MapControllerRoute(
        name: "recomendations",
        pattern: "Recomendations/{action=GetRecomendations}/{id?}",
        defaults: new { controller = "Recomendations" });

    endpoints.MapControllerRoute(
        name: "search",
        pattern: "{controller=Search}/{action=GetSearch}/{title?}",
        defaults: new { controller = "Search" });

    endpoints.MapControllerRoute(
        name: "findnewfriend",
        pattern: "Profile/FindNewFriend/{id?}",
        defaults: new { controller = "Profile", action = "FindNewFriend" });

    endpoints.MapControllerRoute(
        name: "searchfriend",
        pattern: "Profile/SearchFriend/{id?}",
        defaults: new { controller = "Profile", action = "SearchFriend" });

    endpoints.MapControllerRoute(
        name: "unfollow",
        pattern: "Profile/Unfollow",
        defaults: new { controller = "Profile", action = "Unfollow" });

    endpoints.MapControllerRoute(
        name: "removefollower",
        pattern: "Profile/RemoveFollower",
        defaults: new { controller = "Profile", action = "RemoveFollower" });

    endpoints.MapControllerRoute(
        name: "controlPanel",
        pattern: "Admin/ControlPanel/{id?}",
        defaults: new { controller = "Admin", action = "ControlPanel" });

    endpoints.MapControllerRoute(
        name: "hostStatus",
        pattern: "admin/host/status",
        defaults: new { controller = "Admin", action = "HostStatus" });
});

app.Run();
