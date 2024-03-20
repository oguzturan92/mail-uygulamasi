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

    // IDENTITY AYARLARI - 1
    builder.Services.Configure<IdentityOptions>(options => {

        // Şifre Ayarları
        options.Password.RequireDigit = false; // Sayısal değer bulunma durumu.
        options.Password.RequireLowercase = false; // Küçük harf bulunma durumu.
        options.Password.RequireUppercase = false; // Büyük harf bulunma durumu.
        // options.Password.RequiredLength = false; // Minimum karakter sayısı.
        options.Password.RequireNonAlphanumeric = false; // Hem rakam hem harf bulunma durumu.

        // Kilitleme Ayarları
        options.Lockout.MaxFailedAccessAttempts = 5; // 5 yanlış parola girme hakkı olur ve engellenir.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // 5dk sonra engeli kalkar.
        options.Lockout.AllowedForNewUsers = true; // Kilitleme işlemi, yeni kullanıcı için geçerli olur.

        // Mail Ayarları
        // options.User.AllowedUserNameCharacters = ""; // UserName içinde olmasını istediğimiz harfler
        options.User.RequireUniqueEmail = true; // Aynı mail adresi ile bir tane kullanıcı oluşturulabilir.
        options.SignIn.RequireConfirmedEmail = true; // Üye olduktan sonra hesap onaylansın mı.
        options.SignIn.RequireConfirmedPhoneNumber = false; // Üye olduktan sonra telefon numarası onaylansın mı.
    });

    // IDENTITY AYARLARI - 2
    builder.Services.ConfigureApplicationCookie(options => {
        // COOKIE Nedir? : Üye girişi yaptıktan sonra, çıkış yapana kadar, bizden tekrar şifre istemez. Çünkü Cookie aracılığıyla, giriş bilgilerimiz tarayıcıda tutuluyor. Başka bir Örnek : Sepete ürün ekledikten sonra üye girişi yaptığımızda, eklediğimiz sepet karşımıza gelir. Burdaki sepet bilgileri de Cookie aracılığıyla tarayıcıda tutulmuşur.

        options.LoginPath = "/User/UserLogin"; // Giriş yapmamış kullanıcı, yetkisi olmayan sayfaya gitmek istediğinde, yönlendirilecek sayfa.
        options.LogoutPath = "/AdminAccount/Logout"; // Hesaptan çıkış yapılırsa, Cookie, tarayıcıdan silinmiş olacak ve kullanıcı çıkış yaptıktan sonra, parantez içindeki sayfaya yönlendirilecek.
        options.AccessDeniedPath = "/User/UserLogin"; // Giriş yapmış kullanıcı, yetkisi olmayan sayfaya gitmek istediğinde, yönlendirilecek sayfa.
        options.SlidingExpiration = true; // Oturum açıldıktan sonra, her istek yaptığında, kullanıcı Cookie'sinin tarayıcıdan silinmesi için extra 20dk verir. False dersek, istek yapsın yapmasın, ilk giriş yaptıktan 20dk sonra oturum sonlanır.
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // SlidingExpiration(Yukarıdaki özellik) özelliğinin varsayılan dakikasını belirler. 20 yerine 5dk ya da 1 gün diyebiliriz.
        // Not : Tarayıcı kapandığında Cookie silinmesi için Login Action'a bak.
        options.Cookie = new CookieBuilder
        {
            HttpOnly = true, // Cookie değerlerini, sadece, HttpRequest talep edebilir. JavaScript talep edemez. Biz bunu kullanıcaz. Değiştirme.
            Name = ".medikal.Security.Cookie", // Cookie'nin nasıl adlandırılacağı. Tarayıcıda böyle görünecek.

            SameSite = SameSiteMode.Strict // CSRF TOKEN. 
        };
    });

        // MAIL AYARLARI
    builder.Services.AddScoped<IEmailGonder, EmailHotmailGonder>(i => 
        new EmailHotmailGonder(
            builder.Configuration["EmailGonder:Host"],
            builder.Configuration.GetValue<int>("EmailGonder:Port"),
            builder.Configuration.GetValue<bool>("EmailGonder:EnableSSL"),
            builder.Configuration["EmailGonder:UserName"],
            builder.Configuration["EmailGonder:Password"]
        )
    );

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
