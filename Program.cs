using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using ModernPortfolio.Repositories.@abstract;
using ModernPortfolio.Repositories.concrete;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.Services.concrete;

var builder = WebApplication.CreateBuilder(args);

// Handle Cloud Provider DATABASE_URL environment variable if provided (e.g. Render / Railway / Supabase / Neon)
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (!string.IsNullOrEmpty(databaseUrl) && (databaseUrl.StartsWith("postgres://") || databaseUrl.StartsWith("postgresql://")))
{
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');
    var npgsqlConnectionString = $"Host={uri.Host};Port={(uri.Port > 0 ? uri.Port : 5432)};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={(userInfo.Length > 1 ? userInfo[1] : "")};SSL Mode=Require;Trust Server Certificate=true;";
    builder.Configuration["ConnectionStrings:DefaultConnection"] = npgsqlConnectionString;
}

// IoC (Inversion of Control) controller & view services
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Account/Login";
        options.LogoutPath = "/Admin/Account/Logout";
        options.AccessDeniedPath = "/Admin/Account/AccessDenied";
        options.Cookie.Name = "ModernPortfolioAuth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });

// Configure Forwarded Headers for reverse proxy hosting (Render, Railway, Cloudflare, NGINX)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

// Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserSeedService, UserSeedService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IDatabaseInitializerService, DatabaseInitializerService>();

var app = builder.Build();

app.UseForwardedHeaders();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Auto-initialize PostgreSQL tables and seed default admin user
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializerService>();
        await dbInitializer.InitializeDatabaseAsync();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Failed to initialize database on startup.");
    }
}

app.Run();
