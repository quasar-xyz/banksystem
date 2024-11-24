using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankSystem.Data;
using BankSystem.Data.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
   
        options.Password.RequireDigit = false;           
        options.Password.RequireDigit = false;          
        options.Password.RequireLowercase = false;       
        options.Password.RequireUppercase = false;      
        options.Password.RequireNonAlphanumeric = false; 
        options.Password.RequiredLength = 6;            
        options.Password.RequiredUniqueChars = 0;       

       
        options.SignIn.RequireConfirmedAccount = false;   
    })
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
app.MapRazorPages();

app.Run();