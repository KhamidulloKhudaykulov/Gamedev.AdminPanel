using MediatR;
using Mirradev.Admin.Api.Application.Authentication;
using Mirradev.Admin.Api.Domain.Repositories;

namespace Mirradev.Admin.Api.Application.UseCases.Admins.Commands;

public record LoginAdminCommand(string Email, string Password)
    : IRequest<string>;

public class LoginAdminCommandHandler : IRequestHandler<LoginAdminCommand, string>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IJwtService _jwtService;

    public LoginAdminCommandHandler(IAdminRepository adminRepository, IJwtService jwtService)
    {
        _adminRepository = adminRepository;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _adminRepository.SelectAsync(
            a => a.Email == request.Email && a.Password == request.Password);

        if (admin is null)
        {
            throw new ArgumentException("Email or password is incorrect");
        }

        try
        {
            return await _jwtService.GenerateTokenAsync(admin.Email);
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }
}