using Data.Concrete.EfCore;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using WebUI.EmailServis;
using WebUI.Extension;

var builder = WebApplication.CreateBuilder(args);

    // IDentity Context bilgileri
    builder.Services.AddDbContext<ProjeContext>();
    builder.Services.AddIdentity<ProjeUser, ProjeRole>().AddEntityFrameworkStores<ProjeContext>().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();


    builder.Services.Configure<IdentityOptions>(options => {

        
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;

        options.Password.RequireNonAlphanumeric = false;

        // Kilitleme Ayarları
        options.Lockout.MaxFailedAccessAttempts = 5; 
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.AllowedForNewUsers = true;

        /
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = true;
        options.SignIn.RequireConfirmedPhoneNumber = false;
    });

    // IDENTITY AYARLARI - 2
    builder.Services.ConfigureApplicationCookie(options => {
        

        options.LoginPath = "/User/UserLogin"; 
        options.LogoutPath = "/AdminAccount/Logout";
        options.AccessDeniedPath = "/User/UserLogin";
        options.SlidingExpiration = true; 
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        
    });

    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

    // 404 hatası için yazdık. Error Controller içindeki Error404 Actionuna, code parametresi ile gidecek
    app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

    app.UseAuthentication(); // IDentity için

    app.UseAuthorization(); // IDentity için

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MigrateDatabase().Run();
