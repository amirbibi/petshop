using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Data.Repositories;
using PetShop.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services
    .AddDbContext<AuthenticationContext>(options => options
    .UseSqlite(builder.Configuration.GetConnectionString("user")));

builder.Services
    .AddDbContext<PetShopDbContext>(options => options
    .UseLazyLoadingProxies()
    .UseSqlite(builder.Configuration.GetConnectionString("petshop")));

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 1;
        options.Password.RequiredUniqueChars = 1;
    })
    .AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userCtx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    var petShopCtx = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();

    userCtx.Database.EnsureDeleted();
    userCtx.Database.EnsureCreated();

    petShopCtx.Database.EnsureDeleted();
    petShopCtx.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/404");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
}

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();