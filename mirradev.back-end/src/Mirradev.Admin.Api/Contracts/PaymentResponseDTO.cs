namespace Mirradev.Admin.Api.Contracts;

public class PaymentResponseDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string CreatedAt { get; set; }
    public int ClientId { get; set; }
}