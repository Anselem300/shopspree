using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ShopSpree.Web.Services;

public class ShopSpreeAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IHttpContextAccessor _http;

    public ShopSpreeAuthenticationStateProvider(IHttpContextAccessor http)
    {
        _http = http;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = _http.HttpContext?.User;

        if (user?.Identity?.IsAuthenticated == true)
        {
            return Task.FromResult(new AuthenticationState(user));
        }

        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        return Task.FromResult(new AuthenticationState(anonymous));
    }

    public void NotifyAuthChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}