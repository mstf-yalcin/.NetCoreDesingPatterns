using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();






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
        userManager.CreateAsync(new AppUser() { UserName = "User1", Email = "test@gmail.com", PictureUrl = "https://www.webbox.co.uk/wp-content/uploads/2020/10/angry_cat_2-scaled-1568x1046.jpg", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User2", Email = "test2@gmail.com", PictureUrl = "https://www.webbox.co.uk/wp-content/uploads/2020/10/angry_cat_2-scaled-1568x1046.jpg", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User3", Email = "test3@gmail.com", PictureUrl = "https://www.webbox.co.uk/wp-content/uploads/2020/10/angry_cat_2-scaled-1568x1046.jpg", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User4", Email = "test4@gmail.com", PictureUrl = "https://www.webbox.co.uk/wp-content/uploads/2020/10/angry_cat_2-scaled-1568x1046.jpg", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "User5", Email = "test5@gmail.com", PictureUrl = "https://www.webbox.co.uk/wp-content/uploads/2020/10/angry_cat_2-scaled-1568x1046.jpg", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." }, "Password12*").Wait();
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
