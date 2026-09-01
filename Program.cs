using ModernPortfolio.Repositories.@abstract;
using ModernPortfolio.Repositories.concrete;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.Services.concrete;

var builder = WebApplication.CreateBuilder(args);

// IoC (Inversion of Control) konteynerine Controller ve View desteği (MVC) sunan servisleri ekler.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IContactService, ContactService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Uygulama (WebApplication) nesnesini derleyip oluşturur. 
// Bu adımdan sonra servis kayıt aşaması biter ve HTTP istek boru hattı (Middleware Pipeline) yapılandırmasına geçilir.
var app = builder.Build();

// HTTP istek boru hattının (Middleware Pipeline) yapılandırılması.
// Uygulama Geliştirme (Development) ortamında çalışmıyorsa (örn. Canlı/Production ortamında):
if (!app.Environment.IsDevelopment())
{
    // İstekler sırasında oluşabilecek işlenmemiş hataları yakalayarak kullanıcıyı "/Home/Error" sayfasına yönlendirir.
    app.UseExceptionHandler("/Home/Error");

    // HTTP Strict Transport Security (HSTS) protokolünü etkinleştirir. 
    // Tarayıcılara sitenin sadece HTTPS üzerinden açılması gerektiğini bildirerek güvenliği artırır.
    app.UseHsts();
}

// Güvensiz HTTP isteklerini otomatik olarak güvenli HTTPS protokolüne yönlendirir.
app.UseHttpsRedirection();

// Gelen isteklerin URL'lerine göre hangi rota (route) şablonuyla eşleşeceğini belirleyen yönlendirme (Routing) sistemini etkinleştirir.
app.UseRouting();

// Kullanıcının talep edilen kaynağa erişim yetkisini (Authorization) kontrol eder.
app.UseAuthorization();

// .NET 9 ile gelen, CSS, JS ve resim gibi statik dosyaların optimize edilerek (sıkıştırma, fingerprinting vb.) sunulmasını sağlayan middleware'i eşler.
app.MapStaticAssets();

app.MapControllerRoute(
    name:"areas",
    pattern:"{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

// MVC mimarisine uygun varsayılan rota şablonunu tanımlar.
// Herhangi bir Controller veya Action belirtilmediğinde varsayılan olarak HomeController sınıfındaki Index metodunu çalıştırır.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Uygulamayı başlatır ve gelen HTTP isteklerini dinlemeye (port üzerinden) başlar.
app.Run();
