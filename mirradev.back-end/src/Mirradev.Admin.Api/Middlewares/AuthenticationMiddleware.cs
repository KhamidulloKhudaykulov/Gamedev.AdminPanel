using Mirradev.Admin.Api.Application.Authentication;

namespace Mirradev.Admin.Api.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var _jwtService = context.RequestServices.GetRequiredService<IJwtService>();
        var tokenHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        
        var path = context.Request.Path.Value?.ToLower();
        
        if (path == "/auth" || path.StartsWith("/swagger") || path == "/favicon.ico")
        {
            await _next(context);
            return;
        }

        if (string.IsNullOrEmpty(tokenHeader) || !tokenHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        var token = tokenHeader.Substring("Bearer ".Length);

        var principal = await _jwtService.VerifyTokenAsync(token);
        if (principal == null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid token");
            return;
        }

        context.User = principal;

        await _next(context);
    }
}