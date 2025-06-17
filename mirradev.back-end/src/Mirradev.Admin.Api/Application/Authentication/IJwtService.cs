using System.Security.Claims;

namespace Mirradev.Admin.Api.Application.Authentication;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(string login);
    Task<ClaimsPrincipal> VerifyTokenAsync(string token);
}