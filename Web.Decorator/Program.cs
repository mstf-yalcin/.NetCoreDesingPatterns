using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Web.Decorator.Repository;
using Web.Decorator.Repository.Decorator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//*********************

builder.Services.AddMemoryCache();

//scrutor

//builder.Services.AddScoped<IProductRepostiory, ProductRepository>()
//     .Decorate<IProductRepostiory, ProductRepostioryCacheDecorator>()
//     .Decorate<IProductRepostiory, ProductRepositoryLoggingDecorator>();

//*********************

//builder.Services.AddScoped<IProductRepostiory>(sp =>
//{
//    var context = sp.GetRequiredService<AppIdentityDbContext>();
//    var memoryCache = sp.GetRequiredService<IMemoryCache>();

//    var logService = sp.GetRequiredService<ILogger<ProductRepositoryLoggingDecorator>>();

//    var productRepository = new ProductRepository(context);
//    var cacheDecorator = new ProductRepostioryCacheDecorator(productRepository, memoryCache);

//    var logDecorator = new ProductRepositoryLoggingDecorator(cacheDecorator, logService);

//    return logDecorator;
//});

//*********************

builder.Services.AddScoped<IProductRepostiory>(sp =>
{
    var httpContextAcessor = sp.GetRequiredService<IHttpContextAccessor>();

    var context = sp.GetRequiredService<AppIdentityDbContext>();
    var memoryCache = sp.GetRequiredService<IMemoryCache>();
    var logService = sp.GetRequiredService<ILogger<ProductRepositoryLoggingDecorator>>();

    var productRepository = new ProductRepository(context);

    if (httpContextAcessor.HttpContext.User.Identity.Name=="user1")
    {
        var cacheDecorator = new ProductRepostioryCacheDecorator(productRepository, memoryCache);
        return cacheDecorator;
    }

    var logDecorator = new ProductRepositoryLoggingDecorator(productRepository, logService);

    return logDecorator;
});




builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppIdentityDbContext>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{

    var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    identityDbContext.Database.Migrate();


    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser() { UserName = "User1", Email = "test@gmail.com" }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User2", Email = "test2@gmail.com" }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User3", Email = "test3@gmail.com" }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User4", Email = "test4@gmail.com" }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User5", Email = "test5@gmail.com" }, "Password12*").Wait();
    }


}

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
