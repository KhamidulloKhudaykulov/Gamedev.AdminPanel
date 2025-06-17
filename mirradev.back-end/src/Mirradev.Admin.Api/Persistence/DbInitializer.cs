using Microsoft.EntityFrameworkCore;
using Mirradev.Admin.Api.Domain.Entities;

namespace Mirradev.Admin.Api.Persistence;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var _admins = context.Set<Domain.Entities.Admin>();
        var _clients = context.Set<Client>();
        var _payments = context.Set<Payment>();
        var _rates = context.Set<Rate>();
        
        context.Database.Migrate();
        
        
        if (!_admins.Any())
        {
            _admins.AddRange(
                new Domain.Entities.Admin() { Id = 1, Email = "admin@mirra.dev", Password = "admin123" }
            );
        }
        
        if (!_rates.Any())
        {
            _rates.AddRange(
                new Rate() { Id = 1, RateValue = 10 }
            );
        }
        
        if (!_clients.Any())
        {
            _clients.AddRange(
                new Client() { Id = 1, Name = "John", Email = "john1@gmail.com", BalanceToken = 1000 },
                new Client() { Id = 2, Name = "Lisa", Email = "lisa@gmail.com", BalanceToken = 2400 },
                new Client() { Id = 3, Name = "Axe", Email = "axe.me@gmail.com", BalanceToken = 900 }
            );
        }
        
        if (!_payments.Any())
        {
            _payments.AddRange(
                new Payment() { Id = 1, ClientId = 2, Amount = 1000, CreatedAt = DateTime.UtcNow },
                new Payment() { Id = 2, ClientId = 2, Amount = 600, CreatedAt = DateTime.UtcNow },
                new Payment() { Id = 3, ClientId = 3, Amount = 200, CreatedAt = DateTime.UtcNow },
                new Payment() { Id = 4, ClientId = 1, Amount = 400, CreatedAt = DateTime.UtcNow },
                new Payment() { Id = 5, ClientId = 1, Amount = 100, CreatedAt = DateTime.UtcNow }
            );
        }
        
        context.SaveChanges();
    }
}