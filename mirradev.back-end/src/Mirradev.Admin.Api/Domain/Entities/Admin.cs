namespace Mirradev.Admin.Api.Domain.Entities;

public class Admin
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } =  string.Empty;
}