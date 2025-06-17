namespace Mirradev.Admin.Api.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal BalanceToken { get; set; }

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}