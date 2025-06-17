namespace Mirradev.Admin.Api.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }
}