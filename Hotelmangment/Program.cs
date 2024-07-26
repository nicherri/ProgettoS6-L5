using Hotel.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Project.Services.Auth;
using Project.Services.Management;

var builder = WebApplication.CreateBuilder(args);

// Configurazione del database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurazione dei servizi
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ICreazioneService, CreazioneService>();
builder.Services.AddTransient<IRicercheService, RicercheService>();
builder.Services.AddTransient<IVisualizzaCreazioniService, VisualizzaCreazioniService>();
builder.Services.AddTransient<IAddServiziAgg, AddServiziAgg>();

// Configurazione autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura la pipeline delle richieste HTTP
if (!app.Environment.IsDevelopment())
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

app.Run();
