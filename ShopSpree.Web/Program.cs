using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

using ShopSpree.Infrastructure;
using ShopSpree.Web.Components;
using ShopSpree.Web.Services;
using ShopSpree.Shared.Auth;
using ShopSpree.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructure(builder.Configuration);

// ✅ Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("ShopSpreeApi", client =>
{
    client.BaseAddress =
        new Uri("http://localhost:5116");
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>()
      .CreateClient("ShopSpreeApi"));

builder.Services.AddScoped<
    AuthenticationStateProvider,
    ShopSpreeAuthenticationStateProvider>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();


// ✅ LOGIN ENDPOINT (FIXED)
app.MapPost("/api/auth/login", async (
    LoginRequest request,
    IAuthenticateService authService,
    HttpContext http) =>
{
    Console.WriteLine("LOGIN ENDPOINT HIT");

    var user = await authService.LoginAsync(request);

    if (user is null)
        return Results.Unauthorized();

    Console.WriteLine($"User found: {user.Email}");

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name,
            $"{user.FirstName} {user.LastName}")
    };

    var identity = new ClaimsIdentity(
        claims,
        CookieAuthenticationDefaults.AuthenticationScheme);

    var principal = new ClaimsPrincipal(identity);

    await http.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        principal);

    Console.WriteLine("COOKIE CREATED");

    return Results.Ok();
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();